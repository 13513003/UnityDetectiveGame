using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoon2 : MonoBehaviour {
	private GameObject[] Button;
	private GameObject Sun;
	private int state = 0;
	private bool rightAnswer;
	private Vector3 translation = new Vector3(2,0,0);
	private Vector3 target;
	private float step;

	// Use this for initialization
	void Start () {
		Button = new GameObject[12];
		Button[0] = this.transform.Find("Capricorn").gameObject;
		Button[1] = this.transform.Find("Aquarius").gameObject;
		Button[2] = this.transform.Find("Pisces").gameObject;
		Button[3] = this.transform.Find("Aries").gameObject;
		Button[4] = this.transform.Find("Taurus").gameObject;
		Button[5] = this.transform.Find("Gemini").gameObject;
		Button[6] = this.transform.Find("Cancer").gameObject;
		Button[7] = this.transform.Find("Leo").gameObject;
		Button[8] = this.transform.Find("Virgo").gameObject;
		Button[9] = this.transform.Find("Libra").gameObject;
		Button[10] = this.transform.Find("Scorpio").gameObject;
		Button[11] = this.transform.Find("Sagittarius").gameObject;
		Sun = this.transform.Find("Sun").gameObject;
		rightAnswer = false;
		target = new Vector3(Sun.transform.position.x,Sun.transform.position.y,Sun.transform.position.z);
		target += translation;
		step = 3 * Time.deltaTime;
	}

	public void checkAnswer(){
		if (checkPattern()){
			state++;
		}
		if (state == 12){
			rightAnswer = true;
		}
	}

	public bool checkPattern() {
		for(int i = 0; i <= state; i++) {
			if (! Button[i].transform.GetComponent<PressPattern>().getState()){
				resetPattern();
				return false;
			}
		}
		return true;
	}

	void resetPattern() {
		for(int i = 0; i < 12; i++){
			// if(Button[i].transform.GetComponent<PressPattern>().getState()){
				Button[i].transform.GetComponent<PressPattern>().unpress();
			// }
		}
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (rightAnswer){
			Sun.transform.position = Vector3.MoveTowards(Sun.transform.position, target, step);
		}
	}
}
