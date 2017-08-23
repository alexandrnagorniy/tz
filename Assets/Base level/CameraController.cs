using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform ball;
	protected float speed;
	protected Transform camera;
	// Use this for initialization
	protected void Start () 
	{
		camera = transform.Find ("Main Camera").GetComponent<Transform> ();	
		speed = 0.05f;
	}
	
	// Update is called once per frame
	protected void Update () {
		camera.transform.LookAt (ball);
		transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, speed);
	}
}
