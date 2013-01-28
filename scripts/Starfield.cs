using System;
using UnityEngine;

public class Starfield : FSprite
{
	private int frameCounter;
	private int energyCounter;
	private int animationCounter = 0;
	private bool isFast;
	private float speed;
	public Starfield (float _x, bool _isFast) : base("Starfield4.png")
	{
		isFast = _isFast;
		speed = .5f;
		this.x = _x;
		this.scale = 2.0f;
	}
	public void setSpeed(float newspeed)
	{
		speed = newspeed;
	}
	public void Update () {
		
		x -= speed;
		
		if (x <= (-320 - 80))
			x = 320 + 80;
	}
}
