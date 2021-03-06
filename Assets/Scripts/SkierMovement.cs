﻿using UnityEngine;

public class SkierMovement : MonoBehaviour
{

	[SerializeField]
	float XmoveSpeed = 1f;

	[SerializeField]
	float YmoveSpeed = 6f;

	[SerializeField]
	float frequency = 2f;

	[SerializeField]
	float magnitude = 2f;

	Vector3 pos, localScale;

	float beatTimer = 0;
	public bool onBeat = false;
	[HideInInspector] public bool onBeatWait = false;

	public GameObject particleEffect0;
	public GameObject particleEffect1;
	public GameObject particleEffect2;
	public GameObject particleEffect3;
	public GameObject particleEffect4;

    Animator skierAnimator;
	float xPos = 0f;
	float xPosOld = 0f;
	float xPosDiff = 0f;

	[HideInInspector] public bool playedCocaine = false;
	[HideInInspector] public bool growBigger = false;



	void MoveRight()
	{
		pos += -transform.forward * Time.deltaTime * YmoveSpeed;

		transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * XmoveSpeed * magnitude;
	}



	void Start()
	{
        skierAnimator = gameObject.GetComponent<Animator>();

		pos = transform.position;
		localScale = transform.localScale;
	}

	private void FixedUpdate()
	{
		//UPDATE TIMER
		if (onBeatWait) beatTimer += Time.deltaTime;


		//ADJUST SPRITE FOR LEFT/RIGHT MOVEMENT
        xPosOld = xPos;
        xPos = transform.position.x;
        xPosDiff = (xPos - xPosOld) * 10;
        skierAnimator.SetFloat("xSpeed", xPosDiff);


		//PLAY THE PARTICLE EFFECT AFTER THE 'COCAINE!' SOUND HAS BEEN PLAYED
		if (playedCocaine)
		{
            skierAnimator.SetBool("isHigh", true);
			particleEffect0.SetActive(true);
			particleEffect1.SetActive(true);
			particleEffect2.SetActive(true);
			particleEffect3.SetActive(true);
		}

		//PLAY THE PARTICLE EFFECT WHEN SKIERS GROW BIGGER
		if (growBigger)
		{
			particleEffect4.SetActive(true);
		}

		//MOVE TO THE BEAT
		if (onBeat)
		{
			XmoveSpeed = 2f;
			YmoveSpeed = 3f;
			frequency = 6f;
			magnitude = 1f;
			MoveRight();
		}
        else
        {
            skierAnimator.SetBool("isHigh", false);
        }

		
		//AJDUST TO THE RHYTHM
		if (onBeatWait && beatTimer % 0.5 <= 0.1f) //ADJUSTED
		{
			MoveRight();
			onBeat = true;
			onBeatWait = false;
			beatTimer = 0f;
		}
		else //ADJUSTING
		{
			MoveRight();
			XmoveSpeed = 1f;
			frequency = 2f;
			magnitude = 2f;
		}
	}
}