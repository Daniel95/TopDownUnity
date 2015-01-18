using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	//Random rnd = new Random();
	//float randomFireRate = rnd.Next(0, 10) + 0.5;
	public int moveOrNot;
	public float moveEnemySpeed;
	private float enemyRotation;

	public GameObject shot;
	public Transform shotSpawn;
	private float fireRate = 1.5f;
	
	private float nextFire;

	private float randomFireRate = 1;

	private bool isTurret = false;

	public float range;

	//private float range = 25;

	// Use this for initialization
	void Start () {
		/*
		if (moveOrNot = 1)
		{
			range += 30;
		}
		*/
		if(gameObject.name == "Rotating Turret")
		{
			fireRate = 0.5f;
		} 
		if(gameObject.name == "Enemy  Sniper")
		{
			fireRate = 4f;
		} 
		if (gameObject.tag == "Enemy")
		{
			randomFireRate = Random.Range(0f, 0.5f) + 0.75f;
		}
		if(gameObject.tag == "Turret")
		{
			isTurret = true;
		}
	}
	
	// Updatie is called once per frame
	void Update () {
	
		if (moveOrNot == 1) 
		{
			transform.Translate (Vector3.forward * moveEnemySpeed);
		}
		if (gameObject.name == "Rotating Turret") 
		{
			transform.Rotate(new Vector3(0,3,0));
		}


		if(isTurret == false)
		{
			//see if in range:
			Collider[] cols = Physics.OverlapSphere (transform.position, range);
			foreach (Collider col in cols)
			{
				if (col && col.tag == "Player")
				{
					if (Time.time > nextFire) {//shot spawnen
						nextFire = Time.time + (fireRate * randomFireRate);
						Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
					}
				}
			}
		}
		if(isTurret == true)
		{
			if (Time.time > nextFire) {//shot spawnen
				nextFire = Time.time + (fireRate * randomFireRate);
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(gameObject.tag == "Enemy")
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
		}
		if (gameObject.name == "Turret") 
		{
			if (other.gameObject.name == "Rotate180")
			{
				if (moveEnemySpeed == 0.05f)
				{
					moveEnemySpeed = -0.05f;
				}
				else
				{
					moveEnemySpeed = 0.05f;
				}
			}

		}
	}
}
