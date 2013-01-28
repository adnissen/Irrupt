using UnityEngine;
using System.Collections;

public class CreditsPage : FPage {
	
	private static Starfield background;
	private static Starfield background2;
	public static FSprite menuBackground;
	
	public static FSprite menuAnims;
	
	private static FButton btnInstructions;
	
	private bool playingTransition = false;
	private bool playReverse = false;
	private bool transitionIn = false;
	
	private int frameCount = 0;
	private int animationCounter = 0;
	
	private int tutorialIndex = 1;
	// Use this for initialization
	override public void Start () {
		transitionIn = true;
		InitScript.inGame = false;
		background = new Starfield(InitScript.bg1Pos,false);
		Futile.stage.AddChild(background);
		
		background2 = new Starfield(InitScript.bg2Pos, false);
		Futile.stage.AddChild(background2);	
		
		menuAnims = new FSprite("MenutoCredits0.png");
		menuAnims.scale = 2.0f;
		menuAnims.x = 0;
		//menuAnims.isVisible = false;
		Futile.stage.AddChild(menuAnims);
		
		menuBackground = new FSprite("CreditScreen.png");
		menuBackground.scale = 2.0f;
		menuBackground.x = 0;
		menuBackground.isVisible = false;
		Futile.stage.AddChild(menuBackground);
		
		btnInstructions = new FButton("MenuButton.png");
		btnInstructions.x -= 1;
		btnInstructions.y -= 166;
		btnInstructions.scale = 2.0f;
		btnInstructions.isVisible = false;
		Futile.stage.AddChild(btnInstructions);
		InitScript.blackBar1.MoveToTop();
		InitScript.blackBar2.MoveToTop();
		
		btnInstructions.SignalRelease += HandleInfoButtonRelease;
		
		Futile.instance.SignalUpdate += HandleUpdate;
		
	}
	override public void HandleAddedToStage()
	{
		base.HandleAddedToStage();
	}
	override public void HandleRemovedFromStage()
	{
		Destroy();
		Futile.instance.SignalUpdate -= HandleUpdate;
		base.HandleRemovedFromStage();	
	}
	public static void Destroy()
	{
		Futile.stage.RemoveChild(background);
		Futile.stage.RemoveChild(background2);
		Futile.stage.RemoveChild(menuAnims);
		//Futile.stage.RemoveChild(btnInstructions);
	}
	// Update is called once per frame
	private void HandleInfoButtonRelease (FButton button)
	{
		if (InitScript.inGame == false)
			playAnimation();
	}
	private void playAnimation()
	{
		Futile.stage.RemoveChild(menuBackground);
		btnInstructions.isVisible = false;
		playingTransition = true; 
		
	}
	protected void HandleUpdate () {
		background.Update();
		InitScript.bg1Pos = background.x;
		background2.Update();
		InitScript.bg2Pos = background2.x;
		//if (Input.GetMouseButtonDown(0))
		//{
		//	playAnimation();	
		//}
		frameCount++;
		if (transitionIn == true)
		{
			if (frameCount % 3 == 0)
			{
				animationCounter++;
				if (animationCounter >= 9)
					animationCounter = 0;
				
				if (animationCounter == 0)
					menuAnims.SetElementByName("MenutoCredits0.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("MenutoCredits1.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("MenutoCredits2.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("MenutoCredits3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("MenutoCredits4.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("MenutoCredits5.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("MenutoCredits6.png");
				else if (animationCounter == 7)
					menuAnims.SetElementByName("Menutocredits7.png");
				else if (animationCounter == 8)
				{
					//menuAnims.isVisible = true;
					menuBackground.isVisible = true;
					btnInstructions.isVisible = true;
					transitionIn = false;
				}
			}
		}
		if (playingTransition == true)
		{
			if (frameCount % 3 == 0)
			{
				animationCounter++;
				if (animationCounter >= 9)
					animationCounter = 0;
				
				if (animationCounter == 0)
					menuAnims.SetElementByName("Menutocredits7.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("MenutoCredits6.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("MenutoCredits5.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("MenutoCredits4.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("MenutoCredits3.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("MenutoCredits2.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("MenutoCredits1.png");
				else if (animationCounter == 7)
					menuAnims.SetElementByName("MenutoCredits0.png");
				else if (animationCounter == 8)
				{
					InitScript.shouldPlayMenuTransition = false;
					InitScript.gotoMenu();
				}
			}
		}
		/*if (Input.GetMouseButtonDown(0))
		{
			if (InitScript.inGame == false)
				InitScript.goToGame();
		}*/
	}
}
