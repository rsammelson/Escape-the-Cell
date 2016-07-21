using UnityEngine;
using System.Collections;

public class Inventory_Slot_Placer : MonoBehaviour
{
	private Vector2 screenSize;
	private Vector2 lastScreenSize;

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
		int x = (int)(sizeOfScreen.x - 100);
		int y = (int)(sizeOfScreen.y - 100);

		print (x);
		print (y);
	}

	public static int Slots (int sizeOfArea, int sizeOfObject, int spaceBetween)
	{
		int a = sizeOfArea;
		int s = sizeOfObject;
		int b = spaceBetween;

		int i = s + b;

		int aR;

		int n;

		if (((s * 2) + b) >= a) {
			n = 2;
			aR = a - ((s * 2) + b);

			while (aR >= i) {
				n += 1;
				aR = aR - i;
			}
		}

		return n;
	}
}
