using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumpadController : MonoBehaviour {

	public KeyCode Left = KeyCode.A;
	public KeyCode Right = KeyCode.D;
	public KeyCode Up = KeyCode.W;
	public KeyCode Down = KeyCode.S;
	public Transform RPB;
	public Transform PB;
	public DoorController doorController;
	public float timeBetweenFlicks = 0.1f;
	public string password; // password to unlock key
	string answer; // string to concatenate answer
	float timer;
	Vector3 newPos; // new position for RPB upon position change 
	Text[] keys; // array of text containing each key value
	PadController[] padControllers; // array of PadController
	int activeKey = 0; // which pad button is active
	int position = 0; // the position in array padControllers
	[SerializeField] float currentAmount = 0;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		keys = GetComponentsInChildren<Text> ();
		padControllers = GetComponentsInChildren<PadController> ();
		int pos = 0;
		foreach (PadController pc in padControllers) {
			pc.setPos (pos);
			pos++;
		}
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		/*if (timer >= timeBetweenFlicks && Time.timeScale != 0) {
			if (Input.GetKey (Left)) {
				position--;
				if (position < 0) {
					position = padControllers.Length - 1;
				}
				timer = 0f;
				currentAmount = 0;
			}
			if (Input.GetKey (Right)) {
				position++;
				if (position >= padControllers.Length) {
					position = 0;
				}
				timer = 0f;
				currentAmount = 0;
			}
			if (Input.GetKey (Up)) {
				position = position - 3;
				if (position < 0 ) {
					position = position + padControllers.Length;
				}
				timer = 0f;
				currentAmount = 0;
			}
			if (Input.GetKey (Down)) {
				position = position + 3;
				if (position >= padControllers.Length) {
					position = position - padControllers.Length;
				}
				timer = 0f;
				currentAmount = 0;
			}

			newPos = new Vector3 (
				padControllers [position].gameObject.transform.position.x, 
				padControllers [position].gameObject.transform.position.y + 15
			);
			RPB.position = newPos;
		}*/

		if (currentAmount < 100) {
			currentAmount += speed * Time.deltaTime;
		} else {
			if (padControllers[position].getKeyValue().Equals("erase") && activeKey > 0) {
				activeKey--;
				keys [activeKey].text = "";
			} else if (padControllers[position].getKeyValue().Equals("cancel")) {
				foreach (Text key in keys) {
					key.text = "";
				}
				activeKey = 0;
			} else if (padControllers[position].getKeyValue().Equals("check")) {
				foreach (Text key in keys) {
					answer += key.text;
				}
				if (answer.Equals (password)){
					Debug.Log ("Answer "+ answer + " is Correct");
					doorController.unlockDoor ();
				} else {
					Debug.Log ("Answer "+ answer + " is Wrong");
				}
				answer = "";
			} else if (activeKey < 4) {
				keys [activeKey].text = padControllers[position].getKeyValue();
				activeKey++;
			}
			currentAmount = 0;

		}
		PB.GetComponentInChildren<Image>().fillAmount = currentAmount / 100;
	}

	//on button click input
	public void inputAnswer(int pos, Vector3 newPosition) {
		currentAmount = 0;
		position = pos;
		newPos = new Vector3 (
			newPosition.x, 
			newPosition.y + 15
		);
		RPB.position = newPos;
	}
}
