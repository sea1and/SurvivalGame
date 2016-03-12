using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    Text text;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        int gold = GoldManager.gold;
        int level = LevelManager.level;
        int currentexp = LevelManager.currentExp;
        File.WriteAllText("Save.txt", gold + Environment.NewLine + level + Environment.NewLine +  currentexp);
        text.text = "Game saved!(maybe)";
    }

    public void LoadGame()
    {
        Application.LoadLevel(1);
        FileStream file1 = new FileStream("Save.txt", FileMode.Open); //создаем файловый поток
        StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком 
        GoldManager.gold = int.Parse(reader.ReadLine());
        LevelManager.level = int.Parse(reader.ReadLine());
        LevelManager.currentExp = int.Parse(reader.ReadLine());
    }

    public void DeleteSave()
    {

    }
}
