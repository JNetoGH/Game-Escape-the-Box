using TMPro;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    
    public TMP_Text timerUi;

    private float _deltaCounter;
    private int _totSec;
    private int _totMin;
    
    private bool _isCounting = false;

    public bool get_IsCounting()
    {
        return _isCounting;
    }
    public void StopCounting()
    {
        _isCounting = false;
    }
    public void StartCounting()
    {
        _isCounting = true;
    }
    
    
    private void Update()
    {
        if (_isCounting)
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
}
    
    

