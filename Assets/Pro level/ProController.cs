using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProController : MidleController {
	private ProCameraController camera;
	void Awake()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<ProCameraController> ();
		camera.AddBall (transform);
	}

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}
}
