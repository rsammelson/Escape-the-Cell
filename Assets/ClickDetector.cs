using UnityEngine;
using System.Collections;

public class ClickDetector : MonoBehaviour
{
	public GameObject hitObject;
	public string hitName;
	public bool wasHit = false;

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
		} else {
			wasHit = false;
			hitName = null;
			hitObject = null;
		}
	}
}
