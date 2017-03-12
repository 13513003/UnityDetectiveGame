using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {

	float smooth = 2f;
	float DoorOpenAngle = 90f;
	bool open;
	bool enter;
	bool locked = true;

	Vector3 defaultRot;
	Vector3 openRot;

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

		if(Input.GetKeyDown("f")){
			open = !open;
		}
	}


	void OnGUI(){
		if(!locked){
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
		}
	}

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
	}

    public void openDoor() {
        open = !open;
    }
}
