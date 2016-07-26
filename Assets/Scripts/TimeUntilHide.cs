using UnityEngine;
using System.Collections;

public class TimeUntilHide : MonoBehaviour
{
	public float timeUnhid;

	private float timeSinceUnhid;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeSinceUnhid = Time.realtimeSinceStartup - timeUnhid;
		if (timeSinceUnhid > 3) {
			this.gameObject.SetActive (false);
		}
	}
}
