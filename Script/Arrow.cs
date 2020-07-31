using UnityEngine;

public class Arrow : MonoBehaviour
{
	public float rotSpeed;
	public bool shouldRotate = true;

	void FixedUpdate()
	{
		if (shouldRotate == true)
		{
			transform.Rotate(new Vector3(0, 0, 1) * rotSpeed);
		}
	}
}
