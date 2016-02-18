using UnityEngine;
using System.Collections;

public class LootType : MonoBehaviour {

	public int LootID;

	void Start() {
		int randnum = Random.Range (0, 1);
		LootID = randnum;
	}
}
