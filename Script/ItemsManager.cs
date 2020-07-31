using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemsManager : MonoBehaviour
{
	//delegate
	public delegate void UIDataChanged(int jumps, int diamonds);
	public static event UIDataChanged uiDataChanged;

	public static int diamonds;
	public static int jumps;

	public LevelLoader levelLoader;

	public int initialJumpsValue, initialDiamondsValue;

	void Start()
	{
		jumps = initialJumpsValue;
		diamonds = initialDiamondsValue;

		if (uiDataChanged != null) uiDataChanged(jumps, diamonds);

		Player.playerLanded += checkValues;
	}

	void OnDisable()
	{
		Player.playerLanded -= checkValues;
	}

	public static void reduceJumps(int amount)
	{
		jumps -= amount;

		if (uiDataChanged != null) uiDataChanged(jumps, diamonds);
	}

	public static void reduceDiamonds(int amount)
	{
		diamonds -= amount;

		if (uiDataChanged != null) uiDataChanged(jumps, diamonds);
	}

	public static void addDiamonds(int amount)
	{
		jumps += amount;
		if (uiDataChanged != null) uiDataChanged(jumps, diamonds);
	}

	void checkValues()
	{
		if (jumps <= 0 && diamonds <= 0)
		{
			print("Level Over");
			levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex, 0.5f);
		}
	}
}
