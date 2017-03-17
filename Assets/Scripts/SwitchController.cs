using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchController : MonoBehaviour {
	public GameObject[] buttons;
	public int buttonidx;
	SwitchText st;
	bool[] states;
	Text mytext;
	int[] counter;
	bool On = true;
	void Start() {
		counter = new int[buttons.Length];
		states = new bool[buttons.Length];
		for (int i = 0; i < buttons.Length; i++) {
			counter [i] = 0;
			states [i] = false;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void buttonClick(Object myObject){
		Debug.Log(states.ToString());
		for (int i = 0; i < buttons.Length; i++) {
			if(myObject.Equals(buttons[i])){
				buttonidx = i;
			}
		}
		mytext = buttons [buttonidx].GetComponentInChildren<Text> ();
		counter[buttonidx]++;
		if (counter[buttonidx] % 2 == 1) {
			mytext.text = "On";
			On = true;
			states [buttonidx] = true;
		} else {
			mytext.text = "Off";
			On = false;
			states [buttonidx] = false;
		}
	}

}
