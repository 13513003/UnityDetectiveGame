using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyController : MonoBehaviour {

	string value;
	int position;
	Text text;
	float timer;
	float timeBetweenFlicks = 0.5f;
	float distance = 50f;
	float time = 0.5f;
	string action;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
		value = text.text;
		action = "default";
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer < timeBetweenFlicks && Time.timeScale != 0) {
			if (action.Equals ("up")) {
				this.transform.Translate (Vector3.up * Time.deltaTime * distance / time);
			} else if (action.Equals ("down")) {
				this.transform.Translate (Vector3.down * Time.deltaTime * distance / time);
			}
		} else {
			action = null;
		}
	}

	public void moveDown() {
		timer = 0f;
		action = "down";
	}

	public void moveUp() {
		timer = 0f;
		action = "up";
	}

	public void setPos(int pos) {
		position = pos;
	}

	public int getPos() {
		return position;
	}

	public void setVal(string val) {
		value = val;
	}

	public string getValue() {
		return value;
	}
}
