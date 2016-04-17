using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    public void NewGame()
    {
		SceneManager.LoadScene ("MainScene");
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
