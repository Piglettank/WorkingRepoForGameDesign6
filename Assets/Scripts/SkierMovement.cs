using UnityEngine;

public class SkierMovement : MonoBehaviour
{

	[SerializeField]
	float XmoveSpeed = 1f;

	[SerializeField]
	float YmoveSpeed = 5f;

	[SerializeField]
	float frequency = 2f;

	[SerializeField]
	float magnitude = 2f;

	Vector3 pos, localScale;

	float beatTimer = 0;
	public bool onBeat = false;
	public static bool onBeatWait = false;

	private void OnTriggerEnter(Collider other)
	{
		onBeatWait = true;
	}

	void Start()
	{
		pos = transform.position;
		localScale = transform.localScale;
	}


	private void FixedUpdate()
	{
		if (onBeatWait) beatTimer += Time.deltaTime;

		if (onBeat)
		{
			XmoveSpeed = 2f;
			frequency = 6f;
			magnitude = 1f;
			MoveRight();
		}

		
		if (onBeatWait && beatTimer % 0.5 <= 0.1f)
		{
			MoveRight();
			onBeat = true;
			onBeatWait = false;
			beatTimer = 0f;
		}
		else
		{
			MoveRight();
			XmoveSpeed = 1f;
			frequency = 2f;
			magnitude = 2f;
		}


	}


	void MoveRight()
	{
		pos += -transform.forward * Time.deltaTime * YmoveSpeed;
		transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * XmoveSpeed * magnitude;
	}
}