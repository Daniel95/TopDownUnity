using UnityEngine;
using System.Collections;

public class EnemyBigBehaviour : MonoBehaviour {
	public int moveOrNot;
	public float moveEnemySpeed;
	private float enemyRotation;
	
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;

	private float fireRate = 2f;
	private float randomFireRate = 1;

	private bool secondShot;
	private bool thirdShot;
	
	private float nextFire1;
	private float nextFire2;
	private float nextFire3;

	private bool isBoss;

	private bool inRange;
	
	// Use this for initialization
	void Start () {
		if (gameObject.name == "Enemy Boss Big") 
		{
			fireRate = 3.4f;
			isBoss = true;
		}
		if (gameObject.name == "Enemy Explode Big") 
		{
			fireRate = 5f;
			isBoss = false;
		}
		if (gameObject.name == "Enemy Big")
		{
			fireRate = 2f;
			isBoss = false;
		}
		randomFireRate = Random.Range(0f, 0.5f) + 0.75f;
	}

	// Updatie is called once per frame
	void Update () 
	{
		if (moveOrNot == 1) 
		{
			transform.Translate (Vector3.forward * moveEnemySpeed);
		}
		if(inRange)
		{
			if (Time.time > nextFire1) 
			{//shot spawnen
				nextFire1 = Time.time + (fireRate * randomFireRate);
				Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation);
				nextFire2 = Time.time + (fireRate / 4);
				nextFire3 = Time.time + (fireRate / 2f);
				thirdShot = true;
				secondShot = true;
			}
			if (Time.time > nextFire2 && secondShot == true) {//shot spawnen
				Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation);
				secondShot = false;
			}
		}
		if(isBoss)
		{
			if (Time.time > nextFire1) //shot spawnen
			{
				nextFire1 = Time.time + (fireRate * randomFireRate);
				Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation);
				nextFire2 = Time.time + (fireRate / 4);
				nextFire3 = Time.time + (fireRate / 2f);
				thirdShot = true;
				secondShot = true;
			}
			if (Time.time > nextFire2 && secondShot == true) {//shot spawnen
				Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation);
				secondShot = false;
			}
			if (Time.time > nextFire3 && thirdShot == true)
			{
				Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation);
				Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation);
				thirdShot = false;
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