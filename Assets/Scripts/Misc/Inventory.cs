using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject> ();
	public List<Item> Items = new List<Item>();
	public GameObject slots;
	ItemDatabase database;
	public GameObject tooltip;
	int x = -90;
	int y = 80;

	void Start () {

		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
		int slotamount = 0;

		for (int i = 1; i < 5; i++) {
			for (int j = 1; j < 5; j++) {
				GameObject slot = (GameObject)Instantiate (slots);
				slot.GetComponent<SlotScript> ().slotNumber = slotamount;
				Slots.Add (slot);
				Items.Add(new Item());

				slot.transform.parent = this.gameObject.transform;
				slot.name = "Slot" + i + "." + j;
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x += 60;
				if (j == 4 ) {
					x = -90;
					y -= 55;
				}
				slotamount++;
			}
		}

		addItem (0);
		addItem (1);
	}

	void addItem(int id) {
		for (int i = 0; i < database.items.Count; i++) {
			if (database.items[i].itemID == id) {
				Item item = database.items[i];
				addItemAtEmptySlot(item);
				break;
			}
		}
	}

	void addItemAtEmptySlot(Item item) {
		for (int i = 0; i < Items.Count; i++) {
			if (Items [i].itemName == null) {
				Items [i] = item;
				break;
			}
		}
	}

	public void ShowTooltip(Vector3 toolPosition, Item item) {
		tooltip.GetComponent<RectTransform> ().localPosition = new Vector3 (toolPosition.x + 245, toolPosition.y, toolPosition.z);
		tooltip.SetActive (true);

		tooltip.transform.GetChild (0).GetComponent<Text>().text = item.itemName;
		tooltip.transform.GetChild (2).GetComponent<Text>().text = item.itemDesc;
	}

	public void closeTooltip() {
		tooltip.SetActive (false);
	}
}
