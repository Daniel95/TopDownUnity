using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {
	public GameObject explosionPrefab;
	public static float playerLives;
	private float enemyLives = 5;
	private float objectLives = 2;
	private float damage;
	private float plusHealthPickup;

	//bomb damage cooldown
	private bool explosionHit;
	private float bombDamageTimer;

	//wordt naar UI gestuurd
	public static int enemiesLeft;
	public static float bossHealth;//wordt naar UI gestuurd
	private float damageControl;

	//private int bossesCount;

	// Use this for initialization
	void Start () {
		//starting lives:
		enemiesLeft = UI.enemies;
		if (GameObject.Find("Player Big Tank") != null)
		{
			damage = 4;
		}
		if (gameObject.name == "Enemy Boss Big") 
		{
			if (Menu.difficulty == 0)//normal
			{
				enemyLives = 35f;
			}
			if (Menu.difficulty == 1)//easy
			{
				enemyLives = 25f;
			}
			if (Menu.difficulty == 2)//hard
			{
				enemyLives = 45f;
			}
		}
		if (gameObject.name == "Enemy Boss Annihilator") 
		{
			if (Menu.difficulty == 0)//normal
			{
				enemyLives = 36f;
			}
			if (Menu.difficulty == 1)//easy
			{
				enemyLives = 28f;
			}
			if (Menu.difficulty == 2)//hard
			{
				enemyLives = 48f;
			}
			bossHealth += enemyLives;
		}
		if (gameObject.name == "Enemy Big" || gameObject.name == "Big Explode Enemy") 
		{
			if (Menu.difficulty == 0)//normal
			{
				enemyLives = 12f;
			}
			if (Menu.difficulty == 1)//easy
			{
				enemyLives = 9f;
			}
			if (Menu.difficulty == 2)//hard
			{
				enemyLives = 15f;
			}
		}
		if (gameObject.name == "Enemy Shotgun" || gameObject.name == "Enemy Sniper") 
		{
			if (Menu.difficulty == 0)//normal
			{
				enemyLives = 3f;
			}
			if (Menu.difficulty == 1)//easy
			{
				enemyLives = 1f;
			}
			if (Menu.difficulty == 2)//hard
			{
				enemyLives = 5f;
			}
		}
		if (gameObject.name == "Enemy") 
		{
			if (Menu.difficulty == 0)//normal
			{
				enemyLives = 5f;
			}
			if (Menu.difficulty == 1)//easy
			{
				enemyLives = 3f;
			}
			if (Menu.difficulty == 2)//hard
			{
				enemyLives = 7f;
			}
		}
		if (gameObject.name == "Player Tank") 
		{
			damage += 2;
			if (Menu.difficulty == 0)//normal
			{
				playerLives = 6f;
			}
			if (Menu.difficulty == 1)//easy
			{
				playerLives = 10f;
			}
			if (Menu.difficulty == 2)//hard
			{
				playerLives = 4f;
			}
		}
		if (gameObject.name == "Player Race Tank") 
		{
			playerLives = 3;
		}
		if (gameObject.name == "Player Big Tank") 
		{
			damage = 4;
			if (Menu.difficulty == 0)//normal
			{
				playerLives = 10f;
			}
			if (Menu.difficulty == 1)//easy
			{
				playerLives = 14f;
			}
			if (Menu.difficulty == 2)//hard
			{
				playerLives = 6f;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.name == "Player Tank" || gameObject.name == "Player Race Tank")
		{
			damage = PlayerControl.fireMode;
		}
		if (explosionHit == true) 
		{
			bombDamageTimer--;
			if (bombDamageTimer < Time.deltaTime)
			{
				explosionHit = false;
			}
		}
	}

	//boss health indicator:
	void OnGUI(){
		if (gameObject.name == "Enemy Boss Big") 
		{
			GUI.Box (new Rect (Screen.width / 15 + 170, 40 / 2, 105, 25), "Boss Health: " + enemyLives);
		}
	}
	//alle collisions: (geen trigger)
	void OnCollisionEnter(Collision col)
	{
		//enemies/woodwall raken en verwijderen:
		if(col.gameObject.tag == "Player Bullet")
		{
			if(gameObject.tag == "Enemy")
			{
				if (GameObject.Find("Player Tank") != null || GameObject.Find("Player Race Tank"))
				{
					damage = PlayerControl.fireMode;
				}
				enemyLives -= damage;
				if(enemyLives <= 0)
				{
					enemiesLeft--;
					Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
					Destroy(this.gameObject);
				}
				if (gameObject.name == "Enemy Boss Annihilator") 
				{
					bossHealth -= damage;
				}
			}
			if(gameObject.name == "WoodWall")
			{
				objectLives--;
				if(objectLives <= 0)
				{
					Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
					Destroy(this.gameObject);
				}
			}
		}
		//player/woodwall raken en level restarten:
		if (col.gameObject.tag == "Enemy Bullet") 
		{
			if(gameObject.tag == "Player")
			{
				playerLives--;
				if(playerLives <= 0)
				{
					bossHealth = 0;
					Application.LoadLevel(Application.loadedLevelName);
				}
			}
			if(gameObject.name == "WoodWall")
			{
				objectLives--;
				if(objectLives <= 0)
				{
					Destroy(this.gameObject);
				}
			}
		}
		//woodwall verwijderen als je er tegen aan rijdt:
		if(col.gameObject.tag == "Player")
		{
			if(gameObject.name == "WoodWall"){
				Destroy(this.gameObject);
			}
		}
		if (col.gameObject.name == "Player Big Tank") 
		{
			if(gameObject.name == "Enemy" || gameObject.name == "Enemy Sniper" || gameObject.name == "Enemy Shotgun" ){
				enemiesLeft--;
				Destroy(this.gameObject);
			}
		}
		//Doodgaan bij Boss collision
		if (col.gameObject.name == "Enemy Boss Annihilator") 
		{
			if(gameObject.name == "Player Big Tank"){
				bossHealth = 0;
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
		if (col.gameObject.name == "Enemy Boss Big") 
		{
			if(gameObject.name == "Player Tank"){
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
	}
	//Trigger collision
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Health Pickup")
		{
			if(gameObject.name == "Player Tank")
			{
				playerLives += 2;
				Destroy(other.gameObject);
			}
			if(gameObject.name == "Player Big Tank")
			{
				playerLives += 3;
				Destroy(other.gameObject);
			}
		}
		if(gameObject.name == "Enemy Boss Annihilator"){
			if (other.gameObject.name == "Bomb Explosion Range(Clone)") 
			{
				for(int i = 0;i < 3; i++)
				{
					if(enemyLives >= 0)
					{
						bossHealth -= 4;
						enemyLives -= 4;
					}
				}
				enemyLives -= 4;
				explosionHit = true;
				bombDamageTimer = Time.deltaTime + 1;
				if(enemyLives <= 0)
				{
					enemiesLeft--;
					Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
					Destroy(this.gameObject);
				}
			}
		}
	}
}
