using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class BtnRestart : MonoBehaviour
{
	Button btnRestart;


	private void Start()
	{
		btnRestart = this.gameObject.GetComponent<Button>();

		btnRestart.onClick.AddListener(() =>
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
	}
}
