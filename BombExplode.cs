using UnityEngine;
using System.Collections;

public class BombExplode : MonoBehaviour {

	private float bombLives = 3;


	public GameObject explosionRange;
	public GameObject explosion;
	public Transform explosionSpawn;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter(Collision col)
	{
		//enemies/woodwall raken en verwijderen:
		if(col.gameObject.name == "Player Bullet(Clone)")
		{
			bombLives--;
			if(bombLives <= 0)
			{

				Instantiate(explosionRange, explosionSpawn.position, explosionSpawn.rotation);
				Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation);
				bombLives = 3;
			}
		}
	}
}
