using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RotatePattern : MonoBehaviour {
	public int value;
	private System.Random rand;

	// Use this for initialization
	void Start () {
		// rand = new System.Random ();
		// value = rand.Next(0,10);
		this.transform.localEulerAngles = new Vector3(0, value*30, 0);
	}

	public int getValue() {
		return value;
	}

	void OnMouseDown() {
		value = ++value % 12;
		this.transform.localEulerAngles = new Vector3(0, value*30, 0);
		this.transform.parent.GetComponent<PuzzleMoon1>().checkAnswer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
