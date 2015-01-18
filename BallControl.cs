using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	private delegate void MenuDelegate();
	private MenuDelegate gameBallFunction;

	private int scorePlayer1 = 0;
	private int scorePlayer2 = 0;
	
	// Use this for initialization
	void Start () {
		gameBallFunction = backToMenu;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		gameBallFunction();
		GUI.Box (new Rect (Screen.width/15-80/2, 40/2, 70, 40), "Green: "+scorePlayer1+"\r\nRed: "+scorePlayer2);
	}
 
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Goal1")
		{
			scorePlayer2++;
			//Application.LoadLevel(Application.loadedLevelName);
		}
		if (col.gameObject.name == "Goal2")
		{
			scorePlayer1++;
			//Application.LoadLevel(Application.loadedLevelName);
		}
		if (scorePlayer2 >= 3 || scorePlayer1 >= 3) {
			scorePlayer1 = 0;
			scorePlayer2 = 0;
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
	void backToMenu()
	{
		if (GUI.Button (new Rect (Screen.width/1.05f-80/1.5f, 40/2, 70, 40), "Menu")) 
		{
			Application.LoadLevel("Menu");
		}
	}

}