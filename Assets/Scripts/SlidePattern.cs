using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePattern : MonoBehaviour {
	public int arrow;
	public int color;
	private bool unpressbutton;
	private bool pressbutton;
	private Vector3 translation = new Vector3(0,-0.08f,0);
	private Vector3 targetPress;
	private Vector3 targetNormal;
	private float step;

	// Use this for initialization
	void Start () {
		unpressbutton = false;
		pressbutton = false;
		step = 1 * Time.deltaTime;
		targetNormal = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		targetPress = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		targetPress += translation;
	}

	void OnMouseDown() {
		if (!pressbutton && !unpressbutton){
			StartCoroutine(Press());
			if (color == 1) {
				this.transform.parent.parent.GetComponent<PuzzleMoon5>().slideRed(arrow);
			} else if (color == 2) {
				this.transform.parent.parent.GetComponent<PuzzleMoon5>().slideGreen(arrow);
			} else if (color == 3) {
				this.transform.parent.parent.GetComponent<PuzzleMoon5>().slideYellow(arrow);
			}
		}
	}

	IEnumerator Press() {
		pressbutton = true;
        yield return new WaitForSeconds(0.3f);
        pressbutton = false;
        StartCoroutine(Unpress());
    }

    IEnumerator Unpress() {
    	unpressbutton = true;
    	yield return new WaitForSeconds(0.3f);
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
	}
}
