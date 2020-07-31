using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
	public TMP_Text diamondsValue, jumpsValue;

	void Awake()
	{
		ItemsManager.uiDataChanged += ChangeUI;
	}

	void OnDisable()
	{
		ItemsManager.uiDataChanged -= ChangeUI;
	}

	void ChangeUI(int jumps, int diamonds)
	{
		diamondsValue.text = diamonds.ToString();
		jumpsValue.text = jumps.ToString();
	}
}
