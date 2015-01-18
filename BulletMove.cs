using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	public float bulletSpeed;
	public GameObject explosionPrefab;
	private float lifeTime;
	public float maxLifeTime;

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
		Destroy (this.gameObject);
	}
}

