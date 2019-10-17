using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kontrol : MonoBehaviour
{
    int hiz = 2;
    void Update()
    {

        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere*1.5f);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, 0, hiz * Time.deltaTime);         
        }       

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, 0, -1 * hiz * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(hiz * Time.deltaTime, 0, 0);          
        }         

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-1 * hiz * Time.deltaTime, 0, 0);          
        }
    }
}