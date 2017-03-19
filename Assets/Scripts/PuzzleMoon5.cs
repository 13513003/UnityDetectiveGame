using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoon5 : MonoBehaviour {
	private int rx;
	private int ry;
	private int gx;
	private int gy;
	private int yx;
	private int yy;
	private GameObject Red;
	private GameObject Green;
	private GameObject Yellow;
	private Vector3 toUp = new Vector3(0,0.5f,0);
	private Vector3 toDown = new Vector3(0,-0.5f,0);
	private Vector3 toLeft = new Vector3(0,0,0.5f);
	private Vector3 toRight = new Vector3(0,0,-0.5f);
	private Vector3 target;
	private float step;
	private int state = 0;

	// Use this for initialization
	void Start () {
		rx = 0; ry = 0;
		gx = 0; gy = 0;
		yx = 0; yy = 0;
		Red = this.transform.Find("Red").gameObject;
		Green = this.transform.Find("Green").gameObject;
		Yellow = this.transform.Find("Yellow").gameObject;
		step = 1 * Time.deltaTime;
	}

	public void slideRed(int arrow){
		if ((arrow == 1) && (rx < 10)){
			state = 1;
			target = Red.transform.position + toLeft;
			rx++;
		} else if ((arrow == 2) && (rx > -10)){
			state = 2;
			target = Red.transform.position + toRight;
			rx--;
		} else if ((arrow == 3) && (ry < 6)){
			state = 3;
			target = Red.transform.position + toUp;
			ry++;
		} else if ((arrow == 4) && (ry > -6)){
			state = 4;
			target = Red.transform.position + toDown;
			ry--;
		}
		StartCoroutine(Check());
	}

	public void slideGreen(int arrow){
		if ((arrow == 1) && (gx < 10)){
			state = 5;
			target = Green.transform.position + toLeft;
			gx++;
		} else if ((arrow == 2) && (gx > -10)){
			state = 6;
			target = Green.transform.position + toRight;
			gx--;
		} else if ((arrow == 3) && (gy < 6)){
			state = 7;
			target = Green.transform.position + toUp;
			gy++;
		} else if ((arrow == 4) && (gy > -6)){
			state = 8;
			target = Green.transform.position + toDown;
			gy--;
		}
		StartCoroutine(Check());
	}

	public void slideYellow(int arrow){
		if ((arrow == 1) && (yx < 10)){
			state = 9;
			target = Yellow.transform.position + toLeft;
			yx++;
		} else if ((arrow == 2) && (yx > -10)){
			state = 10;
			target = Yellow.transform.position + toRight;
			yx--;
		} else if ((arrow == 3) && (yy < 6)){
			state = 11;
			target = Yellow.transform.position + toUp;
			yy++;
		} else if ((arrow == 4) && (yy > -6)){
			state = 12;
			target = Yellow.transform.position + toDown;
			yy--;
		}
		StartCoroutine(Check());
	}

	IEnumerator Check() {
        yield return new WaitForSeconds(0.3f);
        state = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (state == 1) {
			Red.transform.position = Vector3.MoveTowards(Red.transform.position, target, step);
		} else if (state == 2) {
			Red.transform.position = Vector3.MoveTowards(Red.transform.position, target, step);
		} else if (state == 3) {
			Red.transform.position = Vector3.MoveTowards(Red.transform.position, target, step);
		} else if (state == 4) {
			Red.transform.position = Vector3.MoveTowards(Red.transform.position, target, step);
		} else if (state == 5) {
			Green.transform.position = Vector3.MoveTowards(Green.transform.position, target, step);
		} else if (state == 6) {
			Green.transform.position = Vector3.MoveTowards(Green.transform.position, target, step);
		} else if (state == 7) {
			Green.transform.position = Vector3.MoveTowards(Green.transform.position, target, step);
		} else if (state == 8) {
			Green.transform.position = Vector3.MoveTowards(Green.transform.position, target, step);
		} else if (state == 9) {
			Yellow.transform.position = Vector3.MoveTowards(Yellow.transform.position, target, step);
		} else if (state == 10) {
			Yellow.transform.position = Vector3.MoveTowards(Yellow.transform.position, target, step);
		} else if (state == 11) {
			Yellow.transform.position = Vector3.MoveTowards(Yellow.transform.position, target, step);
		} else if (state == 12) {
			Yellow.transform.position = Vector3.MoveTowards(Yellow.transform.position, target, step);
		}
	}
}
