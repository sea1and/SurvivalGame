using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public LevelManager levelManager;
    // public GoldManager goldManager;
    public NotificationManager notificationManager;

    private void Start()
    {
    }

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
        int gold = GoldManager.Instance.gold;
        int level = levelManager.level;
        int currentexp = levelManager.currentExp;
        File.WriteAllText("Save.txt", gold + Environment.NewLine + level + Environment.NewLine + currentexp);
        notificationManager.Notify("Game Saved!");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FileStream file1 = new FileStream("Save.txt", FileMode.Open); //создаем файловый поток
        StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком 
        GoldManager.Instance.gold = int.Parse(reader.ReadLine());
        levelManager.level = int.Parse(reader.ReadLine());
        levelManager.currentExp = int.Parse(reader.ReadLine());
    }
}