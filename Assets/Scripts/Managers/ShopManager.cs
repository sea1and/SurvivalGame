using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

	public GameObject shop;
	public Inventory inv;
	RaycastHit hit;
	public bool shopOpen;
    public GoldManager goldManager;

    void Start () {
			shopOpen = false;
	}

	void Update () {
		if(Input.GetMouseButtonDown(0) &&
			gameObject.GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && !shopOpen) {
			shopOpen = true;
			showMenu ();
		}
	}

	void showMenu() {
		shop.SetActive (true);
	}

	public void closeMenu() {
		shopOpen = false;
		shop.SetActive (false);
	}

	//долбаный костыль, но по другому не работает, Юнити не видит публичные функции
	//от двух переменных в граф. редакторе
	public void buyRapier() {
		if (goldManager.gold >= 1000) {
            goldManager.gold -= 1000;
			inv.addItem (2);
		}
	}

	public void buyHP() {
		if (goldManager.gold >= 300) {
            goldManager.gold -= 300;
			inv.addItem (1);
		}
	}

	public void buyArmor() {
		if (goldManager.gold >= 1000) {
            goldManager.gold -= 1000;
			inv.addItem (0);
		}
	}
}
	