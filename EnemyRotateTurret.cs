using UnityEngine;
using System.Collections;

public class EnemyRotateTurret : PlayerBaseRotateTurret {
	public Transform player;
	
	// Update is called once per frame
	override protected void Update () {
		targetPos = player.position;
		base.Update ();//override de update functie van BaseRotateTurret
	}
}
