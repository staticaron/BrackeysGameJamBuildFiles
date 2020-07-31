using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
	public void LoadLevel(int levelIndex, float time)
	{
		StartCoroutine(Load(levelIndex, time));
	}

	public static IEnumerator<YieldInstruction> Load(int level, float time)
	{
		yield return new WaitForSeconds(time);

		SceneManager.LoadScene(level);
	}
}
