using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnClick : MonoBehaviour
{
	public int id;
	public int idOfObjectToClickWith;

	public string correctMessage;
	public string incorrectMessage;

	public GameObject slots;

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
			CollectObject ();
		} else {
			print (incorrectMessage);
		}
	}

	public void CollectObject ()
	{
		Inventory_Slot_Placer inventory_Slot_Placer = slots.GetComponent<Inventory_Slot_Placer> ();
		List<GameObject> availableSlots = inventory_Slot_Placer.objectsMade;
		GameObject slotToFill = availableSlots [0];
		availableSlots.RemoveAt (0);

		slotToFill.SetActive (true);

		fillSlotWithData ();

		Destroy (gameObject);
	}

	void fillSlotWithData ()
	{
	}
}
