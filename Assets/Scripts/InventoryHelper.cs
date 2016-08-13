using UnityEngine;
using System.Collections;

public class InventoryHelper : MonoBehaviour
{
	public GameObject Inventory;

	private bool done = false;

	// Use this for initialization
	void Start ()
	{
		Inventory.SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (done == false) {
			done = true;
			Inventory.SetActive (false);
		}
	}
}
