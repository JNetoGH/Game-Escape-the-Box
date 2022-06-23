using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

// Basicamente esse script serve pra tocar entre as duas UI Portrait e Landscape, de acordo
// com a largura e altura da tela, ela tb seta qual joystick das duas UI sera usada no PlayerController,
// os botoes de rotacao nao precisam pq eles soh passam um input simples de pressionado ou nao, o joysticky
// passa a variacao em eixos, o que eh mais complexo

public class UiManager : MonoBehaviour
{
    
    public GameObject uiPortrait;
    public GameObject uiLandscape;
    public TMP_Text timerUiText;
    public PlayerController playerControllerScript;
    
    
    //private void initRequiredStuff
    
    
    // Start is called before the first frame update
    void Start()
    {
        uiLandscape.SetActive(false);
        uiPortrait.SetActive(false);
            
        bool isPortrait = Screen.height > Screen.width;
        if (isPortrait)
        {
            uiPortrait.SetActive(true);
            uiLandscape.SetActive(false);
            playerControllerScript.joystick = uiPortrait.transform.GetChild(0).GetComponent<Joystick>();
            timerUiText.fontSize = 60; //aumenta o timer
        }
        else
        {
            uiLandscape.SetActive(true);
            uiPortrait.SetActive(false);
            playerControllerScript.joystick = uiLandscape.transform.GetChild(0).GetComponent<Joystick>();
        }
    }

}
