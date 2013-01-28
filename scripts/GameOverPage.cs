using UnityEngine;
using System.Collections;

public class GameOverPage : FPage {
	
	private static Starfield background;
	private static Starfield background2;
	public FSprite menuBackground;
	
	public static FSprite menuAnims;
	
	private FButton btnInstructions;
	private FButton btnGameCenter;
	
	private bool playingTransition = false;
	private bool playReverse = false;
	private bool transitionIn = false;
	
	private int frameCount = 0;
	private int animationCounter = 0;
	
	private FSprite digit1, digit2, digit3;
	private FSprite hsDigit1, hsDigit2, hsDigit3;
	private int value1, value2, value3;
	
	private FSprite flash;
	
	private bool goingtoMenu = false;
	
	private static FButton btnPlay;
	
	// Use this for initialization
	override public void Start () {
		transitionIn = true;
		InitScript.inGame = false;
		background = new Starfield(0,false);
		Futile.stage.AddChild(background);
		
		background2 = new Starfield(320 + 80, false);
		Futile.stage.AddChild(background2);	
		
		menuBackground = new FSprite("MenuStatic.png");
		menuBackground.scale = 2.0f;
		menuBackground.x = 0;
		menuBackground.isVisible = false;
		Futile.stage.AddChild(menuBackground);
		
		menuAnims = new FSprite("Menutoplay6.png");
		menuAnims.scale = 2.0f;
		menuAnims.x = 0;
		Futile.stage.AddChild(menuAnims);
		
		btnInstructions = new FButton("MenuButton.png");
		btnInstructions.x -= 1;
		btnInstructions.y -= 126;
		btnInstructions.scale = 2.0f;
		btnInstructions.isVisible = false;
		Futile.stage.AddChild(btnInstructions);
		
		btnGameCenter = new FButton("GCButton.png");
		btnGameCenter.x -= 1;
		btnGameCenter.y -= 166;
		btnGameCenter.scale = 2.0f;
		btnGameCenter.isVisible = false;
		Futile.stage.AddChild(btnGameCenter);
		
		//score stuffffff
		digit1 = new FSprite("0.png");
		digit1.scale = 2.0f;
		digit1.x = -159.7772f + 180;
		digit1.y = Futile.screen.halfHeight - 57;
		Futile.stage.AddChild(digit1);
		
		digit2 = new FSprite("0.png");
		digit2.scale = 2.0f;
		digit2.x = -159.7772f + 160;
		digit2.y = Futile.screen.halfHeight - 57;
		Futile.stage.AddChild(digit2);
		
		digit3 = new FSprite("0.png");
		digit3.scale = 2.0f;
		digit3.x = -159.7772f + 140;
		digit3.y = Futile.screen.halfHeight - 57;
		Futile.stage.AddChild(digit3);
		
		hsDigit1 = new FSprite("0.png");
		hsDigit1.scale = 2.0f;
		hsDigit1.x = -159.7772f + 180;
		hsDigit1.y = Futile.screen.halfHeight - 123;
		hsDigit1.isVisible = false;
		Futile.stage.AddChild(hsDigit1);
		
		hsDigit2 = new FSprite("0.png");
		hsDigit2.scale = 2.0f;
		hsDigit2.x = -159.7772f + 160;
		hsDigit2.y = Futile.screen.halfHeight - 123;
		hsDigit2.isVisible = false;
		Futile.stage.AddChild(hsDigit2);
		
		hsDigit3 = new FSprite("0.png");
		hsDigit3.scale = 2.0f;
		hsDigit3.x = -159.7772f + 140;
		hsDigit3.y = Futile.screen.halfHeight - 123;
		hsDigit3.isVisible = false;
		Futile.stage.AddChild(hsDigit3);
		
		flash = new FSprite("GameOverAnim0.png");
		flash.scale = 2.0f;
		flash.x = 0;
		flash.isVisible = false;
		Futile.stage.AddChild(flash);
		
		btnPlay = new FButton("PlayButton.png");
		btnPlay.x = 0;
		btnPlay.y = 0;
		btnPlay.scale = 2.0f;
		Futile.stage.AddChild(btnPlay);
		
		btnInstructions.SignalRelease += HandleInfoButtonRelease;
		btnGameCenter.SignalRelease += HandleGCButtonRelease;
		btnPlay.SignalRelease += HandlePlayButtonRelease;
		
		Futile.instance.SignalUpdate += HandleUpdate;
		
		//score things
		if (InitScript.hsD1 == 0)
			hsDigit1.SetElementByName("0.png");
		else if (InitScript.hsD1 == 1)
			hsDigit1.SetElementByName("1.png");
		else if (InitScript.hsD1 == 2)
			hsDigit1.SetElementByName("2.png");
		else if (InitScript.hsD1 == 3)
			hsDigit1.SetElementByName("3.png");
		else if (InitScript.hsD1 == 4)
			hsDigit1.SetElementByName("4.png");
		else if (InitScript.hsD1 == 5)
			hsDigit1.SetElementByName("5.png");
		else if (InitScript.hsD1 == 6)
			hsDigit1.SetElementByName("6.png");
		else if (InitScript.hsD1 == 7)
			hsDigit1.SetElementByName("7.png");
		else if (InitScript.hsD1 == 8)
			hsDigit1.SetElementByName("8.png");
		else if (InitScript.hsD1 == 9)
			hsDigit1.SetElementByName("9.png");
		
					//the second value
		if (InitScript.hsD2 == 0)
			hsDigit2.SetElementByName("0.png");
		else if (InitScript.hsD2 == 1)
			hsDigit2.SetElementByName("1.png");
		else if (InitScript.hsD2 == 2)
			hsDigit2.SetElementByName("2.png");
		else if (InitScript.hsD2 == 3)
			hsDigit2.SetElementByName("3.png");
		else if (InitScript.hsD2 == 4)
			hsDigit2.SetElementByName("4.png");
		else if (InitScript.hsD2 == 5)
			hsDigit2.SetElementByName("5.png");
		else if (InitScript.hsD2 == 6)
			hsDigit2.SetElementByName("6.png");
		else if (InitScript.hsD2 == 7)
			hsDigit2.SetElementByName("7.png");
		else if (InitScript.hsD2 == 8)
			hsDigit2.SetElementByName("8.png");
		else if (InitScript.hsD2 == 9)
			hsDigit2.SetElementByName("9.png");
					
		//the third digit
		if (InitScript.hsD3 == 0)
			hsDigit3.SetElementByName("0.png");
		else if (InitScript.hsD3 == 1)
			hsDigit3.SetElementByName("1.png");
		else if (InitScript.hsD3 == 2)
			hsDigit3.SetElementByName("2.png");
		else if (InitScript.hsD3 == 3)
			hsDigit3.SetElementByName("3.png");
		else if (InitScript.hsD3 == 4)
			hsDigit3.SetElementByName("4.png");
		else if (InitScript.hsD3 == 5)
			hsDigit3.SetElementByName("5.png");
		else if (InitScript.hsD3 == 6)
			hsDigit3.SetElementByName("6.png");
		else if (InitScript.hsD3 == 7)
			hsDigit3.SetElementByName("7.png");
		else if (InitScript.hsD3 == 8)
			hsDigit3.SetElementByName("8.png");
		else if (InitScript.hsD3 == 9)
			hsDigit3.SetElementByName("9.png");
		
		//non highscores
		if (InitScript.oldD1 == 0)
			digit1.SetElementByName("0.png");
		else if (InitScript.oldD1 == 1)
			digit1.SetElementByName("1.png");
		else if (InitScript.oldD1 == 2)
			digit1.SetElementByName("2.png");
		else if (InitScript.oldD1 == 3)
			digit1.SetElementByName("3.png");
		else if (InitScript.oldD1 == 4)
			digit1.SetElementByName("4.png");
		else if (InitScript.oldD1 == 5)
			digit1.SetElementByName("5.png");
		else if (InitScript.oldD1 == 6)
			digit1.SetElementByName("6.png");
		else if (InitScript.oldD1 == 7)
			digit1.SetElementByName("7.png");
		else if (InitScript.oldD1 == 8)
			digit1.SetElementByName("8.png");
		else if (InitScript.oldD1 == 9)
			digit1.SetElementByName("9.png");
		
		if (InitScript.oldD2 == 0)
			digit2.SetElementByName("0.png");
		else if (InitScript.oldD2 == 1)
			digit2.SetElementByName("1.png");
		else if (InitScript.oldD2 == 2)
			digit2.SetElementByName("2.png");
		else if (InitScript.oldD2 == 3)
			digit2.SetElementByName("3.png");
		else if (InitScript.oldD2 == 4)
			digit2.SetElementByName("4.png");
		else if (InitScript.oldD2 == 5)
			digit2.SetElementByName("5.png");
		else if (InitScript.oldD2 == 6)
			digit2.SetElementByName("6.png");
		else if (InitScript.oldD2 == 7)
			digit2.SetElementByName("7.png");
		else if (InitScript.oldD2 == 8)
			digit2.SetElementByName("8.png");
		else if (InitScript.oldD2 == 9)
			digit2.SetElementByName("9.png");
		
		if (InitScript.oldD3 == 0)
			digit3.SetElementByName("0.png");
		else if (InitScript.oldD3 == 1)
			digit3.SetElementByName("1.png");
		else if (InitScript.oldD3 == 2)
			digit3.SetElementByName("2.png");
		else if (InitScript.oldD3 == 3)
			digit3.SetElementByName("3.png");
		else if (InitScript.oldD3 == 4)
			digit3.SetElementByName("4.png");
		else if (InitScript.oldD3 == 5)
			digit3.SetElementByName("5.png");
		else if (InitScript.oldD3 == 6)
			digit3.SetElementByName("6.png");
		else if (InitScript.oldD3 == 7)
			digit3.SetElementByName("7.png");
		else if (InitScript.oldD3 == 8)
			digit3.SetElementByName("8.png");
		else if (InitScript.oldD3 == 9)
			digit3.SetElementByName("9.png");
		
		InitScript.blackBar1.MoveToTop();
		InitScript.blackBar2.MoveToTop();
	}
	override public void HandleAddedToStage()
	{
		base.HandleAddedToStage();
	}
	private void HandlePlayButtonRelease(FButton button)
	{
		if (InitScript.inGame == false)
			playAnimation();
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
	private void HandleInfoButtonRelease (FButton button)
	{
		if (InitScript.inGame == false)
		{
			Social.ShowLeaderboardUI();
		}
	}
	// Update is called once per frame
	private void HandleGCButtonRelease (FButton button)
	{
		if (InitScript.inGame == false)
		{
			goingtoMenu = true;
			InitScript.shouldPlayMenuTransition = true;
			playMenuAnim();
		}
	}
	private void playMenuAnim()
	{
		Futile.stage.RemoveChild(menuBackground);
		btnInstructions.isVisible = false;
		playingTransition = true; 
		Futile.stage.RemoveChild(flash);
		Futile.stage.RemoveChild(digit1);
		Futile.stage.RemoveChild(digit2);
		Futile.stage.RemoveChild(digit3);
		Futile.stage.RemoveChild(hsDigit1);
		Futile.stage.RemoveChild(hsDigit2);
		Futile.stage.RemoveChild(hsDigit3);
	}
	private void playAnimation()
	{
		Futile.stage.RemoveChild(menuBackground);
		btnInstructions.isVisible = false;
		playingTransition = true; 
		Futile.stage.RemoveChild(flash);
		Futile.stage.RemoveChild(digit1);
		Futile.stage.RemoveChild(digit2);
		Futile.stage.RemoveChild(digit3);
		Futile.stage.RemoveChild(hsDigit1);
		Futile.stage.RemoveChild(hsDigit2);
		Futile.stage.RemoveChild(hsDigit3);
		
	}
	protected void HandleUpdate () {
		background.Update();
		InitScript.bg1Pos = background.x;
		background2.Update();
		InitScript.bg2Pos = background2.x;
		frameCount++;
		if (transitionIn == true)
		{
			if (frameCount % 3 == 0)
			{
				animationCounter++;
				if (animationCounter == 0)
					menuAnims.SetElementByName("GametoGameover0.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("GametoGameover1.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("GametoGameover2.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("GametoGameover3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("GametoGameover4.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("GametoGameover5.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("GametoGameover6.png");
				else if (animationCounter == 7)
				{
					//menuAnims.isVisible = true;
					transitionIn = false;
					menuAnims.SetElementByName("GameOverStatic.png");
					flash.isVisible = true;
					hsDigit1.isVisible = true;
					hsDigit2.isVisible = true;
					hsDigit3.isVisible = true;
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
					flash.SetElementByName("GameOverAnim0.png");
				else if (animationCounter == 1)
					flash.SetElementByName("GameOverAnim1.png");
				else if (animationCounter == 2)
					flash.SetElementByName("GameOverAnim2.png");
				else if (animationCounter == 3)
					flash.SetElementByName("GameOverAnim3.png");
			}
		}
		else if (playingTransition == true)
		{
			if (frameCount % 3 == 0)
			{
				animationCounter++;
				if (animationCounter == 0)
					menuAnims.SetElementByName("GametoGameover6.png");
				else if (animationCounter == 1)
					menuAnims.SetElementByName("GametoGameover5.png");
				else if (animationCounter == 2)
					menuAnims.SetElementByName("GametoGameover4.png");
				else if (animationCounter == 3)
					menuAnims.SetElementByName("GametoGameover3.png");
				else if (animationCounter == 4)
					menuAnims.SetElementByName("GametoGameover2.png");
				else if (animationCounter == 5)
					menuAnims.SetElementByName("GametoGameover1.png");
				else if (animationCounter == 6)
					menuAnims.SetElementByName("GametoGameover0.png");
				else if (animationCounter == 7)
				{
					if (goingtoMenu == true)
						InitScript.gotoMenu();
					else
						InitScript.goToGame();
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
