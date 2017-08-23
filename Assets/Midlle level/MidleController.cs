using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidleController : Controller {
	protected float baseSpeed;
	protected LineRenderer renderer;
	protected Vector3 lastPosition;
	protected float timer;
	// Use this for initialization
	protected void Start () {
		base.Start ();
		baseSpeed = speed;
		renderer = GetComponent<LineRenderer> ();
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
		if(timer > 0)
		timer -= Time.deltaTime;
	}

	void LateUpdate(){
		DrawLine ();
	}

	void DrawLine()
	{
		if (transform.position != lastPosition) 
		{
			renderer.positionCount++;
			renderer.SetPosition (renderer.positionCount - 1, transform.position);
			lastPosition = transform.position;
		}
	}

	public void Slider(float value)
	{
		speed = baseSpeed * value;
	}

	protected void OnMouseDown()
	{
		base.OnMouseDown ();
		if (timer <= 0)
			timer = 0.2f;
		else {
			isMoving = false;
			renderer.positionCount = 0;
			transform.position = new Vector3 (controller.x [0], controller.y [0], controller.z [0]);
			step = 1;
		}
	}
}
