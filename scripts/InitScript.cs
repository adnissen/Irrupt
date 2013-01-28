using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	// Use this for initialization
	// I basically use this as a Registry class, putting global game stuff in here
	public static InitScript instance;
	
	private static FPage _currentPage = null;

	private static FStage _stage;
	public static bool inGame = false;
	public static float bg1Pos = 0f;
	public static float bg2Pos = 400f;
	public static int totalScore;
	public static int hsD1, hsD2, hsD3;
	public static int oldD1, oldD2, oldD3;
	public static int highScore;
	public static FSprite blackBar1;
	public static FSprite blackBar2;
	public static bool isAuthed;
	public static bool shouldPlayMenuTransition = true;
	void Start () {
		instance = this;
		
		Go.defaultEaseType = EaseType.Linear;
		Go.duplicatePropertyRule = DuplicatePropertyRuleType.RemoveRunningProperty;
		
		bool isIPad = SystemInfo.deviceModel.Contains("iPad");
		
		FutileParams fparams = new FutileParams(false, false, true, false);
		
		fparams.AddResolutionLevel(480.0f, 1.0f, 1.0f,"");
		
		fparams.origin = new Vector2(0.5f, 0.5f);
		
		fparams.targetFrameRate = 60;
		Application.targetFrameRate = 60;
		
		Futile.instance.Init(fparams);
		
		Futile.atlasManager.LoadAtlas("Atlases/Sprites");
		
		FTouchManager.shouldMouseEmulateTouch = true;	
		
		_stage = Futile.stage;
		
		//I have to say, unity makes it mad easy to store stuff like highscores on the device
		highScore = PlayerPrefs.GetInt("highscore", 0);
		hsD1 = PlayerPrefs.GetInt("Digit1",0);
		hsD2 = PlayerPrefs.GetInt("Digit2",0);
		hsD3 = PlayerPrefs.GetInt("Digit3",0);
		
		//the black bars are added to the ipad version only, since it's pixel art
		//it doesn't scale in odd resolutions, so I just made the screen a better resolution essentially

		//it's a pretty horrible hack, but this is the only way I could really think to do it
		blackBar1 = new FSprite("blackbar.png");
		if (isIPad == false)
			blackBar1.SetElementByName("0.png");
		blackBar1.x = -320;
		blackBar1.scale = 2.0f;
		Futile.stage.AddChild(blackBar1);
		blackBar2 = new FSprite("blackbar.png");
		if (isIPad == false)
			blackBar2.SetElementByName("0.png");
		blackBar2.x = 320;
		blackBar2.scale = 2.0f;
		Futile.stage.AddChild(blackBar2);
		
		HandleResize();
		ISoundManager.Start();
		ISoundManager.PlayMusic();
		
		//gamecenter stuff that unity reduces to like 3 lines
		//very cool
		Social.localUser.Authenticate(authCallback);
		
		gotoMenu();
	}
	
	private void authCallback(bool result)
	{
		isAuthed = result;
	}
	
	//so I use all these different methods as a sort of state manager, basically like FlxG.switchstate in flixel
	//a lot of this is probably redudant, but I was trying to make sure that it was performing as well as physically possible
	public static void gotoInstructions()
	{
		ISoundManager.PlayTransitions();
		Futile.stage.RemoveChild(blackBar1);
		Futile.stage.RemoveChild(blackBar2);
		if(_currentPage != null)
		{
			_stage.RemoveChild(_currentPage);
		}
		_currentPage = new InstructionsPage();
		_stage.AddChild(_currentPage);
		_currentPage.Start();
		Futile.stage.AddChild(blackBar1);
		Futile.stage.AddChild(blackBar2);
		blackBar1.MoveToTop();
		blackBar2.MoveToTop();
	}
	public static void gotoCredits()
	{
		ISoundManager.PlayTransitions();
		Futile.stage.RemoveChild(blackBar1);
		Futile.stage.RemoveChild(blackBar2);
		if(_currentPage != null)
		{
			_stage.RemoveChild(_currentPage);
		}
		_currentPage = new CreditsPage();
		_stage.AddChild(_currentPage);
		_currentPage.Start();
		Futile.stage.AddChild(blackBar1);
		Futile.stage.AddChild(blackBar2);
		blackBar1.MoveToTop();
		blackBar2.MoveToTop();
	}
	public static void gotoGameOver()
	{
		ISoundManager.PlayMenuTransitions();
		Futile.stage.RemoveChild(blackBar1);
		Futile.stage.RemoveChild(blackBar2);
		if(_currentPage != null)
		{
			_stage.RemoveChild(_currentPage);
		}
		_currentPage = new GameOverPage();
		_stage.AddChild(_currentPage);
		_currentPage.Start();
		Futile.stage.AddChild(blackBar1);
		Futile.stage.AddChild(blackBar2);
		blackBar1.MoveToTop();
		blackBar2.MoveToTop();
	}
	public static void gotoMenu()
	{
		ISoundManager.PlayMenuTransitions();
		Futile.stage.RemoveChild(blackBar1);
		Futile.stage.RemoveChild(blackBar2);
		if(_currentPage != null)
		{
			_stage.RemoveChild(_currentPage);
		}
		_currentPage = new MenuPage();;
		_stage.AddChild(_currentPage);
		_currentPage.Start();
		Futile.stage.AddChild(blackBar1);
		Futile.stage.AddChild(blackBar2);
		blackBar1.MoveToTop();
		blackBar2.MoveToTop();
	}
	public static void goToGame()
	{
		ISoundManager.PlayMenuTransitions();
		Futile.stage.RemoveChild(blackBar1);
		Futile.stage.RemoveChild(blackBar2);
		inGame = true;
		if(_currentPage != null)
		{
			_stage.RemoveChild(_currentPage);
		}
		_currentPage = new OrangeGameScript();
		_stage.AddChild(_currentPage);
		_currentPage.Start();
		Futile.stage.AddChild(blackBar1);
		Futile.stage.AddChild(blackBar2);
		blackBar1.MoveToTop();
		blackBar2.MoveToTop();
		
	}

	//this bit of code was written by Matt Rix on /r/futile, but I put it into a method to make it more flixel-like
	public static bool CollidePlayer(FSprite obj1, Spaceman obj2)
	{
		Rect Obj1Rect = obj1.textureRect.CloneAndMultiply(obj1.scale).CloneAndOffset(obj1.x, obj1.y);
		Rect Obj2Rect = obj2.getRect().CloneAndMultiply(obj2.scale).CloneAndOffset(obj2.x, obj2.y);
		if (Obj1Rect.CheckIntersect(Obj2Rect) == true)
		{
			return true;
		}
		else {
			return false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
