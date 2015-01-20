using UnityEngine;
using System.Collections;

public class PlayerBigControl : MonoBehaviour {
	private float moveSpeed;
	private float rotateSpeed;
	public float plusMoveSpeed;
	public float plusRotateSpeed;
	

	//public float TankX = 0;
	//public float TankY = 0;

	private bool countDown;
	private float duration;

	private float fireRateBonus;
	public float fireRate;

	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;


	private float nextFire1;
	private float nextFire2;

	private bool secondShot;

	// Use this for initialization
	void Start () 
	{
	}

	// Update is called once per frame
	void Update () 
	{
		if(UI.enemies == 0) 
		{
			int i = Application.loadedLevel;
			if(i >= 11){
				Menu.gameFinished = true;
				Application.LoadLevel("Menu");
			}
			else{
				Application.LoadLevel(i + 1);
			}
		}
		transform.Translate (Vector3.forward * (moveSpeed * Time.deltaTime));
		transform.Rotate (Vector3.up * (rotateSpeed * Time.deltaTime));
		
		moveSpeed -= moveSpeed/20;
		rotateSpeed -= rotateSpeed/17;
		// Movement input:

		if (Input.GetKey (KeyCode.W)) {
			moveSpeed += plusMoveSpeed;
		}
		if (Input.GetKey (KeyCode.S)) {
			moveSpeed -= plusMoveSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			rotateSpeed -= plusRotateSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			rotateSpeed += plusRotateSpeed;
		}

		if (Input.GetButton("Fire1") && Time.time > nextFire1) {//shot spawnen
			nextFire1 = Time.time + (fireRate - fireRateBonus);
			Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation);
			nextFire2 = Time.time + (fireRate / 4);
			secondShot = true;
		}
		if (Time.time > nextFire2 && secondShot == true) {//shot spawnen
			Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation);
			secondShot = false;
		}
		if(countDown)
		{
			fireRateBonus = 1f;
			duration -= Time.deltaTime;
			if(duration <= 0)
			{
				fireRateBonus = 0;
				countDown = false;
			}
		}
		
	}
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
				moveSpeed += 40f;
			}
			if(moveSpeed < 0)
			{
				moveSpeed += -40f;
			}
		}
	}
}