using UnityEngine;

public class SkierMovement : MonoBehaviour
{

	[SerializeField]
	public static float XmoveSpeed = 1f;

	[SerializeField]
	public static float YmoveSpeed = 0f;

	[SerializeField]
	public static float frequency = 2f;

	[SerializeField]
	public static float magnitude = 2f;

	Vector3 pos, localScale;

	float beatTimer = 0;
	bool onBeat = false;
	public bool onBeatWait = false;

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
			Debug.Log("beatTimer % 2 > 0.1f");
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