﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
	RaycastHit hit;
	Ray ray;
	Vector3 origin;
	bool start = false, correct = true, end = false;
	LineRenderer lineRenderer;
	Camera thisCamera;
	Transform originObj;
	int numPoints;
	GameObject[] answer;

	public float startWidth = 0.1f;
	public float endWidth = 0.1f;
	public string selectableAreaTag = "phone_component";
	public string selectableObjectTag = "unselected";
	public string selectedObjectTag = "selected";
	public int numSelectables = 9;
	public GameObject[] answerSequence;
	// Use this for initialization
	void Awake () {
		thisCamera = Camera.main;
		lineRenderer = GetComponent<LineRenderer>();
		answer = new GameObject[numSelectables];
		lineRenderer.startWidth = startWidth;
		lineRenderer.endWidth = endWidth;
	}
	
	// Update is called once per frame
	void Update () {
		if (!end) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (!start) {
					if (Physics.Raycast (ray, out hit) && hit.collider.transform.tag == selectableObjectTag) {
						print ("selected");
						originObj = hit.collider.transform;
						originObj.tag = selectedObjectTag;
						origin = hit.collider.transform.position;

						numPoints = 1;
						lineRenderer.numPositions = numPoints;
						lineRenderer.SetPosition (0, origin);
						start = true;
						answer [0] = hit.transform.gameObject;

					}
				} else {
					print ("drew");
					if (Physics.Raycast (ray, out hit)) {
						Vector3 mousePos = hit.point;

						lineRenderer.numPositions = numPoints + 1;

						if (hit.collider.transform.tag == selectableObjectTag) {
							print ("new origin");
							hit.collider.transform.tag = selectedObjectTag;
							origin = hit.collider.transform.position;
							lineRenderer.SetPosition (numPoints, origin);
							answer [numPoints] = hit.transform.gameObject;
							numPoints++;
						} else if (hit.collider.transform.tag == selectableAreaTag || hit.collider.transform.tag == selectedObjectTag) {
							mousePos.z = origin.z;
							lineRenderer.SetPosition (numPoints, mousePos);
						}
					}
				}
			} else {
				for (int i = 0; i < answer.Length; i++) {
					if (i < answerSequence.Length) {
						if (answer [i] != answerSequence [i]) {
							correct = false;
						}
					} else {
						if (answer [i] != null)
							correct = false;
					}
					answer [i] = null;
				}
				if (!correct) {
					print ("wrong!!");
					lineRenderer.numPositions = 0;
					GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (selectedObjectTag);
					foreach (GameObject gObj in gameObjects) {
						gObj.transform.tag = selectableObjectTag;
					}
				} else {
					lineRenderer.numPositions = numPoints;
					end = true;
				}
				correct = true;
				start = false;
			}
		}
	}
}
