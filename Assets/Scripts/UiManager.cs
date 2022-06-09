using UnityEngine;

// Basicamente esse script serve pra tocar entre as duas UI Portrait e Landscape, de acordo
// com a largura e altura da tela, ela tb seta qual joystick das duas UI sera usada no PlayerController,
// os botoes de rotacao nao precisam pq eles soh passam um input simples de pressionado ou nao, o joysticky
// passa a variacao em eixos, o que eh mais complexo

public class UiManager : MonoBehaviour
{
    
    public GameObject UiPortrait;
    public GameObject UiLandscape;
    
    public PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        UiLandscape.SetActive(false);
        UiPortrait.SetActive(false);
            
        
        bool isPortrait = Screen.height > Screen.width;
        if (isPortrait)
        {
            UiPortrait.SetActive(true);
            UiLandscape.SetActive(false);
            playerControllerScript.joystick = UiPortrait.transform.GetChild(0).GetComponent<Joystick>();
        }
        else
        {
            UiLandscape.SetActive(true);
            UiPortrait.SetActive(false);
            playerControllerScript.joystick = UiLandscape.transform.GetChild(0).GetComponent<Joystick>();
        }
    }

}
