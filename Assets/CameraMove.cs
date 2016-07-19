using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	private float Horizontal;
	private float Vertical;

	private Vector3 move;

	// Use this for initialization
	void Start ()
	{
		Horizontal = 0;
		Vertical = 0;

		move = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Horizontal = Input.GetAxis ("Horizontal");
		Vertical = Input.GetAxis ("Vertical");

		move = new Vector3 (Vertical * -1, Horizontal, 0);

		transform.Rotate (move);
	}
}
