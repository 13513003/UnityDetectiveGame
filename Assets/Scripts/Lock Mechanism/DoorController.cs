using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {

	float smooth = 2f;
	public float DoorOpenAngle = 90f;
	public GameObject numpadLock;
	bool open;
	bool enter;
	public bool locked = true;
	//public GameObject lockedMessage;
	Vector3 defaultRot;
	Vector3 openRot;
	float timer;

	void Start(){
		defaultRot = transform.eulerAngles;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
	}

	//Main function
	void Update (){
		if(open){
			//Open door
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}else{
			//Close door
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		}

		/*timer += Time.deltaTime;
		if (timer >= 0.5f && Time.timeScale != 0) {
			lockedMessage.SetActive (false);
		}*/
	}


	/*void OnGUI(){
		if(!locked){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
		}
	}*/

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			enter = true;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			enter = false;
		}
	}

	public void unlockDoor() {
		locked = false;
		numpadLock.SetActive (false);
		//lockedMessage.SetActive (false);
	}

    public void openDoor() {
		if (locked) {
			//lockedMessage.SetActive (true);
			timer = 0f;
		} else {
			open = !open;
		}
    }

	public void showLockUI() {
		numpadLock.SetActive (true);
	}
}
