using Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectSocket : MonoBehaviour
{
    SimpleClient sc;
    public Transform mainPlayer;
    void Start()
    {
        sc = new SimpleClient();

        if (sc.Connect("127.0.0.1", 1337))
        {
            //sc.Run();
            Console.WriteLine("Client Started");
        }
        else
        {
            Console.WriteLine("Client failed to connect!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sc.writer.WriteLine(mainPlayer.transform.position.x);
    }
}
