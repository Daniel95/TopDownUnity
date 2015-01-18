using UnityEngine;
using System.Collections;

public class ParticleSelfDestruct : MonoBehaviour {
	private float lifeTime;
	public float maxLifeTime;
	public float lightFade;
	private new Light light;
	// Use this for initialization
	void Start () {

		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity -= lightFade;

		lifeTime += Time.deltaTime;
		if (lifeTime > maxLifeTime)
		{
			Destroy(this.gameObject);
		}
	}
}
