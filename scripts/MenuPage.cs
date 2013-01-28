using UnityEngine;
using System.Collections;

public class MenuPage : FPage {
	
	private static Starfield background;
	private static Starfield background2;
	public static FSprite menuBackground;
	
	public static FSprite menuAnims;
	
	private static FButton btnInstructions;
	private static FButton btnCredits;
	private static FButton btnPlay;
	
	private bool playingTransition = false;
	private bool playReverse = false;
	private bool transitionIn = false;
	
	private int frameCount = 0;
	private int animationCounter = 0;
	// Use this for initialization
	override public void Start () {
		transitionIn = InitScript.shouldPlayMenuTransition;
		InitScript.inGame = false;
		
		background = new Starfield(InitScript.bg1Pos,false);
		Futile.stage.AddChild(background);
		
		background2 = new Starfield(InitScript.bg2Pos, false);
		Futile.stage.AddChild(background2);		
		
		menuBackground = new FSprite("MenuStatic.png");
		menuBackground.scale = 2.0f;
		menuBackground.x = 0;
		if (InitScript.shouldPlayMenuTransition == true)
			menuBackground.isVisible = false;
		Futile.stage.AddChild(menuBackground);
		
		menuAnims = new FSprite("Menutoplay6.png");
		if (InitScript.shouldPlayMenuTransition == false)
			menuAnims.SetElementByName("MenuAnim0.png");
		menuAnims.scale = 2.0f;
		menuAnims.x = 0;
		//menuAnims.isVisible = false;
		Futile.stage.AddChild(menuAnims);
		
		btnInstructions = new FButton("InfoButton.png");
		btnInstructions.x -= 1;
		btnInstructions.y -= 126;
		btnInstructions.scale = 2.0f;
		if (InitScript.shouldPlayMenuTransition == true)
			btnInstructions.isVisible = false;
		Futile.stage.AddChild(btnInstructions);
		
		btnCredits = new FButton("CreditsButton.png");
		btnCredits.x -= 1;
		btnCredits.y -= 166;
		btnCredits.scale = 2.0f;
		if (InitScript.shouldPlayMenuTransition == true)
			btnCredits.isVisible = false;
		Futile.stage.AddChild(btnCredits);
		
		btnPlay = new FButton("PlayButton.png");
		btnPlay.x = 0;
		btnPlay.y = 0;
		btnPlay.scale = 2.0f;
		Futile.stage.AddChild(btnPlay);
		
		InitScript.blackBar1.MoveToTop();
		InitScript.blackBar2.MoveToTop();
		
		btnInstructions.SignalRelease += HandleInfoButtonRelease;
		btnCredits.SignalRelease += HandleCreditButtonRelease;
		btnPlay.SignalRelease += HandlePlayButtonRelease;
		
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
		Futile.stage.RemoveChild(btnCredits);
		Futile.stage.RemoveChild(btnInstructions);
	}
	private void HandlePlayButtonRelease(FButton button)
	{
		playAnimation();
	}
	// Update is called once per frame
	private void HandleCreditButtonRelease (FButton button)
	{
		if (InitScript.inGame == false)
			InitScript.gotoCredits();
	}
	private void HandleInfoButtonRelease (FButton button)
	{
		if (InitScript.inGame == false)
			InitScript.gotoInstructions();
	}
	private void playAnimation()
	{
		Futile.stage.RemoveChild(menuBackground);
		btnInstructions.isVisible = false;
		btnCredits.isVisible = false;
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
					menuAnims.SetElementByName("Menutoplay6.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("Menutoplay5.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("Menutoplay4.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("Menutoplay3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("Menutoplay2.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("Menutoplay1.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("Menutoplay0.png");
				else if (animationCounter == 7)
				{
					//menuAnims.isVisible = true;
					menuBackground.isVisible = true;
					btnInstructions.isVisible = true;
					btnCredits.isVisible = true;
					transitionIn = false;
				}
			}
		}
		if (playingTransition == false && transitionIn == false)
		{
			if (frameCount % 5 == 0)
			{
				animationCounter++;
				if (animationCounter >= 4)
					animationCounter = 0;
				
				if (animationCounter == 0)
					menuAnims.SetElementByName("MenuAnim0.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("MenuAnim1.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("MenuAnim2.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("MenuAnim3.png");
			}
		}
		else if (playingTransition == true)
		{
			if (frameCount % 3 == 0)
			{
				animationCounter++;
				if (animationCounter >= 8)
					animationCounter = 0;
				
				if (animationCounter == 0)
					menuAnims.SetElementByName("Menutoplay0.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("Menutoplay1.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("Menutoplay2.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("Menutoplay3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("Menutoplay4.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("Menutoplay5.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("Menutoplay6.png");
				else if (animationCounter == 7)
					InitScript.goToGame();
			}
		}
	}
}
