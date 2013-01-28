using System;
using UnityEngine;

public class Powerup : FSprite
{
	private int speed;
	private int type;
	private int frameCounter;
	private int animationCounter = 1;
	private bool hit = false;
	public Powerup () : base("GetBig0.png")
	{
		//that first image doesn't matter: it gets swapped out instantly anyways
		type = UnityEngine.Random.Range(1,4);
		//type = 2;
		this.y = Futile.screen.halfHeight + 50;
		this.scale = 2.0f;
		speed = 1;
		this.x = UnityEngine.Random.Range(-159.7772f + 85, 159.7772f - 85);
		OrangeGameScript.powerups.Add(this);
	}
	
	private void Kill()
	{
		if (hit == false)
		{
			ISoundManager.PlayPowerup();
			Debug.Log("POWERUP GET");
			animationCounter = 0;
			hit = true;
			if (type == 1)
				OrangeGameScript.turret.Shoot();
			else if (type == 2)
				OrangeGameScript.laser.Shoot();
			else if (type == 3)
				OrangeGameScript.rocket.Shoot();
		}
	}
	
	public void Update()
	{
		frameCounter++;
		if (frameCounter % 5 == 0)
		{
			if (hit == false)
			{
				animationCounter++;
				if (animationCounter >= 17)
					animationCounter = 1;
				if (type == 1)
				{
					if (animationCounter == 1)
						this.SetElementByName("GetSmall0.png");
					else if (animationCounter == 2)
						this.SetElementByName("GetSmall1.png");
					else if (animationCounter == 3)
						this.SetElementByName("GetSmall2.png");
					else if (animationCounter == 4)
						this.SetElementByName("GetSmall3.png");
					else if (animationCounter == 5)
						this.SetElementByName("GetSmall4.png");
					else if (animationCounter == 6)
						this.SetElementByName("GetSmall5.png");
					else if (animationCounter == 7)
						this.SetElementByName("GetSmall6.png");
					else if (animationCounter == 8)
						this.SetElementByName("GetSmall7.png");
					else if (animationCounter == 9)
						this.SetElementByName("GetSmall8.png");
					else if (animationCounter == 10)
						this.SetElementByName("GetSmall9.png");
					else if (animationCounter == 11)
						this.SetElementByName("GetSmall10.png");
					else if (animationCounter == 12)
						this.SetElementByName("GetSmall11.png");
					else if (animationCounter == 13)
						this.SetElementByName("GetSmall12.png");
					else if (animationCounter == 14)
						this.SetElementByName("GetSmall13.png");
					else if (animationCounter == 15)
						this.SetElementByName("GetSmall14.png");
					else if (animationCounter == 16)
						this.SetElementByName("GetSmall15.png");
				}
				else if (type == 2)
				{
					if (animationCounter == 1)
						this.SetElementByName("GetBig0.png");
					else if (animationCounter == 2)
						this.SetElementByName("GetBig1.png");
					else if (animationCounter == 3)
						this.SetElementByName("GetBig2.png");
					else if (animationCounter == 4)
						this.SetElementByName("GetBig3.png");
					else if (animationCounter == 5)
						this.SetElementByName("GetBig4.png");
					else if (animationCounter == 6)
						this.SetElementByName("GetBig5.png");
					else if (animationCounter == 7)
						this.SetElementByName("GetBig6.png");
					else if (animationCounter == 8)
						this.SetElementByName("GetBig7.png");
					else if (animationCounter == 9)
						this.SetElementByName("GetBig8.png");
					else if (animationCounter == 10)
						this.SetElementByName("GetBig9.png");
					else if (animationCounter == 11)
						this.SetElementByName("GetBig10.png");
					else if (animationCounter == 12)
						this.SetElementByName("GetBig11.png");
					else if (animationCounter == 13)
						this.SetElementByName("GetBig12.png");
					else if (animationCounter == 14)
						this.SetElementByName("GetBig13.png");
					else if (animationCounter == 15)
						this.SetElementByName("GetBig14.png");
					else if (animationCounter == 16)
						this.SetElementByName("GetBig15.png");
				}
				else if (type == 3)
				{
					if (animationCounter == 1)
						this.SetElementByName("GetLaser0.png");
					else if (animationCounter == 2)
						this.SetElementByName("GetLaser1.png");
					else if (animationCounter == 3)
						this.SetElementByName("GetLaser2.png");
					else if (animationCounter == 4)
						this.SetElementByName("GetLaser3.png");
					else if (animationCounter == 5)
						this.SetElementByName("GetLaser4.png");
					else if (animationCounter == 6)
						this.SetElementByName("GetLaser5.png");
					else if (animationCounter == 7)
						this.SetElementByName("GetLaser6.png");
					else if (animationCounter == 8)
						this.SetElementByName("GetLaser7.png");
					else if (animationCounter == 9)
						this.SetElementByName("GetLaser8.png");
					else if (animationCounter == 10)
						this.SetElementByName("GetLaser9.png");
					else if (animationCounter == 11)
						this.SetElementByName("GetLaser10.png");
					else if (animationCounter == 12)
						this.SetElementByName("GetLaser11.png");
					else if (animationCounter == 13)
						this.SetElementByName("GetLaser12.png");
					else if (animationCounter == 14)
						this.SetElementByName("GetLaser13.png");
					else if (animationCounter == 15)
						this.SetElementByName("GetLaser14.png");
					else if (animationCounter == 16)
						this.SetElementByName("GetLaser15.png");
				}
			}
			else if (hit == true)
			{
				animationCounter++;
				
				if (animationCounter == 1)
					this.SetElementByName("PowerupTouch0.png");
				else if (animationCounter == 2)
					this.SetElementByName("PowerupTouch1.png");
				else if (animationCounter == 3)
					this.SetElementByName("PowerupTouch2.png");
				else if (animationCounter == 4)
					this.SetElementByName("PowerupTouch3.png");
				else if (animationCounter == 5)
					this.SetElementByName("PowerupTouch4.png");
				else if (animationCounter == 6)
				{
					OrangeGameScript.powerups.Remove(this);
					Futile.stage.RemoveChild(this);
				}
			}
		}
		
		if (hit == false)
			y -= speed;
		else 
			y += speed;
		if (Futile.Collide(this, OrangeGameScript.testPlayer))
		{
			this.Kill();
		}
	 	if (y < -Futile.screen.halfHeight - 50)
		{
			OrangeGameScript.powerups.Remove(this);
			Futile.stage.RemoveChild(this);
		}
	}
}


	