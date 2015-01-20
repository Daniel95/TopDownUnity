using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private delegate void MenuDelegate();
	private MenuDelegate menuFunction;

	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;

	public static int difficulty;

	public static bool gameFinished = false;
	

	// Use this for initialization
	void Start () {
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonHeight = screenHeight * 0.1f;
		buttonWidth = screenWidth * 0.3f;

		menuFunction = mainMenu;

		//eindscherm laten zien als uitgespeeld
		if(gameFinished == true)
		{
			menuFunction = afterScreen;
		}
	}

	void Update()
	{

	}

	void OnGUI()
	{
		menuFunction();
	}

	void mainMenu()
	{
		GUI.Box (new Rect (Screen.width/15-80/2, 120/2, 250, 200), "Welcome To Annihilator\r\n\r\nControls:\r\nMove: W,A,S,D\r\nShoot: Left Mouse Button\r\nChange Firerate: Right Mouse Button\r\n(The damage chances too!)\r\n\r\n\r\nPickups:\r\nMedicine: plus 2 Health\r\nBullet: double Firerate speed");
		GUI.Box (new Rect (Screen.width/15-80/2, 550, 150, 25), "Made By: Daniël Brand");
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.1f, buttonWidth, buttonHeight), "Start Annihilators"))
		{
			menuFunction = selectLevel1;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.3f, buttonWidth, buttonHeight), "Change Difficulty"))
		{
			menuFunction = selectDifficulty;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.5f, buttonWidth, buttonHeight), "Start Annihilator Ball"))
		{
			Application.LoadLevel("Tankball");
		}
		if(GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.7f, buttonWidth, buttonHeight), "Quit"))
		{
			Application.Quit();
		}
	}

	void selectDifficulty()
	{
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.3f, buttonWidth, buttonHeight), "Normal"))
		{
			difficulty = 0;
			menuFunction = selectLevel1;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.1f, buttonWidth, buttonHeight), "Easy"))
		{

			difficulty = 1;
			menuFunction = selectLevel1;
		}
		if(GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.5f, buttonWidth, buttonHeight), "Hard"))
		{
			difficulty = 2;
			menuFunction = selectLevel1;
		}
	}

	void selectLevel1()
	{
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.11f, buttonWidth, buttonHeight), "Level 1\r\nIntroduction"))
		{
			Application.LoadLevel("Level1");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.22f, buttonWidth, buttonHeight), "Level 2"))
		{
			Application.LoadLevel("Level2");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.33f, buttonWidth, buttonHeight), "Level 3"))
		{
			Application.LoadLevel("Level3");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.44f, buttonWidth, buttonHeight), "Level 4\r\nTime Limit"))
		{
			Application.LoadLevel("Level4");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.55f, buttonWidth, buttonHeight), "Level 5\r\nBoss"))
		{
			Application.LoadLevel("Level5");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.11f, buttonWidth, buttonHeight), "Level 6\r\nUpgrade"))
		{
			Application.LoadLevel("Level6");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.22f, buttonWidth, buttonHeight), "Level 7"))
		{
			Application.LoadLevel("Level7");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.33f, buttonWidth, buttonHeight), "Level 8"))
		{
			Application.LoadLevel("Level8");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.44f, buttonWidth, buttonHeight), "Level 9\r\nWaves"))
		{
			Application.LoadLevel("Level9");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.55f, buttonWidth, buttonHeight), "Level 10\r\nBoss"))
		{
			Application.LoadLevel("Level10");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.66f, buttonWidth, buttonHeight), "Menu"))
		{
			menuFunction = mainMenu;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.66f, buttonWidth, buttonHeight), "Next"))
		{
			menuFunction = selectLevel2;
		}
	}
	void selectLevel2()
	{
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.11f, buttonWidth, buttonHeight), "Level 11\r\nRace"))
		{
			Application.LoadLevel("Level11");
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.22f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.33f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.44f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.55f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.11f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.22f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.33f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.44f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.55f, buttonWidth, buttonHeight), "Work in progress"))
		{
			menuFunction = selectLevel2;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.25f, screenHeight * 0.66f, buttonWidth, buttonHeight), "Menu"))
		{
			menuFunction = mainMenu;
		}
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.7f, screenHeight * 0.66f, buttonWidth, buttonHeight), "Back"))
		{
			menuFunction = selectLevel1;
		}
	}
	void afterScreen()
	{
		GUI.Box (new Rect (Screen.width/4.25f, 120/2, 600, 200), "\r\nGefeliciteerd!\r\n\r\nU heeft 70 Rode Tanks Vernietigd, \r\ndie op een of andere mysterieuze reden op de maan zaten.\r\n\r\nJe hebt met geen enkele Rode Tank contact proberen te zoeken,\r\n het grote mysterie van deze tanks zal nu voor altijd verborgen blijven.\r\n\r\nMet geen weg om van deze planeet af te komen is er geen andere keuze behalve door rijden...\r\n Misschien kom je ooit nog meer Rode tanks tegen die je kan vernietigen...");
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.66f, buttonWidth, buttonHeight), "Menu"))
		{
			gameFinished = false;
			menuFunction = mainMenu;
		}
	}
}
