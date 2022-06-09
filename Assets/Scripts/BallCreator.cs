using UnityEngine;
using UnityEngine.UI;

public class BallCreator : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;


    private Button b;
    // fica true quando for um clique numa zona de boatao da UI mobile
    // dai nao instancia bolas quando se aperta um botao
    // ta sendo handled pelo EventTrigger do Editor 
    private bool _isClickInProhibitedZoneForInstantiation;
    public void SetProhibitionOfBallInstantiation(bool prohibit)
    {
        _isClickInProhibitedZoneForInstantiation = prohibit;
        
    }  
    
    // Update is called once per frame
    private void Update()
    {
        if (!_isClickInProhibitedZoneForInstantiation)
        {
            if (Input.GetButtonDown("Fire1")) 
                Instantiate(ball);
            ball.transform.position = new Vector3(player.transform.position.x, 10, player.transform.position.z);   
        }
    }
}
