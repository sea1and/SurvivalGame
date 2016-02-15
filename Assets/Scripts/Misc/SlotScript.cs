using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler {

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
			item = inventory.Items[slotNumber];
			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;
		} 
		else {
			itemImage.enabled = false;
		}
	}

	public void OnDrop(PointerEventData data) {
		if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
			inventory.Items [slotNumber] = inventory.draggedItem;
			inventory.closeDraggedItem();
		}
		else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null) {
			inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
			inventory.Items [slotNumber] = inventory.draggedItem;
			inventory.closeDraggedItem();
		}
	}

	public void OnPointerEnter(PointerEventData data) {
		if (inventory.Items[slotNumber].itemName != null && !inventory.draggingItem) {
			inventory.ShowTooltip (inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
		}
	}

	public void OnPointerExit(PointerEventData data) {
		if (inventory.Items [slotNumber].itemName != null) {
			inventory.closeTooltip (); 
		} 
	}

	public void OnDrag(PointerEventData data) {
		if (inventory.Items [slotNumber].itemName != null) {
			inventory.showDraggedItem (inventory.Items [slotNumber], slotNumber);
			inventory.Items [slotNumber] = new Item ();
		}
	}

}
