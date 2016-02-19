using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerClickHandler {

	public Item item;
	Image itemImage;
	public int slotNumber;
	Inventory inventory;
	Text itemAmount;
	GameObject player;
	PlayerHealth playerHealth;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		itemImage = gameObject.transform.GetChild(0).GetComponent<Image> ();
		itemAmount = gameObject.transform.GetChild (1).GetComponent<Text> ();
	}
	 

	void Update () {

		if (inventory.Items[slotNumber].itemName != null) {
			item = inventory.Items[slotNumber];
			itemAmount.enabled = false;
			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;

			if (inventory.Items [slotNumber].itemType == Item.ItemType.Consumable) {
				itemAmount.enabled = true;
				itemAmount.text = "" + inventory.Items [slotNumber].itemValue;
			}
		} 
		else {
			itemImage.enabled = false;
		}
	}

	public void OnDrop (PointerEventData data) {
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
			itemAmount.enabled = false;
		}
	}

	public void OnPointerClick(PointerEventData data) {
			if (inventory.Items [slotNumber].itemType == Item.ItemType.Consumable) {
				inventory.Items [slotNumber].itemValue--;
				playerHealth.RestoreHP (inventory.Items [slotNumber].itemDefense);
				if (inventory.Items [slotNumber].itemValue <= 0) {
					inventory.Items [slotNumber] = new Item ();
					itemAmount.enabled = false;
					inventory.closeTooltip ();
				}
			}
	}

}
