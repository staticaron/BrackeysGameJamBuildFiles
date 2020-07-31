using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
	public LevelLoader levelLoader;

	void OnTriggerEnter2D(Collider2D Col)
	{
		if (Col.CompareTag("Player"))
		{
			levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, 0.5f);
		}
	}
}
