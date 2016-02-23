using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void NewGame()
    {
        Application.LoadLevel(1);
    }
    /*public void Button
    {

    }
    public void button1
    {

    }*/
    public void ExitGame()
    {
        Application.Quit();
    }
}
