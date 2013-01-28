using System;
using UnityEngine;

public class Spaceman : FSprite
{
	private int energy = 60;
	private int frameCount = 0;
	private int animationCounter = 0;
	private int jetsCd = 0;
	private static bool isDead = false;
	private Rect collisionRect;
	private bool playingHold = false;
	public Spaceman () : base("pFloat0.png")
	{
		this.y = -Futile.screen.halfHeight + 160;
		//so here I use the exact width, rather than the property in Futile.screen.halfwidth
		//this is because when it scales up on the ipad, it needs this value to be exact or 
		//the things won't spawn in the right place.
		//I have no idea why this only needs to be done for width and not height
		this.x = this.x - 159.7772f;

		//if you set the collision rect here it won't reset when the graphic changes
		collisionRect = new Rect(-3.0f, -7.0f, 7.0f, 12.0f);
		this.scale = 2.0f;
	}
	
	public Rect getRect()
	{
		return collisionRect;	
	}
	
	public float getEnergy()
	{
		return energy;
	}
	
	public void Kill()
	{
		ISoundManager.PlayPlayerDie();
		isDead = true;
		animationCounter = 0;
		//InitScript.inGame = false;
	}
	public bool isPlayerDead()
	{
		return isDead;	
	}
	public void PlayerAlive()
	{
		isDead = false;	
		animationCounter = 0;
	}
	
	public void Update () {
		frameCount++;
		if (frameCount % 10 == 0 && isDead == false)
		{
			animationCounter++;
			if (animationCounter >= 4)
				animationCounter = 0;
			
			if (!Input.GetMouseButton(0) && energy > 0)
			{
				if (animationCounter == 0)
					this.SetElementByName("pFloat0.png");
				else if (animationCounter == 1)
					this.SetElementByName("pFloat1.png");
				else if (animationCounter == 2)
					this.SetElementByName("pFloat2.png");
			}
				
			else
			{
				if (animationCounter >= 2)
					animationCounter = 0;
				if (animationCounter == 0)
					this.SetElementByName("PHold1.png");
				else if (animationCounter == 1)
					this.SetElementByName("PHold2.png");
				
			}
		}
		if (isDead == true)
		{
			if (frameCount % 5 == 0)
			{
				animationCounter++;
				if (animationCounter == 0)
					this.SetElementByName("pDeath0.png");
				else if (animationCounter == 1)
					this.SetElementByName("pDeath1.png");
				else if (animationCounter == 2)
					this.SetElementByName("pDeath2.png");
				else if (animationCounter == 3)
					this.SetElementByName("pDeath3.png");
				else if (animationCounter == 4)
					this.SetElementByName("pDeath4.png");
				else if (animationCounter == 5)
					this.SetElementByName("pDeath5.png");
				else if (animationCounter == 6)
					this.SetElementByName("pDeath6.png");
				else if (animationCounter == 7)
				{
					this.SetElementByName("pDeath7.png");
					OrangeGameScript.endGame();
					InitScript.inGame = false;
				}
			}
		}
		if (isDead == false)
		{
			jetsCd -= 3;
			if (Input.GetMouseButtonUp(0))
			{
				playingHold = false;
				ISoundManager.PlayPlayerRelease();
			}
			if (Input.GetMouseButton(0) && energy > 0 && jetsCd <= 0)
			{
				if (playingHold == false)
				{
					playingHold = true;
					ISoundManager.PlayPlayerHold();
				}
				OrangeGameScript.setStarfieldSpeed(.15f);
				energy -= 1;
				if (energy == 0)
				{
					jetsCd = 60;
				}
				//Debug.Log(energy.ToString());
			}
			else
			{
				if (energy >= 0 && energy < 60)
				{
					energy += 3;
					OrangeGameScript.setStarfieldSpeed(3f);
					this.x += 8;
				}
				else
				{
					OrangeGameScript.setStarfieldSpeed(.5f);
					this.x += 3;
				}
				
			}
			
			if (this.x  > 159.7772 +32)
			{
				ISoundManager.PlayVictory();
				this.x = -159.7772f - 32;
				energy = 60;
				OrangeGameScript.bonusSpeed += 0.1f;
				OrangeGameScript.increaseScore(1);
				OrangeGameScript.displayScore();
			}
		}
	}
}