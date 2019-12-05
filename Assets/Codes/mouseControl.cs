﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mouseControl : MonoBehaviour
{
    public Text finishText;
    public GameObject backMenu;
    int speed = 2;
    void Update()
    {

        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere*1.5f);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);         
        }       

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, 0, -1 * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);          
        }         

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        finishText.text = "OYUN BİTTİ SEN KAZANDIN" ;
        Time.timeScale = 0.0f;
        backMenu.SetActive(true);
    }
}