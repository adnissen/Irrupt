using UnityEngine;
using System.Collections;

public class LazerTurret : FSprite {

	// Use this for initialization
	private int frameCount = 0;
	private int animationCounter = 0;
	private bool shooting = false;
	public LazerTurret () : base("Laser0.png")
	{
		this.y = Futile.screen.halfHeight - 144f;
		this.x = -159.7772f + 38f;
		this.scale = 2.0f;
	}
	
	public void Shoot()
	{
		shooting = true;
	}
	
	// Update is called once per frame
	public void Update () {
		frameCount++;
		if (shooting == true)
		{
			if (frameCount % 5 == 0)
			{
				animationCounter++;
				if (animationCounter >= 32)
				{
					animationCounter = 0;
					shooting = false;
				}
				
				if (animationCounter == 0)
					this.SetElementByName("Laser0.png");
				else if (animationCounter == 1)
					this.SetElementByName("Laser1.png");
				else if (animationCounter == 3)
					this.SetElementByName("Laser2.png");
				else if (animationCounter == 4)
					this.SetElementByName("Laser3.png");
				else if (animationCounter == 5)
					this.SetElementByName("Laser4.png");
				else if (animationCounter == 6)
					this.SetElementByName("Laser5.png");
				else if (animationCounter == 7)
				{
					this.SetElementByName("Laser6.png");
					OrangeGameScript.laserActual.Spawn();
				}
				else if (animationCounter == 8)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 9)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 10)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 11)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 12)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 13)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 14)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 15)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 16)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 17 && animationCounter <= 24)
					this.SetElementByName("Laser6.png");
				else if (animationCounter == 25)
				{
					this.SetElementByName("Laser6.png");
					OrangeGameScript.laserActual.Kill();
				}
				else if (animationCounter == 26)
					this.SetElementByName("Laser5.png");
				else if (animationCounter == 27)
					this.SetElementByName("Laser4.png");
				else if (animationCounter == 28)
					this.SetElementByName("Laser3.png");
				else if (animationCounter == 29)
					this.SetElementByName("Laser2.png");
				else if (animationCounter == 30)
					this.SetElementByName("Laser1.png");
				else if (animationCounter == 31)
					this.SetElementByName("Laser0.png");
			}
		}
	}
}
