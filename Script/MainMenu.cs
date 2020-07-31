using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			SceneManager.LoadScene(2);
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			Application.Quit();
		}
		else if (Input.GetKeyDown(KeyCode.X))
		{
			SceneManager.LoadScene(1);
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			SceneManager.LoadScene(0);
		}
	}
}
