using UnityEngine;
using System.Collections;

public class EnemyExplodingBulletMove : MonoBehaviour {
	public float bulletSpeed;
	public GameObject explosionPrefab;
	private float lifeTime;
	public float maxLifeTime;
	
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float delta = Time.deltaTime;
		transform.Translate(Vector3.forward * bulletSpeed * delta);
		lifeTime += delta;
		if (lifeTime > maxLifeTime) 
		{
			Destroy(this.gameObject);
			Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
		}
	}
	void OnCollisionEnter(Collision col)
	{ 
		Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
		Instantiate (shot, shotSpawn1.position, shotSpawn1.rotation);
		Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation);
		Instantiate (shot, shotSpawn3.position, shotSpawn3.rotation);
		Instantiate (shot, shotSpawn4.position, shotSpawn4.rotation);
		
		Destroy (this.gameObject);
	}
}
