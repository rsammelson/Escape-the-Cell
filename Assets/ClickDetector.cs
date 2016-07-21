﻿using UnityEngine;
using System.Collections;

public class ClickDetector : MonoBehaviour
{
	public GameObject hitObject;
	public string hitName;
	public bool wasHit = false;

	public bool inventoryIsEnabled;

	// Use this for initialization
	void Start ()
	{
		wasHit = false;
		hitName = null;
		hitObject = null;
	}

	// Update is called once per frame
	void Update ()
	{
		if (!inventoryIsEnabled) {
			clickDetection ();
		}
	}

	// ----------------------------------------------------------------------------------------------------

	public void clickDetection ()
	{
		// Get the ray going through the GUI position
		Vector2 v2ScreenCenter = new Vector2 (Screen.width / 2, Screen.height / 2);
		// Vector3 v3ScreenCenter = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = Camera.main.ScreenPointToRay (v2ScreenCenter);
		// Do a raycast
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			wasHit = true;
			hitName = hit.transform.name;
			hitObject = hit.collider.gameObject;

			if (wasClicked ()) {
				if (hitObject.tag == "clickable") {
					OnClick onClick = hitObject.GetComponent<OnClick> ();

					int id = onClick.id;
					print ("clicked: " + id);

					onClick.OnThisObjectClicked (0);
				}
			}
		} else {
			wasHit = false;
			hitName = null;
			hitObject = null;
		}
	}

	// ----------------------------------------------------------------------------------------------------

	public static bool wasClicked ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePos = Input.mousePosition;
			float screenWidth = Screen.width;

			float x = mousePos.x;
			float y = mousePos.y;

			float buttonWidth = 100;
			float buttonHeight = 75;

			bool inWidth = (x < screenWidth) && (x > (screenWidth - buttonWidth));
			bool inHeight = (y > 0) && (y < buttonHeight);

			if (inWidth && inHeight) {
				return false;
			} else {
				return true;
			}
		} else {
			return false;
		}
	}

	public void onInventory (bool enabled)
	{
		if (enabled) {
			inventoryIsEnabled = true;
		} else {
			inventoryIsEnabled = false;
		}
	}
}
