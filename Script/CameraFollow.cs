using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 offset;

	public Vector2 minmax_X, minmax_Y;

	public Vector3 position;

	void Start()
	{
		offset = transform.position;
	}

	void LateUpdate()
	{
		position = target.position + offset;

		position = new Vector3(Mathf.Clamp(position.x, minmax_X.x, minmax_X.y), Mathf.Clamp(position.y, minmax_Y.x, minmax_Y.y), -10);

		transform.position = position;



	}
}
