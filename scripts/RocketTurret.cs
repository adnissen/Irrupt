using UnityEngine;
using System.Collections;

public class RocketTurret : FSprite {

	// Use this for initialization
	private int frameCount = 0;
	private int animationCounter = 0;
	private bool shooting = false;
	public RocketTurret () : base("BigGun0.png")
	{
		this.y = Futile.screen.halfHeight - 48;
		this.x = -159.7772f + 38;
		this.scale = 2.0f;
		//Futile.stage.AddChild(new Bullet(this.x, this.y));
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
				if (animationCounter >= 16)
				{
					animationCounter = 0;
					shooting = false;
				}
				
				if (animationCounter == 0)
					this.SetElementByName("BigGun0.png");
				else if (animationCounter == 1)
					this.SetElementByName("BigGun1.png");
				else if (animationCounter == 3)
					this.SetElementByName("BigGun2.png");
				else if (animationCounter == 4)
					this.SetElementByName("BigGun3.png");
				else if (animationCounter == 5)
					this.SetElementByName("BigGun4.png");
				else if (animationCounter == 6)
					this.SetElementByName("BigGun5.png");
				else if (animationCounter == 7)
					this.SetElementByName("BigGun6.png");
				else if (animationCounter == 8)
					this.SetElementByName("BigGun6.png");
				else if (animationCounter == 9)
				{
					this.SetElementByName("BigGun7.png");
					Futile.stage.AddChild(new Bullet(this.x + 16, this.y, 1));
				}
				else if (animationCounter == 10)
					this.SetElementByName("BigGun5.png");
				else if (animationCounter == 11)
					this.SetElementByName("BigGun4.png");
				else if (animationCounter == 12)
					this.SetElementByName("BigGun3.png");
				else if (animationCounter == 13)
					this.SetElementByName("BigGun2.png");
				else if (animationCounter == 14)
					this.SetElementByName("BigGun1.png");
				else if (animationCounter == 15)
					this.SetElementByName("BigGun0.png");
			}
		}
		for (int i = OrangeGameScript.bullets.Count -1 ; i > 0; i--) {
			OrangeGameScript.bullets[i].Update();	
		}
		
	}
}
