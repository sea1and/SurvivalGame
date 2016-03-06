using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;

public struct quest
{
    public int id;
    public int multiplier;
    public int difficulty;
    public string text;

    public quest(int id, int multiplier, int difficulty, string text)
    {
        this.id = id;
        this.multiplier = multiplier;
        this.difficulty = difficulty;
        this.text = text;
    }
}

public class QuestManager : MonoBehaviour
{
    private static int SlonCounter = 0;
    private static int PinkCounter = 0;
    private static int GreenCounter = 0;
    private Text outText;
    private static int currentCounter = 0;
    private static quest currentQuest;
    private static string fulltext = "no";
    static AudioSource questCompleteAudio;
    quest elephants = new quest(0, 1, 1, "Monsters to be killed: elephants");
    quest pink = new quest(1, 3, 1, "Monsters to be killed: pink zombie");                //вторая цифра - множитель
    quest green = new quest(2, 3, 1, "Monsters to be killed: green zombie");

    public static void EnemyKilled(int type) // 0-slon, 1-pink, 2-green
    {
        if (type == 0)
        {
            SlonCounter++;
            if (currentQuest.id == 0) currentCounter++;
        }
        else if (type == 1)
        {
            PinkCounter++;
            if (currentQuest.id == 1) currentCounter++;
        }
        else if (type == 2)
        {
            GreenCounter++;
            if (currentQuest.id == 2) currentCounter++;
        }
        if (currentCounter >= currentQuest.multiplier * currentQuest.difficulty)
        {
            QuestComplete();
        }
        else fulltext = currentQuest.text + "(" + currentCounter + " / " + currentQuest.multiplier * currentQuest.difficulty + ")";
    }

    public static void QuestComplete()
    {
        currentCounter = 0;
        currentQuest.difficulty++;
        questCompleteAudio.Play();
        LevelManager.TakeExp(currentQuest.difficulty*50);
        //nextQuest();
    }

    public static void Zeroing()
    {
        SlonCounter = 0;
        PinkCounter = 0;
        GreenCounter = 0;
    }

    public void nextQuest()
    {
        if (currentQuest.id == 0) currentQuest = pink;
        if (currentQuest.id == 1) currentQuest = green;
        if (currentQuest.id == 2) currentQuest = elephants;
    }

    void Start () {
        outText = GetComponent<Text>();
        questCompleteAudio = GetComponent<AudioSource>();
        currentQuest = elephants;
        fulltext = currentQuest.text + "(" + currentCounter + " / " + currentQuest.multiplier * currentQuest.difficulty + ")";
    }

    void Update ()
	{
	    outText.text = fulltext;
	}
}