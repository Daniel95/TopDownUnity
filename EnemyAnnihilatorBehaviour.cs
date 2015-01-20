using UnityEngine;
using System.Collections;

public class EnemyAnnihilatorBehaviour : MonoBehaviour {
	public int moveOrNot;
	public float moveEnemySpeed;
	private float enemyRotation;
	
	public GameObject shot1;
	public GameObject shot2;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;

	private float fireRate;
	private float randomFireRate = 1;
	
	private bool secondShot;
	//private bool thirdShot;

	private float nextFire1;
	private float nextFire2;
	private float nextFire3;

	private bool isBoss;
	private bool inRange;
	
	// Use this for initialization
	void Start () {
		if (gameObject.name == "Enemy Annihilator") 
		{
			fireRate = 2.5f;
			isBoss = false;
			randomFireRate = Random.Range(0f, 0.5f) + 0.75f;
		}
		if (gameObject.name == "Enemy Boss Annihilator") 
		{
			fireRate = 5f;
			isBoss = true;
			randomFireRate = Random.Range(0f, 1f) + 0.50f;
		}
	}


	// Updatie is called once per frame
	void Update () {
		if (moveOrNot == 1) 
		{
			transform.Translate (Vector3.forward * moveEnemySpeed);
		}

		if(inRange == true){
			if (Time.time > nextFire1) {//shot spawnen
				nextFire1 = Time.time + (fireRate * randomFireRate);
				Instantiate (shot1, shotSpawn1.position, shotSpawn1.rotation);
				Instantiate (shot2, shotSpawn4.position, shotSpawn3.rotation);
				nextFire2 = Time.time + (fireRate / 2);
				secondShot = true;
			}
			if (Time.time > nextFire2 && secondShot == true) {//shot spawnen
				Instantiate(shot1, shotSpawn2.position, shotSpawn2.rotation);
				Instantiate (shot2, shotSpawn3.position, shotSpawn4.rotation);
				secondShot = false;
			}
		}
		if(isBoss){
			if (Time.time > nextFire1) {//shot spawnen
				nextFire1 = Time.time + (fireRate * randomFireRate);
				Instantiate (shot1, shotSpawn1.position, shotSpawn1.rotation);
				Instantiate (shot2, shotSpawn4.position, shotSpawn3.rotation);
				nextFire2 = Time.time + (fireRate / 2);
				//nextFire3 = Time.time + (fireRate / 2f);
				//thirdShot = true;
				secondShot = true;
			}
			if (Time.time > nextFire2 && secondShot == true) {//shot spawnen
				Instantiate (shot1, shotSpawn2.position, shotSpawn2.rotation);
				Instantiate (shot2, shotSpawn3.position, shotSpawn4.rotation);
				secondShot = false;
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Rotate90")
		{
			transform.Rotate(new Vector3(0,90,0));
		}
		if (other.gameObject.name == "Rotate180")
		{
			transform.Rotate(new Vector3(0,180,0));
		}
		if (other.gameObject.name == "Rotate270")
		{
			transform.Rotate(new Vector3(0,270,0));
		}

		if(isBoss == false)
		{
			if (other.gameObject.name == "InRange")
			{
				inRange = true;
			}
		}
	}
}