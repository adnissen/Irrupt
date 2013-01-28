using System;
using UnityEngine;

public class ScrollingFog : FSprite
{
	private int frameCounter;
	private int energyCounter;
	private int animationCounter = 0;
	public ScrollingFog (float _x) : base("ScrollingFog.png")
	{
		this.x = _x;
		this.scale = 2.0f;
	}
	public void Update () {
	}
}
