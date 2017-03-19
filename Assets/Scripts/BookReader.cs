using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookReader : MonoBehaviour {

	public List<string> bookContent;
	public GameObject rippedPage;
	List<string> outContent;
	List<int> numPage;
	int numPages;
	int page;
	bool next;
	bool prev;
	Text[] bookPage;

	// Use this for initialization
	void Start () {
		page = 0;
		outContent = new List<string> ();
		numPage = new List<int> ();
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
		int currNumPage = 0;
		int nextNumPage = 0;
		bool isRipped = false;
		foreach (string content in bookContent) {
			string[] words = content.Split(' ');
			int numGenPages = 0;
			string sentence = "";
			for (int i = 0; i < words.Length; i++) {
				if (i == 0) {
					if (words [i].Split ('#') [0].Contains ("-")) {
						currNumPage = int.Parse (words [i].Split ('#')[0].Split('-')[0]);
						nextNumPage = int.Parse (words [i].Split ('#')[0].Split('-')[1]);
						isRipped = true;
					} else {
						currNumPage = int.Parse (words [i].Split ('#') [0]);
					}
					words [i] = words [i].Split ('#') [1];
				}
				sentence = sentence + words [i] + " ";
				if ((i != 0 && i % 49 == 0) || i == words.Length - 1) {
					numGenPages++;
					outContent.Add (sentence);
					numPage.Add (currNumPage++);
					sentence = "";
				}
			}
			if (numGenPages % 2 == 1) {
				outContent.Add (sentence);
				if (isRipped) {
					numPage.Add (nextNumPage);
					isRipped = false;
				} else
					numPage.Add (currNumPage);
			}
		}
		numPages = outContent.Count;
	}
	void updateText() {
		if (outContent [page].Contains ("mssng")) {
			rippedPage.SetActive (true);
			bookPage [0].text = "";
			bookPage [1].text = "";
		} else {
			rippedPage.SetActive (false);
			bookPage [0].text = outContent [page];
			bookPage [1].text = outContent [page + 1];
		}
		bookPage [2].text = numPage[page].ToString();
		bookPage [3].text = numPage[page + 1].ToString();
	}

	public void nextPage() {
		next = true;
	}

	public void prevPage() {
		prev = true;
	}
}
