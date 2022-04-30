using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitGameButtonUi : MonoBehaviour
{
    Button btnExit;

	private void Start()
	{
		btnExit = this.gameObject.GetComponent<Button>();

		btnExit.onClick.AddListener(() =>
		{
			Application.Quit();
		});
	}
}
