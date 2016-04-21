using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldManager : MonoBehaviour
{

    public static GoldManager Instance;
    public int gold;
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