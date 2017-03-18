using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookReader : MonoBehaviour {

	public List<string> bookContent;
	public GameObject rippedPage;
	List<string> outContent;
	int numPages;
	int page;
	bool next;
	bool prev;
	Text[] bookPage;

	// Use this for initialization
	void Start () {
		page = 0;
		outContent = new List<string> ();
		bookPage = GetComponentsInChildren<Text> ();
		initializeText ();
		updateText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (page >= numPages - 2)
			next = false;
		if (next) {
			page = page + 2;
			next = false;
			updateText ();
		}
		if (prev && page > 0) {
			page = page - 2;
			prev = false;
			updateText();
		}
	}

	void initializeText() {
		foreach (string content in bookContent) {
			string[] words = content.Split(' ');
			int numGenPages = 0;
			string sentence = "";
			for (int i = 0; i < words.Length; i++) {
				sentence = sentence + words [i] + " ";
				if ((i != 0 && i % 49 == 0) || i == words.Length - 1) {
					numGenPages++;
					outContent.Add (sentence);
					sentence = "";
				}
			}
			if (numGenPages % 2 == 1)
				outContent.Add (sentence);
		}
		numPages = outContent.Count;
	}
	void updateText() {
		if (outContent [page].Contains ("#missing")) {
			rippedPage.SetActive (true);
			bookPage [0].text = "";
			bookPage [1].text = "";
		} else {
			rippedPage.SetActive (false);
			bookPage [0].text = outContent [page];
			bookPage [1].text = outContent [page + 1];
		}

	}

	public void nextPage() {
		next = true;
	}

	public void prevPage() {
		prev = true;
	}
}
