using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class bot : MonoBehaviour
{
    public Text FinishText;
    public Text time;
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
        FinishText.text = "Bilgisayar Kazandı" + time.text + "Second";
        time.text = "";
    }
}
