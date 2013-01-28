using UnityEngine;
using System.Collections;

public class InstructionsPage : FPage {
	
	private static Starfield background;
	private static Starfield background2;
	public static FSprite menuBackground;
	
	public static FSprite menuAnims;
	
	private static FButton btnInstructions;
	
	private static FButton btnForward;
	private static FButton btnBackward;
	
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
		
		menuAnims = new FSprite("MenutoInstruct0.png");
		menuAnims.scale = 2.0f;
		menuAnims.x = 0;
		Futile.stage.AddChild(menuAnims);
		
		menuBackground = new FSprite("info1-0.png");
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
		
		btnForward = new FButton("ForwardButton.png");
		btnForward.x = 100;
		btnForward.y = 0;
		btnForward.scale = 2.0f;
		btnForward.isVisible = true;
		Futile.stage.AddChild(btnForward);
		
		btnBackward = new FButton("Backbutton.png");
		btnBackward.x = -100;
		btnBackward.y = 0;
		btnBackward.scale = 2.0f;
		btnBackward.isVisible = false;
		Futile.stage.AddChild(btnBackward);
		
		btnInstructions.SignalRelease += HandleInfoButtonRelease;
		btnForward.SignalRelease += HandleForwardButtonRelease;
		btnBackward.SignalRelease += HandleBackwardButtonRelease;
		
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
	}
	// Update is called once per frame
	private void HandleBackwardButtonRelease (FButton button)
	{
		ISoundManager.PlayForwardButton();
		tutorialIndex -= 1;
		animationCounter = 3;
		frameCount = 55;
		if (tutorialIndex <= 0)
			tutorialIndex = 1;
		if (tutorialIndex == 1)
		{
			btnForward.isVisible = true;
			btnBackward.isVisible = false;
		}
		else if (tutorialIndex == 2)
		{
			btnForward.isVisible = true;
			btnBackward.isVisible = true;
		}
		else if (tutorialIndex == 3)
		{
			btnForward.isVisible = false;
			btnBackward.isVisible = true;
		}
	}
	private void HandleForwardButtonRelease (FButton button)
	{
		ISoundManager.PlayForwardButton();
		tutorialIndex += 1;
		animationCounter = 3;
		frameCount = 55;
		if (tutorialIndex >= 4)
			tutorialIndex = 3;
		if (tutorialIndex == 1)
		{
			btnForward.isVisible = true;
			btnBackward.isVisible = false;
		}
		else if (tutorialIndex == 2)
		{
			btnForward.isVisible = true;
			btnBackward.isVisible = true;
		}
		else if (tutorialIndex == 3)
		{
			btnForward.isVisible = false;
			btnBackward.isVisible = true;
		}
	}
	private void HandleInfoButtonRelease (FButton button)
	{
		if (InitScript.inGame == false)
			playAnimation();
	}
	private void playAnimation()
	{
		Futile.stage.RemoveChild(menuBackground);
		Futile.stage.RemoveChild(btnForward);
		Futile.stage.RemoveChild(btnBackward);
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
				if (animationCounter >= 8)
					animationCounter = 0;
				
				if (animationCounter == 0)
					menuAnims.SetElementByName("MenutoInstruct0.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("MenutoInstruct1.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("MenutoInstruct2.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("MenutoInstruct3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("MenutoInstruct4.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("MenutoInstruct5.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("MenutoInstruct6.png");
				else if (animationCounter == 7)
				{
					//menuAnims.isVisible = true;
					menuBackground.isVisible = true;
					btnInstructions.isVisible = true;
					transitionIn = false;
					animationCounter = 0;
				}
			}
		}
		if (transitionIn == false && playingTransition == false)
		{
			if (frameCount % 60 == 0)
			{
				animationCounter++;
				if (animationCounter >= 3)
					animationCounter = 0;
				
				if (tutorialIndex == 1)
				{
					if (animationCounter == 0)
						menuBackground.SetElementByName("info1-0.png");
					else if (animationCounter == 1)
						menuBackground.SetElementByName("Info1-1.png");
					else if (animationCounter == 2)
						menuBackground.SetElementByName("Info1-2.png");
				}
				else if (tutorialIndex == 2)
				{				
					if (animationCounter == 0)
						menuBackground.SetElementByName("Info2-0.png");
					else if (animationCounter == 1)
						menuBackground.SetElementByName("Info2-1.png");
					else if (animationCounter == 2)
						menuBackground.SetElementByName("Info2-2.png");
				}
				else if (tutorialIndex == 3)
				{
					if (animationCounter == 0)
						menuBackground.SetElementByName("Info3.png");
					else if (animationCounter == 1)
						menuBackground.SetElementByName("Info3.png");
					else if (animationCounter == 2)
						menuBackground.SetElementByName("Info3.png");
				}
			}
		}
		if (playingTransition == true)
		{
			if (frameCount % 3 == 0)
			{
				animationCounter++;
				if (animationCounter >= 8)
					animationCounter = 0;
				
				if (animationCounter == 0)
					menuAnims.SetElementByName("MenutoInstruct6.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("MenutoInstruct5.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("MenutoInstruct4.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("MenutoInstruct3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("MenutoInstruct2.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("MenutoInstruct1.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("MenutoInstruct0.png");
				else if (animationCounter == 7)
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
