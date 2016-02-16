/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerPickUpManager : MonoBehaviour {

	public Inventory inv;

	void Awake() {
	}

	void Update() {
		List<GameObject> ItemsList = GameObject.FindGameObjectsWithTag("Loot");
		for (int i = 0; i < ItemsList.Count; i++) {
			Vector3 vec;
			vec = gameObject.transform.position - ItemsList [i].transform.position;
			if (((vec.x) ^ 2 + (vec.y) ^ 2 + (vec.z) ^ 2) ^ (1 / 2) <= 5) {
				inv.addItemAtEmptySlot ();
			}
		}

	}

}
*/