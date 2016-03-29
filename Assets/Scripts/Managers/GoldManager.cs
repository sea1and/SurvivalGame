using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldManager : MonoBehaviour
{
    public int gold = 0;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
    }

    void Update ()
    {
        text.text = "Gold: " + gold;
    }
}
