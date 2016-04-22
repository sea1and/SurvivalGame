using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    
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
        GoldManager.Instance.currentExp += count;
        if (GoldManager.Instance.currentExp >= GoldManager.Instance.level * 100)
        {
            levelup();
        }
    }

    public void levelup()
    {
        // вместо level юзать  GoldManager.Instance.level и GoldManager.Instance.currentExp
        GoldManager.Instance.currentExp = GoldManager.Instance.currentExp - GoldManager.Instance.level * 100;
        GoldManager.Instance.level++;
        playerHealth.currentHealth = playerHealth.maxHealth;
        lvlupAudio.Play();
        notificationManager.Notify("Level "+ GoldManager.Instance.level + "!");
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
        expSlider.maxValue = GoldManager.Instance.level * 100;
        expSlider.value = GoldManager.Instance.currentExp;
        levelText.text = GoldManager.Instance.level.ToString();
        SliderText.text = GoldManager.Instance.currentExp + "/"+ GoldManager.Instance.level * 100;
    }
}
