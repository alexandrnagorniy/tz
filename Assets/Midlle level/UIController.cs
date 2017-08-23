using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public GameObject cameraController;
	public GameObject target;
	private Slider slider;
	// Use this for initialization
	protected void Start () {
		slider = GetComponent<Slider> ();
		cameraController = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	protected void Update () {
		target = (GameObject)cameraController.GetComponent<CameraController> ().ball.gameObject;
	}
}
