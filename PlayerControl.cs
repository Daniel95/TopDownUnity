using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private float moveSpeed;
	private float rotateSpeed;
	public float plusMoveSpeed;
	public float plusRotateSpeed;


	//public float TankX = 0;
	//public float TankY = 0;

	private bool countDown;
	private float duration;

	private float fireRateBonus;
	private float nextFire;

	public GameObject shot;
	public Transform shotSpawn;

	public static float fireMode = 2;

	private float myVelocity;

	/*
	private bool smokeOn;
	public GameObject smoke;
	public Transform smokeSpawn1;
	*/
	
	// Use this for initialization
	void Start () 
	{
		if(gameObject.name == "Player Tank")
		{
			myVelocity = 15;
		}
		if(gameObject.name == "Player Race Tank")
		{
			myVelocity = 80;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Checken of level klaar is:
		if(UI.enemies <= 0) 
		{
			int i = Application.loadedLevel;
			if(i == 11){
				Menu.gameFinished = true;
				Application.LoadLevel("Menu");
			}
			else{
				Application.LoadLevel(i + 1);
			}
		}

		//Velocity:
		transform.Translate (Vector3.forward * (moveSpeed * Time.deltaTime));
		transform.Rotate (Vector3.up * (rotateSpeed * Time.deltaTime));
		
		moveSpeed -= moveSpeed/myVelocity;
		rotateSpeed -= rotateSpeed/15;
		// Movement input:
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			moveSpeed += plusMoveSpeed;
		}
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			moveSpeed -= plusMoveSpeed;
		}
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			rotateSpeed -= plusRotateSpeed;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			rotateSpeed += plusRotateSpeed;
		}
		//Schieten:
		if (Input.GetButton("Fire1") && Time.time > nextFire) {//shot spawnen
			if (fireMode == 3){
				nextFire = Time.time + 0.9f - (fireRateBonus * 6f);
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
			if (fireMode == 2){
				nextFire = Time.time + 0.6f - (fireRateBonus * 4f);
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
			if (fireMode == 1){
				nextFire = Time.time + 0.3f - (fireRateBonus * 2f);
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
		//Schietmodus veranderen
		if (Input.GetMouseButtonDown (1)) //schietmodus veranderen
		{
		fireMode--;
			if (fireMode < 1)
				{
				fireMode = 3;
				}
		}

		//Firerate Pickup uitvoeren:
		if(countDown)
		{
			fireRateBonus = 0.1f;
			duration -= Time.deltaTime;
			if(duration <= 0)
			{
				countDown = false;
				fireRateBonus = 0f;
			}
		}
		/*
		//Rook uitvoeren:
		if (Die.playerLives <= 2 && smokeOn == false) 
		{
			Instantiate(smoke, turret.position, smokeSpawn1.rotation);
			//smoke.transform.parent = transform;
			smokeOn = true;
		}
		if (Die.playerLives > 2) 
		{
			smokeOn = false;	
		}
		*/
		
	}
	//Firerate pickup oppakken:
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Firerate Pickup")
		{
			countDown = true;
			duration = 8;
			Destroy(other.gameObject);
		}
		if (other.gameObject.name == "SpeedBoost")
		{
			if(moveSpeed > 0)
			{
				moveSpeed += 1.5f;
			}
			if(moveSpeed < 0)
			{
				moveSpeed += -1.5f;
			}
		}
	}
}
