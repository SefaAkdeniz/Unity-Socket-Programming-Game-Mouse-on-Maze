using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeControl : MonoBehaviour
{
    public float time;
    public Text TimeText;

    void Start()//İSMAİL SEFA AKDENİZ
    {
        TimeText.text = time.ToString("0");     
    }

    void Update()
    {
            time += Time.deltaTime;
            PlayerPrefs.SetFloat("Zaman", time);
            TimeText.text = time.ToString("0");      
    }
}
