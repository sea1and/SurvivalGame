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

    Slider expSlider;
    Slider healthSlider;
    Text levelText;
    AudioSource lvlupAudio;

    public void TakeExp(int count)
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
