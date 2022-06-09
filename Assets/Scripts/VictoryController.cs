using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{

    public static bool win;
    
    public MyTimer myTimer;
    public GameObject winUI;

    private void Start()
    {
        winUI.SetActive(false);
    }

    // esse method eh chamado quando um obj deixa o colisor
    private void OnTriggerExit(Collider other)
    {
        // checa se oq saiu foi o player e n uma esfera,
        // checa pela tag q coloquei no player
        if (other.tag.Equals("player"))
        {
            myTimer.StopCounting();
            winUI.SetActive(true);
            win = true;
        }
    }

    // ta sendo chamada pelo onCLick do botao de reset no editor
    public void resetGame()
    {
        win = false;
        SceneManager.LoadScene("MainScene");
    }
    
}
