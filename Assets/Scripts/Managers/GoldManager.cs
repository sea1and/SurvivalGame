using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldManager : MonoBehaviour
{

    public static GoldManager Instance;
    public int gold;
    public int currentExp = 0;
    public int level = 1;

    void Awake()
    {
        if (null == Instance)
        {
            GameObject gam = gameObject;
            GameObject trams = transform.gameObject;
            DontDestroyOnLoad(gameObject);

            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }



    }

    void Update()
    {
    
    }
}