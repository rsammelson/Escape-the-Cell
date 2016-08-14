using UnityEngine;
using System.Collections;

public class CloseInventory : MonoBehaviour
{
	public GameObject mainCanvas;
	public GameObject messageCanvas;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void Close ()
	{
		GameObject mainCamera = GameObject.Find ("Main Camera");
		ClickDetector clickDetector = mainCamera.GetComponent<ClickDetector> ();

		mainCanvas.SetActive (true);
		messageCanvas.SetActive (true);

		clickDetector.onInventory (false);

		this.gameObject.SetActive (false);
	}
}
