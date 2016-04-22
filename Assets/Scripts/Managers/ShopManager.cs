using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour
{

    public GameObject shop;
    public Inventory inv;
    RaycastHit hit;
    public bool shopOpen;
    // public GoldManager goldManager;

    void Start()
    {
        shopOpen = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            gameObject.GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && !shopOpen)
        {
            shopOpen = true;
            showMenu();
        }
    }

    void showMenu()
    {
        shop.SetActive(true);
    }

    public void closeMenu()
    {
        shopOpen = false;
        shop.SetActive(false);
    }

   
    public void buyRapier()
    {
        if (GoldManager.Instance.gold >= 1000)
        {
            GoldManager.Instance.gold -= 1000;
            inv.addItem(2);
        }
    }

    public void buyHP()
    {
        if (GoldManager.Instance.gold >= 300)
        {
            GoldManager.Instance.gold -= 300;
            inv.addItem(1);
        }
    }

    public void buyArmor()
    {
        if (GoldManager.Instance.gold >= 1000)
        {
            GoldManager.Instance.gold -= 1000;
            inv.addItem(0);
        }
    }
}