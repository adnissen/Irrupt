using System;
using UnityEngine;

public class Lazer : FSprite
{
	private int speed;
	private int frameCounter;
	private int animationCounter;
	private bool shooting;
	public Lazer () : base("Laserbeam0.png")
	{
		this.x = OrangeGameScript.laser.x + 120;
		this.y = -601;
		this.scale = 2.0f;
		speed = 1;
	}
	
	public void Spawn()
	{
		ISoundManager.PlayLaser();
		shooting = true;
		this.y = OrangeGameScript.laser.y - 2;
	}
	
	public void Kill()
	{
		shooting = false;
		animationCounter = 0;
		this.y = -601;	
	}
	
	public void Update()
	{
		frameCounter++;
		
		if (shooting == true)
		{
			if (frameCounter % 9 == 0)
			{
				animationCounter++;
				
				if (animationCounter == 1)
					this.SetElementByName("Laserbeam1.png");
				else if (animationCounter == 2)
					this.SetElementByName("Laserbeam2.png");
				else if (animationCounter == 3)
					this.SetElementByName("Laserbeam3.png");
				else if (animationCounter == 4)
					this.SetElementByName("Laserbeam4.png");
				else if (animationCounter == 5)
					this.SetElementByName("Laserbeam5.png");
				else if (animationCounter == 6)
					this.SetElementByName("Laserbeam6.png");
				else if (animationCounter == 7)
					this.SetElementByName("Laserbeam7.png");
				else if (animationCounter == 8)
					this.SetElementByName("Laserbeam8.png");
				else if (animationCounter == 9)
					this.SetElementByName("Laserbeam9.png");
				else if (animationCounter == 10)
					this.SetElementByName("Laserbeam10.png");
				else if (animationCounter == 11)
					this.SetElementByName("Laserbeam9.png");
				else if (animationCounter == 12)
					this.SetElementByName("Laserbeam8.png");
				else if (animationCounter == 13)
					this.SetElementByName("Laserbeam7.png");
				else if (animationCounter == 14)
					this.SetElementByName("Laserbeam6.png");
				else if (animationCounter == 15)
					this.SetElementByName("Laserbeam5.png");
				else if (animationCounter == 16)
					this.SetElementByName("Laserbeam4.png");
				else if (animationCounter == 17)
					this.SetElementByName("Laserbeam3.png");
				else if (animationCounter == 18)
					this.SetElementByName("Laserbeam2.png");
				else if (animationCounter == 19)
					this.SetElementByName("Laserbeam1.png");
			}
		}
		
		for (int i = OrangeGameScript.obstacles.Count -1 ; i > 0; i--) {
			if (Futile.Collide(this, OrangeGameScript.obstacles[i]))
			{
				OrangeGameScript.obstacles[i].Kill();
			}
		}
	}
}


	