using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory_Slot_Placer : MonoBehaviour
{
	private Vector2 screenSize;
	private Vector2 lastScreenSize;

	private int[,] map;

	private List<GameObject> objectsMade;

	public Object prefab;

	// Use this for initialization
	void Start ()
	{
		screenSize = new Vector2 (Screen.width, Screen.height);
		lastScreenSize = new Vector2 (Screen.width, Screen.height);

		PlaceInventorySlots (screenSize);
	}
	
	// Update is called once per frame
	void Update ()
	{
		screenSize = new Vector2 (Screen.width, Screen.height);

		if (screenSize != lastScreenSize) {
			PlaceInventorySlots (screenSize);
		}

		lastScreenSize = screenSize;
	}

	void PlaceInventorySlots (Vector2 sizeOfScreen)
	{
		GameObject Slot1 = GameObject.Find ("InventorySlot");

//		Slot1.SetActive (false);

//		foreach (GameObject thingToDestroy in objectsMade) {
//			Destroy (thingToDestroy);
//		}

		objectsMade = new List<GameObject> ();

		int x = (int)(sizeOfScreen.x - 100);
		int y = (int)(sizeOfScreen.y - 100);

		print (x);
		print (y);

		int numX = Slots (x, 75, 25);
		int numY = Slots (y, 115, 25);

		print ("Number of slots Horizontally: " + numX);
		print ("Number of slots Vertically: " + numY);

		for (int iX = 0; iX < numX; iX++) {
			print ("x");
			for (int iY = 0; iY < numY; iY++) {
				if (iX == 0 && iY == 0) {
//					Slot1.SetActive (true);
				} else {
//					Instantiate (prefab, SlotLocation (), new Quaternion (0, 0, 0, 0));
					print (iX);
					print (iY);
				}
			}
		}
	}

	public static int Slots (int sizeOfArea, int sizeOfObject, int spaceBetween)
	{
		int a = sizeOfArea;
		int s = sizeOfObject;
		int b = spaceBetween;

		int i = s + b;

		int aR;

		int n;

		if (a >= ((s * 2) + b)) {
			n = 2;
			aR = a - ((s * 2) + b);

			while (aR >= i) {
				n += 1;
				aR = aR - i;
			}
		} else if (a >= s) {
			n = 1;
		} else {
			n = 0;
		}

		return n;
	}

	public static Vector3 SlotLocation ()
	{
		return new Vector3 (0, 0, 0);
	}
}
