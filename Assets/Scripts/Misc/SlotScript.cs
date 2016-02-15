using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler {

	public Item item;
	Image itemImage;
	public int slotNumber;
	Inventory inventory;

	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		itemImage = gameObject.transform.GetChild(0).GetComponent<Image> ();

	}
	

	void Update () {
		if (inventory.Items[slotNumber].itemName != null) {
			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;
		} 
		else {
			itemImage.enabled = false;
		}
	}

	public void OnPointerDown(PointerEventData data) {
		Debug.Log (transform.name);
	}

	public void OnPointerEnter(PointerEventData data) {
		Debug.Log ("Mouseover");
	}
}
