using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	protected float speed = 1f;
	[SerializeField]
	protected string jsonName;
	[SerializeField]
	protected BallController controller;
	protected bool isMoving;
	protected int step = 1;
	protected Vector3 nextPosition;
	// Use this for initialization
	protected void Start () {
		controller = CreateData (jsonName);
		transform.position = new Vector3 (controller.x [0], controller.y [0], controller.z [0]);
	}
	
	// Update is called once per frame
	protected void Update () 
	{
		if(isMoving) 
		{
			nextPosition = new Vector3 (controller.x [step], controller.y [step], controller.z [step]);
			transform.position = Vector3.MoveTowards (transform.position, nextPosition, speed * Time.deltaTime);
			if (transform.position == nextPosition) {
				isMoving = false;
				step++;
			}
		}
	}



	protected BallController CreateData(string name)
	{
		return JsonUtility.FromJson<BallController> (Resources.Load(name).ToString());
	}
		
	protected void OnMouseDown()
	{
		if (!isMoving) 
			isMoving = true;	
	}
}

[System.Serializable]
public class BallController
{
	public float[] x;
	public float[] y;
	public float[] z;
}