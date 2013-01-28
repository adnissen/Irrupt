using System;
using UnityEngine;

public class Obstacle : FSprite
{
	private int speed;
	private bool isDead = false;
	private int frameCount = 0;
	private int animationCounter = 0;
	private bool isLarge = false;
	public Obstacle () : base("SmallObstacle.png")
	{
		this.y = Futile.screen.halfHeight + 50;
		if (UnityEngine.Random.Range(1, 6) == 5)
		{
			this.SetElementByName("obstacle.png");
			isLarge = true;
		}
		this.width = 24;
		this.height = 24;
		this.scale = 2.0f;
		speed = UnityEngine.Random.Range(1, 3);
		this.x = UnityEngine.Random.Range(-159.7772f + 85, 159.7772f - 85);
		OrangeGameScript.obstacles.Add(this);
	}
	
	public void Kill()
	{
		if (isDead == false)
			ISoundManager.PlayAsteriodBreak();
		isDead = true;
		
	}
	
	public void Update()
	{
		frameCount++;
		if (isDead == true)
		{
			if (frameCount % 5 == 0)
			{
				animationCounter++;
				if (isLarge == false)
				{
					if (animationCounter == 1)
						this.SetElementByName("SmallBlockDead0.png");
					else if (animationCounter == 2)
						this.SetElementByName("SmallBlockDead1.png");
					else if (animationCounter == 3)
						this.SetElementByName("SmallBlockDead2.png");
					else if (animationCounter == 4)
						this.SetElementByName("SmallBlockDead3.png");
					else if (animationCounter == 5)
					{
						OrangeGameScript.obstacles.Remove(this);
						Futile.stage.RemoveChild(this);
					}
				}
				else if (isLarge == true)
				{
					if (animationCounter == 1)
						this.SetElementByName("BigBlockDead0.png");
					else if (animationCounter == 2)
						this.SetElementByName("BigBlockDead1.png");
					else if (animationCounter == 3)
						this.SetElementByName("BigBlockDead2.png");
					else if (animationCounter == 4)
						this.SetElementByName("BigBlockDead3.png");
					else if (animationCounter == 5)
						this.SetElementByName("BigBlockDead4.png");
					else if (animationCounter == 6)
					{
						OrangeGameScript.obstacles.Remove(this);
						Futile.stage.RemoveChild(this);
					}
				}
					
			}
		}
		
		y -= speed + OrangeGameScript.bonusSpeed;
		if (InitScript.CollidePlayer(this, OrangeGameScript.testPlayer) && isDead == false && OrangeGameScript.testPlayer.isPlayerDead() == false)
		{
			//call a player death function and play the animation
			
			//don't call reset until the anim is complete, so call it from Spaceman.csharp
			OrangeGameScript.testPlayer.Kill();
			Debug.Log("YOU'RE DEAD AHHAHA FUCK YOU");	
		}
	 	if (y < -Futile.screen.halfHeight - 50)
		{
			OrangeGameScript.obstacles.Remove(this);
			Futile.stage.RemoveChild(this);
		}
	}
}


	