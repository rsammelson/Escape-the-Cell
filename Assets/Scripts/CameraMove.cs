using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	private float Horizontal;
	private float Vertical;

	private Vector3 moveV;
	private Vector3 moveH;

	// Use this for initialization
	void Start ()
	{
		Horizontal = 0;
		Vertical = 0;

		moveV = new Vector3 (0, 0, 0);
		moveH = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		ClickDetector clickDetector = GetComponent<ClickDetector> ();
		if (!clickDetector.inventoryIsEnabled) {
			Horizontal = Input.GetAxis ("Horizontal");
			Vertical = Input.GetAxis ("Vertical");

			moveV = new Vector3 (Vertical * -1, 0);
			moveH = new Vector3 (0, Horizontal, 0);

			transform.Rotate (moveV);
			transform.Rotate (moveH, Space.World);
		}
	}
}
