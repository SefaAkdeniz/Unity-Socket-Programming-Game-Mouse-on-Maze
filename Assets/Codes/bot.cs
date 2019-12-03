using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class bot : MonoBehaviour
{
    public Text finishText;
    public GameObject backMenu;
    NavMeshAgent agent;
    public Transform cheese;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


        agent.destination = cheese.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        finishText.text = "OYUN BİTTİ BİLGİSAYAR KAZANDI";
        Time.timeScale = 0.0f;
        backMenu.SetActive(true);
    }
}
