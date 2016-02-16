using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start () {
		items.Add (new Item ("crimson_guard", 0, "The best armor", 10, 10, 1, Item.ItemType.Chest));
		items.Add (new Item ("energy_booster", 1, "Amazing stone", 10, 10, 1, Item.ItemType.Consumable));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
