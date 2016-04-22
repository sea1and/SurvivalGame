using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
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
    public int SlonCounter = 0;
    public int PinkCounter = 0;
    public int GreenCounter = 0;
    public Text outText;
    public int currentCounter = 0;
    AudioSource questCompleteAudio;
    quest currentQuest;
    quest elephants = new quest(0, 1, 1, "Elephants killer");
    quest pink = new quest(1, 3, 1, "Pinks killer");                //вторая цифра - множитель
    quest green = new quest(2, 3, 1, "Greens killer");
    public NotificationManager notificationManager;
    public LevelManager levelManager;

    public void EnemyKilled(int type) // 0-slon, 1-pink, 2-green
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
        outText.text = currentQuest.text + "(" + currentCounter + " / " + currentQuest.multiplier * currentQuest.difficulty + ")";
    }

    public void QuestComplete()
    {
        currentCounter = 0;
        if (currentQuest.id == 0) elephants.difficulty++;
        else
        if (currentQuest.id == 1) pink.difficulty++;
        else
        if (currentQuest.id == 2) green.difficulty++;
        questCompleteAudio.Play();
        levelManager.TakeExp(currentQuest.difficulty * 50);
        nextQuest();
        notificationManager.Notify("Quest complete +" + currentQuest.difficulty * 50 + "xp");
    }

    public void Zeroing()
    {
        SlonCounter = 0;
        PinkCounter = 0;
        GreenCounter = 0;
    }

    public void nextQuest()
    {
        if (currentQuest.id == 0) currentQuest = pink;
        else
        if (currentQuest.id == 1) currentQuest = green;
        else
        if (currentQuest.id == 2) currentQuest = elephants;
        outText.text = currentQuest.text + "(" + currentCounter + " / " + currentQuest.multiplier * currentQuest.difficulty + ")";
    }

    void Start()
    {
        outText = GameObject.FindGameObjectWithTag("QuestText").GetComponent<Text>();
        questCompleteAudio = GameObject.FindGameObjectWithTag("QuestText").GetComponent<AudioSource>();
        currentQuest = elephants;
        outText.text = currentQuest.text + "(" + currentCounter + " / " + currentQuest.multiplier * currentQuest.difficulty + ")";
    }

    void Update()
    {
    }
}