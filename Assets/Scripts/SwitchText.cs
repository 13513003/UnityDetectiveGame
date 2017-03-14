using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchText : MonoBehaviour {
	public Text mytext;
	public int counter = 0;
	public bool On = true;

	public void changeText(GameObject button){
		counter++;
		mytext = button.GetComponent<Text> ();
		if (counter % 2 == 1) {
			mytext.text = "On";
			On = true;
		} else {
			mytext.text = "Off";
			On = false;
		}
	}
	public bool state(){
		return On;
	}
}
