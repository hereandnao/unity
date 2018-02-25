using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{

	public float RotNeck;
	public float RotEarL;
	public float RotEarR;
	
	public Transform WinkyHead;
	public Transform WinkyEarLeft;
	public Transform WinkyEarRight;

	private float rate = 1.0f;

	private Quaternion targetRotation;
	
	void Start(){
		targetRotation = WinkyEarLeft.rotation;
	}
	
	void Update()
	{
		if (Input.GetKeyDown("e"))
		{
		//		PlayAnim(RotNeck, RotEarL, RotEarR);	
	//		StartCoroutine(Rotate(RotNeck));
			StartCoroutine(RotateHead(WinkyHead, RotNeck, 1));
	//		StartCoroutine(RotateEar(WinkyEarLeft, RotEarL, 1));
		}

		
		if (Input.GetKeyDown (KeyCode.Space)) { 
			targetRotation *=  Quaternion.AngleAxis(60, Vector3.up);
		}
	//	WinkyEarLeft.rotation= Quaternion.Lerp (WinkyEarLeft.rotation, targetRotation , 10 * 1f * Time.deltaTime); 
		
	}
	/*
	void PlayAnim(float RotNeck, float RotEarL, float RotEarR)
	{
		Rotating(WinkyHead, new Vector3(RotNeck, 0 , 0));
		WinkyEarLeft.Rotate(0, rate * RotEarL, 0);
		WinkyEarRight.Rotate(0, rate * RotEarR, 0);			
	}
	*/

	IEnumerator RotateHead(Transform tr, float RotNeck, float duration) {
		Quaternion startRot = tr.rotation;
		float t = 0.0f;
		while ( t  < duration )
		{
			t += Time.deltaTime;
			tr.rotation = startRot * Quaternion.AngleAxis(t / duration * RotNeck, transform.right); //or transform.right if you want it to be locally based
			yield return null;
		}
	}

	IEnumerator RotateEar(Transform tr, float RotEar, float duration) {
		Quaternion startRot = tr.rotation;
		float t = 0.0f;
		while ( t  < duration )
		{
			t += Time.deltaTime;
			tr.rotation = startRot * Quaternion.AngleAxis(t / duration * RotEar, tr.right); //or transform.right if you want it to be locally based
			yield return null;
		}
		//	tr.rotation = startRot;
	}
}