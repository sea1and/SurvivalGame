using UnityEngine;
using System;
using System.Collections;
using System.Timers;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class RemoveSlotScript : MonoBehaviour, IDropHandler /* , IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerClickHandler */ {

    public Inventory inventory;
    
    public GameObject Loot;

    public void Start() {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData data)
    {
        if (inventory.draggingItem)
        {
            Vector3 PlayerPosition = GameObject.FindWithTag("Player").transform.position;

            GameObject tmp = (GameObject)Instantiate(Loot, PlayerPosition + new Vector3(SmartRand(), 0.7f, SmartRand()), Quaternion.identity);
            tmp.GetComponent<LootType>().LootID = inventory.draggedItem.itemID;
            tmp.GetComponent<LootType>().Value = inventory.draggedItem.itemValue;
            inventory.closeDraggedItem();
        }

    }

    float SmartRand()
    {
        float rand = UnityEngine.Random.Range(-1.5f, 1.5f);
        while (Mathf.Abs(rand) < 0.3f)
        {
            rand = UnityEngine.Random.Range(-1.5f, 1.5f);
        }
        return rand;
    }
}

