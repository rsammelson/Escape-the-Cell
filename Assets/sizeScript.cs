using UnityEngine;
using System.Collections;

public class sizeScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		setScreenSize ();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		setScreenSize ();
	}

	void setScreenSize ()
	{
		float w = Screen.width;
		float h = Screen.height;

		Vector2 size = new Vector2 (w - 50, h - 50);

		RectTransform rectTransform = GetComponent<RectTransform> ();
		rectTransform.sizeDelta = size;
	}
}
