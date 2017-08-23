using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProCameraController : CameraController 
{
	private List<Transform> ballStack = new List<Transform> ();
	private int targetBall;
	private ProUIController uiController;
	public void AddBall(Transform currentBall)
	{
		ballStack.Add (currentBall);
	}

	// Use this for initialization
	void Start () {
		ball = ballStack [targetBall];
		uiController = GameObject.Find ("Slider").GetComponent<ProUIController> ();
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update ();	
		ball = ballStack [targetBall];
		if (Vector3.Distance (ball.position, transform.position) > 1)
			speed = 2;
		else
			speed = 0.05f;

		foreach (Transform tempBall in ballStack) 
		{
			if (tempBall == ballStack [targetBall]) 
			{
				tempBall.GetComponent<SphereCollider> ().enabled = true;
				tempBall.GetComponent<ProController> ().Slider (uiController.SliderValue);
			}
			else
			{
				tempBall.GetComponent<SphereCollider> ().enabled = false;
				tempBall.GetComponent<ProController> ().Slider (0);
			}
		}


		#if UNITY_ANDROID || Unity_IOS 

			transform.rotation = Quaternion.Euler (0, transform.eulerAngles.y + Input.GetTouch(0).deltaPosition.x, 0);
		#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
			if (Input.GetKey (KeyCode.Mouse0))
				transform.rotation = Quaternion.Euler (0, transform.eulerAngles.y + Input.GetAxis ("Mouse X") * 5, 0);
		#endif
	}



	public void MoveToNextBall(int i)
	{
		if (targetBall + i > ballStack.Count - 1)
			targetBall = 0;
		if (targetBall + i  < 0)
			i = ballStack.Count - 1;
		targetBall += i;
	}
}