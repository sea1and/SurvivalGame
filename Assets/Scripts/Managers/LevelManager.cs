using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int currentExp = 0;
    public int level = 1;
    public int currentHealth;
    GameObject player;
    PlayerHealth playerHealth;
    public NotificationManager notificationManager;
    public PlayerStats playerStats;
    Slider expSlider;
    Text levelText;
    public Text SliderText;
    AudioSource lvlupAudio;
    public void TakeExp(int count)
    {
        currentExp += count;
        if (currentExp >= level * 100)
        {
            levelup();
        }
    }

    public void levelup()
    {
        currentExp = currentExp - level * 100;
        level++;
        playerHealth.currentHealth = playerHealth.maxHealth;
        lvlupAudio.Play();
        notificationManager.Notify("Level "+level+"!");
        playerStats.levelScore++;
    }

    void Start()
    {
        lvlupAudio = gameObject.GetComponent<AudioSource>();
        expSlider = transform.GetChild(0).GetComponent<Slider>();
        levelText = transform.GetChild(1).GetComponent<Text>();
        expSlider.value = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        expSlider.maxValue = level * 100;
        expSlider.value = currentExp;
        levelText.text = level.ToString();
        SliderText.text = currentExp +"/"+ level * 100;
    }
}
