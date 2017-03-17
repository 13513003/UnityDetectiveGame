using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPattern : MonoBehaviour {
	private bool state;
	private bool unpressbutton;
	private bool pressbutton;
	private Vector3 translation = new Vector3(0,-0.3f,0);
	private Vector3 targetPress;
	private Vector3 targetNormal;
	private float step;

	// Use this for initialization
	void Start () {
		state = false;
		unpressbutton = false;
		pressbutton = false;
		step = 3 * Time.deltaTime;
		targetNormal = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		targetPress = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		targetPress += translation;
	}

	public bool getState() {
		return state;
	}

	void OnMouseDown() {
		state = true;
		// this.transform.position += translation;
		StartCoroutine(Check());
		this.transform.parent.GetComponent<PuzzleMoon2>().checkAnswer();
	}

	public void unpress() {
		state = false;
		StartCoroutine(False());
		// this.transform.position -= translation;
	}

	IEnumerator Check() {
		pressbutton = true;
        yield return new WaitForSeconds(1);
        pressbutton = false;
    }

    IEnumerator False() {
		unpressbutton = true;
        yield return new WaitForSeconds(1);
        unpressbutton = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (pressbutton){
			transform.position = Vector3.MoveTowards(this.transform.position, targetPress, step);
		}
		if (unpressbutton){
			transform.position = Vector3.MoveTowards(this.transform.position, targetNormal, step);
		}
		// if(transform.position == targetPress){
		// 	pressbutton = false;
		// }
		// if(transform.position == targetNormal){
		// 	unpressbutton = false;
		// }
	}
}
