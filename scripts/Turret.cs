using UnityEngine;
using System.Collections;

public class Turret : FSprite {

	// Use this for initialization
	private int frameCount = 0;
	private int animationCounter = 0;
	private bool shooting = false;
	private Bullet testBullet;
	public Turret () : base("Gun0.png")
	{
		this.y = Futile.screen.halfHeight - 96;
		this.x = -121.7772f;
		this.scale = 2.0f;
		testBullet = new Bullet(this.x, this.y, 4);
		Futile.stage.AddChild(testBullet);
		Debug.Log(this.x);
	}
	
	public void Shoot()
	{
		shooting = true;
	}
	override public void HandleRemovedFromStage()
	{
		Futile.stage.RemoveChild(testBullet);
		base.HandleRemovedFromStage();	
	}
	// Update is called once per frame
	public void Update () {
		frameCount++;
		if (shooting == true)
		{
			if (frameCount % 5 == 0)
			{
				animationCounter++;
				if (animationCounter >= 26)
				{
					animationCounter = 0;
					shooting = false;
				}
				
				if (animationCounter == 0)
					this.SetElementByName("Gun0.png");
				else if (animationCounter == 1)
					this.SetElementByName("Gun1.png");
				else if (animationCounter == 3)
					this.SetElementByName("Gun2.png");
				else if (animationCounter == 4)
					this.SetElementByName("Gun3.png");
				else if (animationCounter == 5)
					this.SetElementByName("Gun4.png");
				else if (animationCounter == 6)
					this.SetElementByName("Gun5.png");
				else if (animationCounter == 7)
					this.SetElementByName("Gun6.png");
				else if (animationCounter == 8)
					this.SetElementByName("Gun6.png");
				else if (animationCounter == 9)
				{
					this.SetElementByName("Gun7.png");
					Futile.stage.AddChild(new Bullet(this.x + 16, this.y, 4));
				}
				else if (animationCounter == 10 && animationCounter <= 13)
					this.SetElementByName("Gun6.png");
				else if (animationCounter == 14)
				{
					this.SetElementByName("Gun7.png");
					Futile.stage.AddChild(new Bullet(this.x + 16, this.y, 4));
				}
				else if (animationCounter == 15 && animationCounter <= 18)
					this.SetElementByName("Gun6.png");
				else if (animationCounter == 19)
				{
					this.SetElementByName("Gun7.png");
					Futile.stage.AddChild(new Bullet(this.x + 16, this.y, 4));
				}
				else if (animationCounter == 20)
					this.SetElementByName("Gun5.png");
				else if (animationCounter == 21)
					this.SetElementByName("Gun4.png");
				else if (animationCounter == 22)
					this.SetElementByName("Gun3.png");
				else if (animationCounter == 23)
					this.SetElementByName("Gun2.png");
				else if (animationCounter == 24)
					this.SetElementByName("Gun1.png");
				else if (animationCounter == 25)
					this.SetElementByName("Gun0.png");
			}
		}
		for (int i = OrangeGameScript.bullets.Count -1 ; i > 0; i--) {
			OrangeGameScript.bullets[i].Update();	
		}
		
	}
}
