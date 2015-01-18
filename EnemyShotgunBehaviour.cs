using UnityEngine;
using System.Collections;

public class EnemyShotgunBehaviour : MonoBehaviour {
	public int moveOrNot;
	public float moveEnemySpeed;
	private float enemyRotation;
	
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;

	private float fireRate = 2.5f;
	private float randomFireRate = 1;
	
	private float nextFire;

	public float range;
	
	// Use this for initialization
	void Start () {
		randomFireRate = Random.Range(0f, 0.5f) + 0.75f;
	}
	
	// Updatie is called once per frame
	void Update () {
		if (moveOrNot == 1) 
		{
			transform.Translate (Vector3.forward * moveEnemySpeed);
		}

		Collider[] cols = Physics.OverlapSphere (transform.position, range);
		foreach (Collider col in cols)
		{
			if (col && col.tag == "Player")
			{
				if (Time.time > nextFire) {//shot spawnen
					nextFire = Time.time + (fireRate * randomFireRate);
					Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
					Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
					Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
				}
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
	}
}