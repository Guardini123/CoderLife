using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSwitch;

    [SerializeField] private GameObject _switcherIndicatorOn;
    [SerializeField] private GameObject _switcherIndicatorOff;

    [SerializeField] private bool _isOn = false;
    public bool On => _isOn;


    void Start()
    {
        if(_objectToSwitch == null || _switcherIndicatorOn == null || _switcherIndicatorOff == null)
		{
            Debug.LogError("You need to set up object and switcher!");
            this.enabled = false;
		} else {
            SwitchObjectState(_isOn);
        }
    }

    
    public void Switch()
	{
        _isOn = !_isOn;
        SwitchObjectState(_isOn);
    }


    private void SwitchObjectState(bool state)
	{
        _objectToSwitch.SetActive(state);
        _switcherIndicatorOn.SetActive(state);
        _switcherIndicatorOff.SetActive(!state);
    }
}
