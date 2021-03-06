﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBubbles : MonoBehaviour {

	public GameObject initialBlueBubble;
	public float timeForNewBlueBubble;
	private float currentBlueTime = 0.0f;
	private Vector3 initialBlueBubblePos;
	List<GameObject> newBlueBubble = new List<GameObject>();

	public GameObject initialRedBubble;
	public float timeForNewRedBubble;
	private float currentRedTime = 0.0f;
	private Vector3 initialRedBubblePos;
	List<GameObject> newRedBubble = new List<GameObject>();

	public GameObject initialBlackBubble;
	public float timeForNewBlackBubble;
	private float currentBlackTime = 0.0f;
	private Vector3 initialBlackBubblePos;
	List<GameObject> newBlackBubble = new List<GameObject>();

	public GameObject initialGreenBubble;
	public float timeForNewGreenBubble;
	private float currentGreenTime = 0.0f;
	private Vector3 initialGreenBubblePos;
	List<GameObject> newGreenBubble = new List<GameObject>();

	void Start () {
		newBlueBubble.Add (initialBlueBubble);
		initialBlueBubblePos = initialBlueBubble.transform.position;

		newRedBubble.Add (initialRedBubble);
		initialRedBubblePos = initialRedBubble.transform.position;

		newBlackBubble.Add (initialBlackBubble);
		initialBlackBubblePos = initialBlackBubble.transform.position;

		newGreenBubble.Add (initialGreenBubble);
		initialGreenBubblePos = initialGreenBubble.transform.position;
	}

	void Update () {
		createNewBlueBubble();
		StartCoroutine(removeNullElsFromList(newBlueBubble));

		createNewRedBubble();
		StartCoroutine(removeNullElsFromList(newRedBubble));

		createNewBlackBubble();
		StartCoroutine(removeNullElsFromList(newBlackBubble));

		createNewGreenBubble();
		StartCoroutine(removeNullElsFromList(newGreenBubble));
	}

	void createNewBlueBubble() {
		if (Time.time - currentBlueTime > timeForNewBlueBubble) {
			currentBlueTime = Time.time;
			newBlueBubble.Add(Instantiate (newBlueBubble[newBlueBubble.Count - 1], new Vector3 (initialBlueBubblePos.x, initialBlueBubblePos.y + randomYOffset(), initialBlueBubblePos.z), Quaternion.identity) as GameObject);
			newBlueBubble[newBlueBubble.Count-1].name = "BlueBubble" + newBlueBubble.Count;
		}
	}

	void createNewRedBubble() {
		if (Time.time - currentRedTime > timeForNewRedBubble) {
			currentRedTime = Time.time;
			newRedBubble.Add(Instantiate (newRedBubble[newRedBubble.Count - 1], new Vector3 (initialRedBubblePos.x, initialRedBubblePos.y + randomYOffset(), initialRedBubblePos.z), Quaternion.identity) as GameObject);
			newRedBubble[newRedBubble.Count-1].name = "RedBubble" + newRedBubble.Count;
		}
	}

	void createNewBlackBubble() {
		if (Time.time - currentBlackTime > timeForNewBlackBubble) {
			currentBlackTime = Time.time;
			newBlackBubble.Add(Instantiate (newBlackBubble[newBlackBubble.Count - 1], new Vector3 (initialBlackBubblePos.x, initialBlackBubblePos.y + randomYOffset(), initialBlackBubblePos.z), Quaternion.identity) as GameObject);
			newBlackBubble[newBlackBubble.Count-1].name = "BlackBubble" + newBlackBubble.Count;
		}
	}

	void createNewGreenBubble() {
		if (Time.time - currentGreenTime > timeForNewGreenBubble) {
			currentGreenTime = Time.time;
			newGreenBubble.Add(Instantiate (newGreenBubble[newGreenBubble.Count - 1], new Vector3 (initialGreenBubblePos.x, initialGreenBubblePos.y + randomYOffset(), initialGreenBubblePos.z), Quaternion.identity) as GameObject);
			newGreenBubble[newGreenBubble.Count-1].name = "GreenBubble" + newGreenBubble.Count;
		}
	}

	float randomYOffset() {
		return Random.Range (-4f, 4f);
	}

	IEnumerator removeNullElsFromList(List<GameObject> list) {
		yield return new WaitForSeconds(30.0f);
		list.RemoveAll(item => item == null);
	}
}
