using UnityEngine;
using System.Collections;

public class PlayerBaseRotateTurret : MonoBehaviour {

	private Transform[] transforms;
	protected Transform turret;
	protected Vector3 targetPos;

	// Use this for initialization
	protected virtual void Start () {//zoekt naar de turret in de tank
		transforms = gameObject.GetComponentsInChildren<Transform>();
		foreach(Transform t in transforms)//slaat elke transform op
		{
			if (t.gameObject.name == "turret")
			{
				turret = t;
			}
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		turret.LookAt(targetPos);
	}
}
