using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickUpManager : MonoBehaviour {


	public GameObject canv;
	public AudioClip PickUpClip;
	Inventory inv;
	GameObject player;
	AudioSource PickUpSound;
	GameObject[] ItemsList;

	void Awake() {
		PickUpSound = gameObject.GetComponent<AudioSource> ();
		PickUpSound.clip = PickUpClip;
		player = GameObject.FindGameObjectWithTag ("Player");
		inv = canv.GetComponent<Inventory>();
	}
    public void PickUp(GameObject item) {
        Destroy(item);
        inv.addItem(item.GetComponent<LootType>().LootID);
        PickUpSound.Play();
    }
	void Update() {
		
	}

}
