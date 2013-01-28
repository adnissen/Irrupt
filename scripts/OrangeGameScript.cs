using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrangeGameScript : FPage {

	// Use this for initialization
	private static int FrameCounter = 120;
	//public static bool inGame = false;
	public static Spaceman testPlayer;
	public static Turret turret;
	
	public static Lazer laserActual;
	public static LazerTurret laser;
	
	public static RocketTurret rocket;

	public static EnergyBar bar;
	public static List<Obstacle> obstacles;
	public static List<Bullet> bullets;
	public static List<Powerup> powerups;
	
	private static FSprite digit1, digit2, digit3;
	private static FSprite hsDigit1, hsDigit2, hsDigit3;
	private static int value1, value2, value3;
	
	public static float bonusSpeed = 2f;
	public static float spawnTime = 60f;
	
	private static int score = 0;
	
	private static Starfield background;
	private static Starfield background2;
	private FSprite walls;
	
	private int frameCount = 0;
	private int animationCounter = 0;
	
	private bool transitionOut = false;
	private static bool transitioningIn = false;
	//menu stuffs
	public static FSprite menuBackground;
	
	private FSprite victoryFlare;
	private static bool flaring = false;
	
	private FButton btnPause;
	
	private static bool paused = false;
	
	private FSprite pausedScreen;
	override public void Start () {
		InitScript.inGame = true;
		InitScript.totalScore = 0;
		bonusSpeed = 2f;
		score = 0;
		value1 = 0;
		value2 = 0;
		value3 = 0;
		FrameCounter = 120;
		obstacles = new List<Obstacle>();
		powerups = new List<Powerup>();
		bullets = new List<Bullet>();
		
		background = new Starfield(InitScript.bg1Pos,false);
		Futile.stage.AddChild(background);
		
		background2 = new Starfield(InitScript.bg2Pos, false);
		Futile.stage.AddChild(background2);	
		
		bar = new EnergyBar();
		Futile.stage.AddChild(bar);
		
		walls = new FSprite("AwesomeWall.png");
		walls.scale = 2.0f;
		walls.x = 0;
		Futile.stage.AddChild(walls);
		
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
		
		///////
		
		testPlayer = new Spaceman();
		Futile.stage.AddChild(testPlayer);
		testPlayer.PlayerAlive();
		
		victoryFlare = new FSprite("Victory0.png");
		victoryFlare.scale = 2.0f;
		victoryFlare.x = 159.7772f - 30;
		victoryFlare.y = -Futile.screen.halfHeight + 160;
		Futile.stage.AddChild(victoryFlare);
		
		btnPause = new FButton("PauseButton.png");
		btnPause.x = -159.7772f + 12;
		btnPause.y = Futile.screen.halfHeight - 12;
		btnPause.scale = 2.0f;
		//btnPause.isVisible = false;
		Futile.stage.AddChild(btnPause);
		
		turret = new Turret();
		Futile.stage.AddChild(turret);
		
		laser = new LazerTurret();
		Futile.stage.AddChild(laser);
		
		laserActual = new Lazer();
		Futile.stage.AddChild(laserActual);
		
		rocket = new RocketTurret();
		Futile.stage.AddChild(rocket);
		
		pausedScreen = new FSprite("Paused0.png");
		pausedScreen.scale = 2.0f;
		pausedScreen.isVisible = false;
		Futile.stage.AddChild(pausedScreen);
		
		InitScript.blackBar1.MoveToTop();
		InitScript.blackBar2.MoveToTop();
		
		btnPause.SignalRelease += HandlePauseButtonRelease;
		Futile.instance.SignalUpdate += HandleUpdate;
	}
	private void HandlePauseButtonRelease (FButton button)
	{
		if (paused == false)
		{
			paused = true;
			pausedScreen.isVisible = true;
		}
		else 
			paused = false;
	}
	public static void setStarfieldSpeed(float newspeed)
	{
		background.setSpeed(newspeed);
		background2.setSpeed(newspeed);
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
	public void Destroy()
	{
		Futile.stage.RemoveChild(background);
		Futile.stage.RemoveChild(background2);
		Futile.stage.RemoveChild(digit1);
		Futile.stage.RemoveChild(digit2);
		Futile.stage.RemoveChild(digit3);
		Futile.stage.RemoveChild(bar);
		Futile.stage.RemoveChild(victoryFlare);
		Futile.stage.RemoveChild(pausedScreen);
		for (int i = 0; i < Futile.stage.GetChildCount(); i++) {
			Futile.stage.RemoveChild(Futile.stage.GetChildAt(i));
		}
	}
	public static void endGame()
	{
		transitioningIn = true;
	}
	
	// Update is called once per frame
	protected void HandleUpdate () {
		frameCount++;
		if (paused == false)
		{
			if (InitScript.inGame == true)
			{
				//all the score indicator stuff
				
				//adjusting the score stuff
				
				
				if (bonusSpeed > 1.5f)
				{
					spawnTime = 60;
				}
				
				if (bonusSpeed > 5f)
				{
					spawnTime = 30;
				}
				
				if (bonusSpeed > 3f)
				{
					spawnTime = 45;	
				}
				
				FrameCounter++;
				if (FrameCounter % spawnTime == 0)
					Futile.stage.AddChild(new Obstacle());
				if (FrameCounter % 600 == 0)
					Futile.stage.AddChild(new Powerup());
				
				for (int i = obstacles.Count -1 ; i > 0; i--) {
					obstacles[i].Update();	
				}
				
				for (int i = powerups.Count -1 ; i > 0; i--) {
					powerups[i].Update();	
				}
				if (flaring == true)
				{
					if (frameCount % 7 == 0)
					{
						animationCounter++;	
					
						if (animationCounter == 0)
							victoryFlare.SetElementByName("Victory0.png");
						else if (animationCounter == 1)
							victoryFlare.SetElementByName("Victory1.png");
						else if (animationCounter == 2)
						{
							animationCounter = 0;
							flaring = false;
							victoryFlare.SetElementByName("Victory2.png");
						}
					}
				}
				background.Update();
				InitScript.bg1Pos = background.x;
				background2.Update();
				InitScript.bg2Pos = background2.x;
				bar.Update();
				turret.Update();
				rocket.Update();
				laser.Update();
				laserActual.Update();
				testPlayer.Update();
			}
			else if (InitScript.inGame == false)
			{
				for (int i = powerups.Count -1 ; i > 0; i--) {
					powerups[i].isVisible = false;	
				}
				for (int i = bullets.Count -1 ; i > 0; i--) {
					bullets[i].isVisible = false;	
				}
				laserActual.isVisible = false;
				
				testPlayer.Update();
				Futile.stage.RemoveChild(turret);
				Futile.stage.RemoveChild(rocket);
				Futile.stage.RemoveChild(laser);
				InitScript.oldD1 = value1;
				InitScript.oldD2 = value2;
				InitScript.oldD3 = value3;
				if (InitScript.totalScore > InitScript.highScore)
				{
					InitScript.highScore = InitScript.totalScore;
					InitScript.hsD1 = value1;
					InitScript.hsD2 = value2;
					InitScript.hsD3 = value3;
					PlayerPrefs.SetInt("highscore",InitScript.highScore);
					PlayerPrefs.SetInt("Digit1", InitScript.hsD1);
					PlayerPrefs.SetInt("Digit2", InitScript.hsD2);
					PlayerPrefs.SetInt("Digit3", InitScript.hsD3);
					//PlayerPrefs.Save();
				}
				//again unity owns this game-center stuff
				//it even checks it for you so I don't even need to do that
				Social.ReportScore(InitScript.totalScore, "Irruptleaderboard1", reportCallback);	
				for (int i = obstacles.Count -1 ; i > 0; i--) {
					obstacles[i].Update();
				}
				for (int i = obstacles.Count -1 ; i > 0; i--) {
					obstacles[i].Kill();	
				}
				InitScript.gotoGameOver();
			}
		}
		else
		{
			//super cool pause screen
			pausedScreen.MoveToTop();
			if (frameCount % 5 == 0)
			{
				animationCounter++;
				
				if (animationCounter >= 5)
				{
					animationCounter = 3;
				}
				
				if (animationCounter == 0)
					pausedScreen.SetElementByName("Paused0.png");
				else if (animationCounter == 1)
					pausedScreen.SetElementByName("Paused1.png");
				else if (animationCounter == 2)
					pausedScreen.SetElementByName("Paused2.png");
				else if (animationCounter == 3)
					pausedScreen.SetElementByName("Paused3.png");
				else if (animationCounter == 4)
					pausedScreen.SetElementByName("Paused4.png");
			}
			if (Input.GetMouseButton(0))
			{
				paused = false;	
				pausedScreen.isVisible = false;
				animationCounter = 0;
			}
		}
	}
	
	public static void increaseScore(int amount)
	{
		//I was too lazy to actually figure out to make a font with folmers custom numbers
		//so instead I opeted to just write the whole system myself. yay 
		flaring = true;
		score += amount;
		InitScript.totalScore += amount;
		if (score == 0)
			value1 = 0;
		else if (score == 1)
			value1 = 1;
		else if (score == 2)
			value1 = 2;
		else if (score == 3)
			value1 = 3;
		else if (score == 4)
			value1 = 4;
		else if (score == 5)
			value1 = 5;
		else if (score == 6)
			value1 = 6;
		else if (score == 7)
			value1 = 7;
		else if (score == 8)
			value1 = 8;
		else if (score == 9)
			value1 = 9;
		else if (score == 10)
		{
			value2++;
			if (value2 >= 10)
			{
				value2 = 0;
				value3++;
			}
			score = 0;
			value1 = 0;
		}
			
			
			
			//the rightmost number
		if (value1 == 0)
			digit1.SetElementByName("0.png");
		else if (value1 == 1)
			digit1.SetElementByName("1.png");
		else if (value1 == 2)
			digit1.SetElementByName("2.png");
		else if (value1 == 3)
			digit1.SetElementByName("3.png");
		else if (value1 == 4)
			digit1.SetElementByName("4.png");
		else if (value1 == 5)
			digit1.SetElementByName("5.png");
		else if (value1 == 6)
			digit1.SetElementByName("6.png");
		else if (value1 == 7)
			digit1.SetElementByName("7.png");
		else if (value1 == 8)
			digit1.SetElementByName("8.png");
		else if (value1 == 9)
			digit1.SetElementByName("9.png");
			
			//the second value
		if (value2 == 0)
			digit2.SetElementByName("0.png");
		else if (value2 == 1)
			digit2.SetElementByName("1.png");
		else if (value2 == 2)
			digit2.SetElementByName("2.png");
		else if (value2 == 3)
			digit2.SetElementByName("3.png");
		else if (value2 == 4)
			digit2.SetElementByName("4.png");
		else if (value2 == 5)
			digit2.SetElementByName("5.png");
		else if (value2 == 6)
			digit2.SetElementByName("6.png");
		else if (value2 == 7)
			digit2.SetElementByName("7.png");
		else if (value2 == 8)
			digit2.SetElementByName("8.png");
		else if (value2 == 9)
			digit2.SetElementByName("9.png");
			
			//the third digit
		if (value3 == 0)
			digit3.SetElementByName("0.png");
		else if (value3 == 1)
			digit3.SetElementByName("1.png");
		else if (value3 == 2)
			digit3.SetElementByName("2.png");
		else if (value3 == 3)
			digit3.SetElementByName("3.png");
		else if (value3 == 4)
			digit3.SetElementByName("4.png");
		else if (value3 == 5)
			digit3.SetElementByName("5.png");
		else if (value3 == 6)
			digit3.SetElementByName("6.png");
		else if (value3 == 7)
			digit3.SetElementByName("7.png");
		else if (value3 == 8)
			digit3.SetElementByName("8.png");
		else if (value3 == 9)
			digit3.SetElementByName("9.png");
	}
	
	private void reportCallback(bool success)
	{
		
	}
	
	public static void displayScore()
	{
		Debug.Log(score.ToString());
	}
}
