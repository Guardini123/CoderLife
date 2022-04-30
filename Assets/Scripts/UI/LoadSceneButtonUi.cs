using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LoadSceneButtonUi : MonoBehaviour
{
    Button btnStartPlay;

	[SerializeField] private string m_sceneName;

	private void Start()
	{
		btnStartPlay = this.gameObject.GetComponent<Button>();

		btnStartPlay.onClick.AddListener(() =>
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene(m_sceneName);
		});
	}
}
