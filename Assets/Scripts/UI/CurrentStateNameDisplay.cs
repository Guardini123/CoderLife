using System.Collections;
using UnityEngine;
using TMPro;

public class CurrentStateNameDisplay : MonoBehaviour
{
	[SerializeField] private Character _character;
	[SerializeField] private TMP_Text _curStateNameTMPText;

	[SerializeField]
	private void Start()
	{
		if (_character == null || _curStateNameTMPText == null)
		{
			Debug.LogError("You need to set up character and text field!");
			this.enabled = false;
		}
	}

	private void Update()
	{
		_curStateNameTMPText.text = _character.CurrentState.GetType().ToString();
	}
}