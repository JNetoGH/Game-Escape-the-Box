using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    private float _deltaCounter;
    private int _totSec;
    private int _totMin;
    
    [FormerlySerializedAs("timerUI")] public TMP_Text timerUi;

    private void Update()
    {
        // Time.deltaTime will increase the value with 1 every second.
        _deltaCounter += Time.deltaTime;
        
        _totSec = (int) _deltaCounter;
        if (_totSec >= 60)
        {
            _deltaCounter = 0;
            _totSec = 0;
            _totMin++;
        }
        
        timerUi.text = (_totMin <= 9 ? "0":"") + _totMin + ":" 
                       + (_totSec <= 9 ? "0":"") + _totSec;
    }
}
    
    

