using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public Text Notify1;
    public Text Notify2;
    public Text Notify3;

    public void Notify(string s)
    {
        Notify3.text = Notify2.text;
        Notify2.text = Notify1.text;
        Notify1.text = s;
    }
	void Start ()
    {
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Notify("232");
        }
    }
}
