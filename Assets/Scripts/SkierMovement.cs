using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkierMovement : MonoBehaviour
{

	[SerializeField]
	float XmoveSpeed = 0.5f;

	[SerializeField]
	float YmoveSpeed = 0.5f;

	[SerializeField]
	float frequency = 0.5f;

	[SerializeField]
	float magnitude = 0.5f;

	Vector3 pos, localScale;


	void Start()
	{

		pos = transform.position;

		localScale = transform.localScale;

	}

	void Update()
	{
		MoveRight();
	}

	void MoveRight()
	{
		pos += -transform.forward * Time.deltaTime * YmoveSpeed;
		transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * XmoveSpeed * magnitude;
	}
}