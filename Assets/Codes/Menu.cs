using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void HumanVsHuman()
    {  
        SceneManager.LoadScene("HumanVsHuman"); ;
    }
    public void HumanVsAI()
    {
        SceneManager.LoadScene("HumanVsAI"); ;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
