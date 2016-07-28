using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory_Slot_Placer : MonoBehaviour
{
	private Vector2 screenSize;
	private Vector2 lastScreenSize;

	private int[,] map;

	public List<GameObject> objectsMade;
	//	public List<InventorySlotInfo> filledSlotInfo;

	public GameObject firstSlot;

	private int xCorrection;
	private int yCorrection;

	public Object prefab;

	// Use this for initialization
	void Start ()
	{
		screenSize = new Vector2 (Screen.width, Screen.height);
		lastScreenSize = new Vector2 (Screen.width, Screen.height);

		PlaceInventorySlots (screenSize, true);
		
		// -----

		Button slot1 = firstSlot.GetComponent<Button> ();
		GameObject mainCamera = GameObject.Find ("Main Camera");
		ClickDetector clickDetector = mainCamera.GetComponent<ClickDetector> ();
		GameObject inventory = this.gameObject.transform.parent.parent.gameObject;
		CloseInventory closeInventory = inventory.GetComponent<CloseInventory> ();

		slot1.onClick.AddListener (() => {
			clickDetector.objectInHandSet (0);
			closeInventory.Close ();
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
		screenSize = new Vector2 (Screen.width, Screen.height);

		if (screenSize != lastScreenSize) {
			PlaceInventorySlots (screenSize, false);
		}

		lastScreenSize = screenSize;
	}

	void PlaceInventorySlots (Vector2 sizeOfScreen, bool firstRun)
	{
//		GameObject Slot1 = GameObject.Find ("InventorySlot");

		firstSlot.SetActive (false);

//		if (!firstRun) {
		foreach (GameObject thingToDestroy in objectsMade) {
			Destroy (thingToDestroy);
		}
//		}

		objectsMade = new List<GameObject> ();

		GameObject thingMade;

		int width = 75;
		int height = 115;
		int horizontalSpacing = 20;
		int verticalSpacing = 25;

		int x = (int)(sizeOfScreen.x - ((horizontalSpacing * 2)) - 50);
		int y = (int)(sizeOfScreen.y - ((verticalSpacing * 2)) - 50);

		print (x);
		print (y);

		int numX = Slots (x, width, verticalSpacing, true);
		int numY = Slots (y, height, horizontalSpacing, false);

		print ("Number of slots Horizontally: " + numX);
		print ("Number of slots Vertically: " + numY);

		for (int iX = 0; iX < numX; iX++) {
			for (int iY = 0; iY < numY; iY++) {
				if (iX == 0 && iY == 0) {
					firstSlot.SetActive (true);
				} else {
					Vector3 locationOfSlot = SlotLocation (iX, iY, width, height, horizontalSpacing, verticalSpacing, xCorrection, yCorrection, numX, numY);
					thingMade = Instantiate (prefab, locationOfSlot, new Quaternion (0, 0, 0, 0)) as GameObject;
					thingMade.transform.SetParent (gameObject.transform, false);

					objectsMade.Add (thingMade);
				}
			}
		}
	}

	public int Slots (int sizeOfArea, int sizeOfObject, int spaceBetween, bool axisIsX)
	{
		int a = sizeOfArea;
		int s = sizeOfObject;
		int b = spaceBetween;

		int i = s + b;

		int aR = 0;

		int n;

		if (a >= s) {
			n = 1;
			aR = a - s;

			print ("i:" + i);

			while (aR >= (i + b)) {
				n += 1;
				aR = aR - i;
				print ("Important:" + aR);
			}
		} else {
			n = 0;
		}

		print ("I: " + aR);

		if (axisIsX) {
			xCorrection = (aR + 0) / (n - 1);
		} else {
			yCorrection = (aR + 0) / (n - 1);
		}

		return n;
	}

	public static Vector3 SlotLocation (int fromLeft, int fromTop, int width, int height, int horizontalSpacing, int verticalSpacing, int horizontalCorrection, int verticalCorrection, int xSlots, int ySlots)
	{
		Vector3 loc = new Vector3 (100, 2, 0);

		int hSpace = width + horizontalSpacing;
		int vSpace = height + verticalSpacing;

		loc.x += fromLeft * hSpace;
		loc.y -= (fromTop * vSpace);

		loc.x += fromLeft * horizontalCorrection;
		loc.y -= fromTop * verticalCorrection;

		return loc;
	}

	// Slot Filling ----------------------------------------------------------------------------------------------------

	//	void FillSlotsOnScreenChange ()
	//	{
	//		foreach (InventorySlotInfo slotData in filledSlotInfo) {
	//			FillSlotWithData (objectsMade [0], slotData.nameOfObject, slotData.idOfObject);
	//		}
	//	}
	//
	//	void FillSlotWithData (GameObject slotToBeFilled, string name, int idOfObject)
	//	{
	//		string nameOfSpriteAsset = name + "Sprite.jpg";
	//		string spritePath = "Assets/Sprites/" + nameOfSpriteAsset;
	//
	//		FillText (slotToBeFilled, name);
	//
	//		FillImage (slotToBeFilled, spritePath);
	//
	//		Button slotButton = slotToBeFilled.GetComponent<Button> ();
	//
	//		setId (slotButton, idOfObject);
	//	}
	//
	//	void FillText (GameObject fillSlot, string textToAdd)
	//	{
	//		GameObject textObject = fillSlot.transform.GetChild (0).gameObject;
	//		Text text = textObject.GetComponent<Text> ();
	//		text.text = textToAdd;
	//	}
	//
	//	void FillImage (GameObject fillSlot, string pathOfSprite)
	//	{
	//		Sprite sprite = AssetDatabase.LoadAssetAtPath (pathOfSprite, typeof(Sprite)) as Sprite;
	//
	//		GameObject imageObject = fillSlot.transform.GetChild (1).gameObject;
	//		Image image = imageObject.GetComponent<Image> ();
	//
	//		print (pathOfSprite);
	//		print (sprite);
	//
	//		image.sprite = sprite;
	//	}
	//
	//	void setId (Button fillSlot, int id)
	//	{
	//		GameObject mainCamera = GameObject.Find ("Main Camera");
	//		ClickDetector clickDetector = mainCamera.GetComponent<ClickDetector> ();
	//		fillSlot.onClick.AddListener (() => {
	//			clickDetector.objectInHandSet (id);
	//		});
	//	}

	// -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//	public struct InventorySlotInfo
	//	{
	//		public string nameOfObject;
	//		public int idOfObject;
	//
	//		public InventorySlotInfo (string name, int id)
	//		{
	//			nameOfObject = name;
	//			idOfObject = id;
	//		}
	//	}
}
