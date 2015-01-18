using UnityEngine;
using System.Collections;

public class TankBallMove : MonoBehaviour {
	private float moveSpeed;
	private float rotateSpeed;
	public float plusMoveSpeed;
	public float plusRotateSpeed;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Velocity:
		transform.Translate (Vector3.forward * moveSpeed);
		transform.Rotate (Vector3.up * rotateSpeed);
		
		moveSpeed -= moveSpeed/10;
		rotateSpeed -= rotateSpeed/10;
		// Movement input:
		if (gameObject.name == "Player1") 
		{
			if (Input.GetKey (KeyCode.W)) {
				moveSpeed += plusMoveSpeed;
			}
			if (Input.GetKey (KeyCode.S)) {
				moveSpeed -= plusMoveSpeed;
			}
			if (Input.GetKey (KeyCode.A)) {
				rotateSpeed -= plusRotateSpeed;
			}
			if (Input.GetKey (KeyCode.D)) {
				rotateSpeed += plusRotateSpeed;
			}
		}
		if (gameObject.name == "Player2") 
		{
			if (Input.GetKey (KeyCode.UpArrow)) {
				moveSpeed += plusMoveSpeed;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				moveSpeed -= plusMoveSpeed;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rotateSpeed -= plusRotateSpeed;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				rotateSpeed += plusRotateSpeed;
			}
		}
	}
}