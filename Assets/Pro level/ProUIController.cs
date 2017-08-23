using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProUIController : UIController {
	public Text nameText;
	private float sliderValue;
	public float SliderValue{
		get{ return sliderValue; }
	}
	// Use this for initialization
	void Start () {
		base.Start ();
		sliderValue = 1;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		nameText.text = target.name.ToString();
	}

	public void Slider(float value)
	{
		sliderValue = value;
		target.GetComponent<ProController> ().Slider (value);
	}


}
