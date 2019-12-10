using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using System.Threading;

public class SocketProcess : MonoBehaviour
{
    public Text timeCounter;
    public Text HedefIP;
    public GameObject arayuz;
    public Transform Ben;
    public Transform Rakip;
    private Vector3 BenPosizyon;
    public GameObject ip;
    public GameObject katil;


    private StreamReader sr;
    private StreamWriter sw;

    private bool gameIsStart = false;

    private string rakipKonum = "";

    void Start()
    {
        Time.timeScale = 0.0f;
        timeCounter.text = "Oyun kurun ya da oyuna katılın.";
    }
   
    public void OyunKur()
    {
        Time.timeScale = 1.0f;
        Thread t = new Thread(OyunKur_Load);
        t.Start();
        arayuz.SetActive(false);
       
    }

    private async void OyunKur_Load()
    {
       
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        TcpListener _tcpListener = new TcpListener(ip, 8080);
        _tcpListener.Start();
        
        Socket socket = _tcpListener.AcceptSocket();

        NetworkStream ns = new NetworkStream(socket);

        sr = new StreamReader(ns, Encoding.UTF8);
        sw = new StreamWriter(ns, Encoding.UTF8);

        sw.WriteLine("START_GAME");
        sw.Flush();


        int frameCount = 0;
        while (true)
        {
            if (frameCount > 50)
            {
                rakipKonum = await sr.ReadLineAsync();
                string[] rakipKnm = rakipKonum.Split(':');
                if (rakipKnm.Length == 2)
                {
                    Debug.Log(rakipKnm);
                    Vector3 yeniKonum = new Vector3(float.Parse(rakipKnm[0]), Rakip.position.y, float.Parse(rakipKnm[1]));
                    Rakip.position = yeniKonum;
                }

                string benPozisyon = BenPosizyon.x + ":" + BenPosizyon.z;
                sw.WriteLine(benPozisyon);
                sw.Flush();

                frameCount = 0;
            }
            frameCount += 1;
            
        }
        Debug.Log("Bittiii");
    }

    private async void OyunKatil_Load()
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream stream;

        try
        {
            tcpClient.Connect(HedefIP.text, 8080);
            stream = tcpClient.GetStream();

            sr = new StreamReader(stream, Encoding.UTF8);
            sw = new StreamWriter(stream, Encoding.UTF8);

        }
        catch (Exception e)
        {
            //EditorUtility.DisplayDialog("HATA", "Socket bağlantısı kurulamadı, karşıdaki oyuncunun oyunu başlattığından emin olun ve doğru ip'yi girin. \nSistem hata mesajı: " + e.Message, "Tamam");
            Debug.Log(e);
            throw;
        }
        Time.timeScale = 1.0f;
        int frameCount = 0;
        while (true)
        {
            if (frameCount > 50)
            {
                if (sw == null)
                    continue;
                string benPozisyon = BenPosizyon.x + ":" + BenPosizyon.z;
                sw.WriteLine(benPozisyon);
                sw.Flush();
                rakipKonum = await sr.ReadLineAsync();
                string[] rakipKnm = rakipKonum.Split(':');
                if (rakipKnm.Length == 2)
                {
                    Vector3 yeniKonum = new Vector3(float.Parse(rakipKnm[0]), Rakip.position.y, float.Parse(rakipKnm[1]));
                    Rakip.position = yeniKonum;
                }
                frameCount = 0;
            }
            frameCount += 1;

        }
        Debug.Log("Bittiii");
    }

    public void OyunaKatil()
    {
        ip.SetActive(true);
        katil.SetActive(true);
        
    }
    public void Baglan()
    {
        OyunKatil_Load();
        arayuz.SetActive(false);
    }

    int frameCount = 0;
    void Update()
    {
        if (frameCount > 30)
        {
            BenPosizyon = Ben.position;

            frameCount = 0;
        }
        frameCount += 1;
    }
}
