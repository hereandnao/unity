using System;
using UnityEngine;
using System.Collections;

public class Sliders : MonoBehaviour {


	float BaseSliderValue = 0.0f;
	float EarLeftValue = 0.0f;
	private float EarRightValue = 0.0f;

	public Transform WinkyHead;
	public Transform WinkyEarLeft;
	public Transform WinkyEarRight;

	
	
	private float rate = 2.0f;
	private float rate2 = 3.0f;
	private float rate3 = 1.0f;

	void Update()
	{

		WinkyHead.Rotate(rate * BaseSliderValue, 0, 0);
		WinkyEarLeft.Rotate(0, rate2 * EarLeftValue, 0);
		WinkyEarRight.Rotate(0, rate3 * EarRightValue, 0);
		if (Input.GetMouseButtonUp(0))
		{
			BaseSliderValue = 0;
			EarLeftValue = 0;
			EarRightValue = 0;
		}
		//	print("ROTATION TETE  = " + WinkyHead.localRotation.eulerAngles.x);
	}

	void OnGUI()
	{
		BaseSliderValue = GUI.HorizontalSlider(new Rect(25,25,100,30), BaseSliderValue, -10.0f,10.0f);
		EarLeftValue = GUI.HorizontalSlider(new Rect(25,50,100,30), EarLeftValue, -10.0f,10.0f);
		EarRightValue = GUI.HorizontalSlider(new Rect(25,75,100,30), EarRightValue, -10.0f,10.0f);
	}	
}