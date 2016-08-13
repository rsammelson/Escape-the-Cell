using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	private float Horizontal;
	private float Vertical;

	private Vector3 moveV;
	private Vector3 moveH;

	private int i = 100;

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

			Quaternion newRotation = transform.rotation * Quaternion.Euler (moveV);
			float angleDiff = Quaternion.Angle (newRotation, new Quaternion (0.5f, 0f, 0f, 0.5f));
//			if (Vertical < 0 && ) {
//
//			}

			moveV = new Vector3 (Vertical * -1, 0);
			moveH = new Vector3 (0, Horizontal, 0);

//			if (transform.rotation.y == newRotation.y) {
			transform.Rotate (moveV);
//			}
			transform.Rotate (moveH, Space.World);

			print (angleDiff);
		}
	}
}
