using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour
{
	public int id;
	public int idOfObjectToClickWith;

	public string correctMessage;
	public string incorrectMessage;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnThisObjectClicked (int clickedWithId)
	{
		if (clickedWithId == idOfObjectToClickWith) {
			print (correctMessage);
		} else {
			print (incorrectMessage);
		}
	}
}
