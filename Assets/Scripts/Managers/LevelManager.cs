using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static int currentExp = 0;
    public static int level = 1;
    public static int currentHealth;
    static GameObject player;
    static PlayerHealth playerHealth;

    static Slider expSlider;
    static Slider healthSlider;
    static Text levelText;
    static AudioSource lvlupAudio;

    public static void TakeExp(int count)
    {
        currentExp += count;
        if (currentExp >= level * 100)
        {
            currentExp = currentExp - level * 100;
            level += 1;
            // playerHealth.currentHealth = playerHealth.startingHealth;
            //healthSlider.value = currentHealth;
            playerHealth.RestoreHP(100);
            lvlupAudio.Play();
        }
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
    }
}
