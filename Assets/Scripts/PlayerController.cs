using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    // RIGIDBODY DO PLAYER
    private Rigidbody _rgb;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
    }
    
    // STARTA O TIMER
    public MyTimer myTimer;
    private void Update()
    {
        // faz a checagem pra soltar soh se ja n tiver contando pra poupar processamento
        // e checa se o player n ganhou para n estartar o contador que ja foi parado quando ganha
        if (!myTimer.get_IsCounting() && !VictoryController.win)
        {
            // solta o contador quando algo tecla, joystick, botao ou toque na tela ocorre 
            if (Input.GetButtonDown("Fire1") || Input.GetAxis("Horizontal") != 0 ||
                Input.GetAxis("Vertical") != 0 || Input.GetAxis("Rotate Player") != 0 || 
                _isJoystickHeld || _isLeftButtonHeld || _isRightButtonHeld)
            {
                myTimer.StartCounting(); 
            }            
        }
    }

    private void FixedUpdate()
    {
        MoveWithRigidBody();
        RotateWithRigidBody();
    }
    
    // ============================================================================================= 
    // =============================================================================================
    
    
    // MOVEMENT
    public float movementSpeed = 8;
    // JOYSTICK
    public Joystick joystick;
    private bool _isJoystickHeld;
    public void Set_isJoystickHeld(bool value) // handled no sistema de eventos do unity
    {
        _isJoystickHeld = value;
    }

    private void MoveWithRigidBody()
    {
        // MOVE INPUTS: W A S D, setas ou joystick, se tiver usando o joystick, pega os inputs
        // do joystick, se nao, pega do teclado 
        float xAxisMoveInput = _isJoystickHeld ? joystick.Horizontal : Input.GetAxis("Horizontal");
        float zAxisMoveInput = _isJoystickHeld ? joystick.Vertical : Input.GetAxis("Vertical");
        
        // move o player pelo RigidBody com os inputs pegos
        Vector3 positionIncrement = new Vector3(xAxisMoveInput, 0, zAxisMoveInput) * movementSpeed;
        _rgb.velocity = positionIncrement;
    }
    
    
    // ============================================================================================= 
    // =============================================================================================

    
    // ROTATION 
    public float rotationSpeed = 50;
    // BOTOTES DE SETAS PARA ROTACAO: são handled pelo sistema de eventos do Unity
    public Button leftArrowButton;
    private bool _isLeftButtonHeld;
    public void Set_isLeftButtonHeld(bool value) { _isLeftButtonHeld = value; }
    public Button rightArrowButton;
    private bool _isRightButtonHeld;
    public void Set_isRightButtonHeld(bool value) { _isRightButtonHeld = value; }
    
    private void RotateWithRigidBody()
    {
        float yAxisRotationInput;
        
        // LEFT BUTTON, RIGHT BUTTON, KEYBOARD TECLAS Q e R: ve de onde vai sair o input pra rotacionar
        if (_isLeftButtonHeld) yAxisRotationInput = - rotationSpeed * Time.fixedDeltaTime;
        else if (_isRightButtonHeld) yAxisRotationInput = rotationSpeed * Time.fixedDeltaTime;
        else yAxisRotationInput = Input.GetAxis("Rotate Player") * rotationSpeed * Time.fixedDeltaTime;
        
        // rotaciona o player com o Rigidbody
        Quaternion rotationIncrement = Quaternion.Euler(0,yAxisRotationInput,0 );
        _rgb.MoveRotation(_rgb.rotation * rotationIncrement);
    }
    
}
