using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	private delegate void MenuDelegate();
	private MenuDelegate gameFunction;
	
	private float health;
	private float bossHealth;

	public static int enemies;

	private float offsetY = 40;
	private float sizeX = 80;
	private float sizeY = 25;

	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
		gameFunction = backToMenu;
	}
	
	// Update is called once per frame
	void Update () {
		health = Die.playerLives;
		enemies = Die.enemiesLeft;
		bossHealth = Die.bossHealth;
	}

	void OnGUI(){
		gameFunction();
		GUI.Box (new Rect (Screen.width/15-sizeX/2, offsetY/2, sizeX, sizeY), "Health: "+health);
		GUI.Box (new Rect (Screen.width/6-sizeX/1.9f, offsetY/2, sizeX+3, sizeY), "Enemies: "+enemies);
		if (GameObject.Find("Enemy Boss Annihilator") != null)
		{
			GUI.Box (new Rect (Screen.width / 15 + 190, offsetY/2, 105, 25), "Boss Health: " + bossHealth);
		}
	}

	void backToMenu()
	{
		if (GUI.Button (new Rect (Screen.width/1.05f-sizeX/1.5f, offsetY/2, sizeX, sizeY), "Menu")) 
		{
			Die.bossHealth = 0;
			Application.LoadLevel("Menu");
		}
	}
}