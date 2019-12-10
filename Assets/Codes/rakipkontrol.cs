using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rakipkontrol : MonoBehaviour
{
    public Text FinishText;
    public GameObject GOfinishText;
    public Text time;
    public GameObject backMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "peynir") {
            Debug.Log(other.tag);
            GOfinishText.SetActive(true);
            FinishText.text = "OYUN BİTTİ RAKİP KAZANDI";
            Time.timeScale = 0.0f;
            backMenu.SetActive(true);
        }
    }
}
