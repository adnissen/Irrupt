using System;
using UnityEngine;

public class Bullet : FSprite
{
	private int speed;
	private int frameCounter;
	private int animationCounter = 1;
	private bool isDead = false;
	public Bullet (float _x, float _y, int _speed) : base("SmallShot0.png")
	{
		this.x = _x;
		this.y = _y;
		this.scale = 2.0f;
		speed = _speed;
		OrangeGameScript.bullets.Add(this);
		ISoundManager.PlayGunshot();
	}
	private void Kill()
	{
		if (isDead == false)
		{
			isDead = true;
			animationCounter = 0;
		}
	}
	public void Update()
	{
		if (isDead == false)
			x += speed;
		frameCounter++;
		if (frameCounter % 5 == 0)
		{
			if (isDead == false)
			{
				animationCounter++;
				if (animationCounter >= 5)
					animationCounter = 1;
				if (speed != 1)
				{
					if (animationCounter == 1)
						this.SetElementByName("SmallShot0.png");
					else if (animationCounter == 2)
						this.SetElementByName("SmallShot1.png");
					else if (animationCounter == 3)
						this.SetElementByName("SmallShot2.png");
					else if (animationCounter == 4)
						this.SetElementByName("SmallShot3.png");
				}
				else if (speed == 1)
				{
					if (animationCounter == 1)
						this.SetElementByName("BigShot0.png");
					else if (animationCounter == 2)
						this.SetElementByName("BigShot1.png");
					else if (animationCounter == 3)
						this.SetElementByName("BigShot2.png");
					else if (animationCounter == 4)
						this.SetElementByName("BigShot3.png");
				}
			}
			else if (isDead == true)
			{
				animationCounter++;
				if (animationCounter == 0)
					this.SetElementByName("BulletHits0.png");
				else if (animationCounter == 1)
					this.SetElementByName("BulletHits1.png");
				else if (animationCounter == 2)
					this.SetElementByName("BulletHits2.png");
				else if (animationCounter == 3)
					this.SetElementByName("BulletHits3.png");
				else if (animationCounter == 4)
					this.SetElementByName("BulletHits4.png");
				else if (animationCounter == 5)
					this.SetElementByName("BulletHits5.png");
				else if (animationCounter == 6)
					this.SetElementByName("Bullethits6.png");
				else if (animationCounter == 7)
					this.SetElementByName("BulletHits7.png");
				else if (animationCounter == 8)
					this.SetElementByName("BulletHits8.png");
				else if (animationCounter == 9)
					this.SetElementByName("BulletHits9.png");
				else if (animationCounter == 10)
				{
					OrangeGameScript.bullets.Remove(this);
					Futile.stage.RemoveChild(this);
				}
			}
		}
		
		if (this.x >= 159.7772 - 85)
		{
			this.Kill();
		}
		
		for (int i = OrangeGameScript.obstacles.Count -1 ; i > 0; i--) {
			if (Futile.Collide(this, OrangeGameScript.obstacles[i]))
			{
				OrangeGameScript.obstacles[i].Kill();
				this.Kill();
			}
		}
	}
}


	