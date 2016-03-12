using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldManager : MonoBehaviour
{
    public static int gold = 0;

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
