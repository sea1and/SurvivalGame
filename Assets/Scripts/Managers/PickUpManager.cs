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

	void Update() {
		ItemsList = GameObject.FindGameObjectsWithTag("Loot");
	
		if (ItemsList != null) {
			for (int i = 0; i < ItemsList.Length; i++) {
				if (ItemsList [i] != null) {
					Vector3 vec;
					vec = player.transform.position - ItemsList [i].transform.position;
					if (vec.magnitude <= 1) {
						Destroy (ItemsList [i]);
						inv.addItem(ItemsList[i].GetComponent<LootType>().LootID);
						PickUpSound.Play ();
					}
				}
			}
		}
	}

}
