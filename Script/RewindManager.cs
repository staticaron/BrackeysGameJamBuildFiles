using UnityEngine;
using System;
using System.Collections.Generic;

//b48f654f-d0da-4848-9164-f714b574b271
//b48f654f-d0da-4848-9164-f714b574b271

public class RewindManager : MonoBehaviour
{
	public List<float> x_positions;
	public List<float> y_positions;

	public List<float> rotations;

	public float timeToStore;
	public float timeToRewind;

	private float initialGravityScale;
	private Rigidbody2D thisBody;
	private int rewindIndex;

	void Start()
	{
		//Subscribe to events
		Player.groundData += RewindStoreManager;

		thisBody = GetComponent<Rigidbody2D>();
		initialGravityScale = thisBody.gravityScale;
	}

	void OnDisable()
	{
		//Unsubscribe from events
		Player.groundData -= RewindStoreManager;
	}

	void RewindStoreManager(bool isGrounded)
	{
		if (isGrounded == true)
		{
			StartStoring(0, timeToStore);
		}
	}

	void StartStoring(float startTime, float repeatTime)
	{
		InvokeRepeating("StorePositions", startTime, repeatTime);
	}

	void StartRewinding(float rewindTime)
	{
		rewindIndex = x_positions.Count - 1;
		InvokeRepeating("Rewind", rewindTime, rewindTime);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (ItemsManager.diamonds > 0)
			{

				if (x_positions.Count > 3)
				{
					ItemsManager.reduceDiamonds(1);
					ItemsManager.addDiamonds(1);

					StartRewinding(timeToRewind);
				}
			}

		}

		if (Input.GetKeyUp(KeyCode.Return))
		{
			StopRewinding();
		}
	}

	public void StorePositions()
	{
		float position_x = (float)Math.Round(transform.position.x, 3);
		float position_y = (float)Math.Round(transform.position.y, 3);
		float rotationToSet = (float)Math.Round(transform.rotation.eulerAngles.z, 0);

		if (x_positions.Count <= 0)
		{
			//Add some sort of starting positions
			x_positions.Add(position_x);
			y_positions.Add(position_y);

			//If rotations list is also empty then init it
			if (rotations.Count <= 0)
			{
				rotations.Add(rotationToSet);
			}

			return;
		}

		//Store Positions and rotations
		float last_x = x_positions[x_positions.Count - 1];
		float last_y = y_positions[y_positions.Count - 1];

		if (Math.Abs(last_x - position_x) > 0.1f || Math.Abs(last_y - position_y) > 0.1f)
		{
			x_positions.Add(position_x);
			y_positions.Add(position_y);
			rotations.Add(rotationToSet);
		}
	}

	public void Rewind()
	{
		thisBody.gravityScale = 0;

		float xToSet, yToSet, rotationToSet;

		xToSet = x_positions[rewindIndex];
		yToSet = y_positions[rewindIndex];
		rotationToSet = rotations[rewindIndex];

		transform.position = new Vector2(xToSet, yToSet);
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationToSet));

		if (rewindIndex == 0)
		{
			StopRewinding();
		}

		rewindIndex -= 1;
	}

	void StopRewinding()
	{
		x_positions.Clear();
		y_positions.Clear();
		rotations.Clear();

		thisBody.gravityScale = initialGravityScale;

		thisBody.constraints = RigidbodyConstraints2D.FreezePosition;
		thisBody.constraints = RigidbodyConstraints2D.None;

		StartStoring(timeToStore, timeToStore);
		CancelInvoke("Rewind");
	}

}
