using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScaleSlider : MonoBehaviour
{
	[SerializeField] private TMP_Text _sliderText;

	private void Start()
	{
		var startValue = 1f;
		SetScale(startValue);
	}

	public void SetScale(float value)
	{
		Time.timeScale = value;
		_sliderText.text = value.ToString("0.00");
	}
}
