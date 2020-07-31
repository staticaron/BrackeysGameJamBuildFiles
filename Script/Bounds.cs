using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour
{
	public LevelLoader levelLoader;

	void OnTriggerEnter2D(Collider2D Col)
	{
		if (Col.CompareTag("Player"))
		{
			levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex, 0);
		}
	}
}
