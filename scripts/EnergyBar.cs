using System;
using UnityEngine;

public class EnergyBar : FSprite
{
	private int frameCounter;
	private int energyCounter;
	public EnergyBar () : base("EnergyBar0.png")
	{
		this.y = Futile.screen.halfHeight - 90;
		this.x = -159.7772f + 160;
		this.width = 28;
		this.height = 10;
		this.scale = 2.0f;
	}
	public void Update () {
		if (OrangeGameScript.testPlayer.getEnergy() >= 60)
			this.SetElementByName("EnergyDepletes0.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 53)
			this.SetElementByName("EnergyDepletes1.png");	
		else if (OrangeGameScript.testPlayer.getEnergy() == 46)
			this.SetElementByName("EnergyDepletes2.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 39)
			this.SetElementByName("EnergyDepletes3.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 32)
			this.SetElementByName("EnergyDepletes4.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 25)
			this.SetElementByName("EnergyDepletes5.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 18)
			this.SetElementByName("EnergyDepletes6.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 11)
			this.SetElementByName("EnergyDepletes7.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 4)
			this.SetElementByName("EnergyDepletes8.png");
		else if (OrangeGameScript.testPlayer.getEnergy() == 0)
			this.SetElementByName("EnergyDepletes9.png");
	}
}
