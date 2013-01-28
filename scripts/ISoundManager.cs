using UnityEngine;
using System.Collections;

public class ISoundManager {
	//so these need to be loaded just like this or else performance just DIES
	//again, credit goes to Matt Rix for this bit
	static public void Start()
	{
		Resources.Load("Audio/asteroid");
		Resources.Load("Audio/forwardbutton");
		Resources.Load("Audio/gunshot");
		Resources.Load("Audio/laser");
		Resources.Load("Audio/menutransitions");
		Resources.Load("Audio/playerdies");
		Resources.Load("Audio/playerhold");
		Resources.Load("Audio/playerrelease");
		Resources.Load("Audio/playtransitions");
		Resources.Load("Audio/forwardbutton");
		Resources.Load("Audio/victory");	
	}
	static public void PlayMusic()
	{
		FSoundManager.PlayMusic("DireProspects", .3f);
	}
	static public void PlayAsteriodBreak()
	{
		FSoundManager.PlaySound("asteroid", .15f);
	}
	static public void PlayForwardButton()
	{
		FSoundManager.PlaySound("forwardbutton", .15f);
	}
	static public void PlayGunshot()
	{
		FSoundManager.PlaySound("gunshot", .15f);
	}
	static public void PlayLaser()
	{
		FSoundManager.PlaySound("laser", .15f);
	}
	static public void PlayMenuTransitions()
	{
		FSoundManager.PlaySound("menutransitions", .15f);
	}
	static public void PlayPlayerDie()
	{
		FSoundManager.PlaySound("playerdies", .15f);
	}
	static public void PlayPlayerHold()
	{
		FSoundManager.PlaySound("playerhold", .15f);
	}
	static public void PlayPlayerRelease()
	{
		FSoundManager.PlaySound("playerrelease", .25f);
	}
	static public void PlayTransitions()
	{
		FSoundManager.PlaySound("playtransitions", .15f);
	}
	static public void PlayPowerup()
	{
		FSoundManager.PlaySound("forwardbutton", .15f);
	}
	static public void PlayVictory()
	{
		FSoundManager.PlaySound("victory", .15f);
	}
}
