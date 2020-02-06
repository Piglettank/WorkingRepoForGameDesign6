using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    public GameObject[] dots = new GameObject[3];

    public static string reaction;

    private float currentTime = 0;
    static float compareTime = 0;

    private float compareTimeW = 0;
    private float compareTimeW2 = 0;

    private int dotCount;
    private int toggle = 0;

    private bool newDude;
    private bool reacted;
    private bool wait;
    private bool invoke;
    private bool remove;


    //ADD TO THE DOT COUNTER SO THAT A DOT WOULD BE ADDED IN FIXED UPDATE
    public void NewDot()
    {
        dotCount += 1;
        invoke = true;
    }


    //ACTIVATED BY THE HIGH_FIVE BUTTON
    public void ToggleHighFive()
    {
        wait = false;
        toggle = 1;
        compareTimeW = Time.time + 1;
        compareTimeW2 = Time.time + 3;
        Debug.Log("inside: ToggleHighFive. compareTimeW: " + compareTimeW );

    }



    //ACTIVATED BY THE FAKE_OUT BUTTON
    public void ToggleFakeOut()
    {
        wait = false;
        toggle = 2;
        compareTimeW = Time.time + 1;
        compareTimeW2 = Time.time + 3;
        Debug.Log("inside: ToggleFakeOut. compareTimeW2: " + compareTimeW);
    }



    //SET REACTION TO HIGH FIVE
    public void SetReactionHF()
    {
        Debug.Log("inside: SetReactionHF");
        reaction = "High Five";
        reacted = true;
        Debug.Log("REACTED: " + reaction);

        //MAKE IT POSSIBLE TO SPAWN A NEW DUDE AFTER 1S DELAY 
    }


    //SET REACTION TO FAKE OUT
    public void SetReactionFO()
    {
        Debug.Log("inside: SetReactionFO");
        reaction = "Fake Out";
        reacted = true;
        Debug.Log("REACTED: " + reaction);

        //MAKE IT POSSIBLE TO SPAWN A NEW DUDE AFTER 1S DELAY
    }



    //ACTIVATE SPAWN OF A NEW DUDE IN FIXED UPDATE
    public void NewDudeSetup()
    {
        Debug.Log("inside: NewDudeSetup");
        newDude = true;
        remove = true;
    }



    //REMOVE ALL THE DOTS
    public void Resett()
    {
        CancelInvoke();

        for (int b = 0; b <= 2; ++b)
        {
            dots[b].SetActive(false);
        }
    }


    // START
    void Start()
    {
        //MAKE A DUDE
        newDude = true;
        wait = false;

        //DOTS SET UP
        invoke = true;
        remove = false;
        dotCount = -1;

        //TIME SET UP
        Time.timeScale = 1f;
        currentTime = Time.time;
        compareTime = 0;
    }


    // FIXED UPDATE
    void FixedUpdate()
    {
        //UPDATE WAITING TIME 
        currentTime = Time.time;

        if (toggle == 1 || toggle == 2 || toggle == 3)
        {

            Debug.Log("inside: toggle true. Time.time: " + Time.time + ". compareTimeW: " + compareTimeW);


            if (Time.time >= compareTimeW)
            {
                if (toggle == 1) SetReactionHF();
                if (toggle == 2) SetReactionFO();
            }

            if (Time.time >= compareTimeW2)
            {
                NewDudeSetup();
                toggle = 0;
            }
        }


        //MAKE A NEW DUDE 
        if (newDude == true)
        {
            Resett();           //REMOVE EXISITING DOTS
            newDude = false;    //JUST 1 MORE DUDE
            wait = true;        //WAITING STARS
            reacted = false;    //NO REACTION FOR THE NEW DUDE
            invoke = true;      //YES, ADD NEW DOTS
            remove = false;     //NO, WE'RE NOT REMOVING EXISTING DOTS
            dotCount = -1;      //RESET THE dotCount

            compareTime = Time.time + 4.5f; //NEW TIMESTAMP FOR THE 'IGNORED' REACTION 
        }


        //ADD 1 DOT PER SECOND
        if (wait == true)
        {
            // CHECK IF dotCount IS WITHIN ARRAY INDEX
            if (dotCount >= 0 && dotCount <= 2)
            {
                if (remove == false)//DON'T ADD A NEW DOT DURING THE FRAME WHERE WE RESET THE DOTS
                {
                    dots[dotCount].SetActive(true);
                }
            }

            // ADD 1 TO dotCount PER SECOND 
            if (invoke == true)
            {
                Debug.Log("invoke");

                Invoke("NewDot", 1f);
                invoke = false;
            }

            //CHECK FOR IGNORED REACTION
            if (currentTime >= compareTime)
            {
                currentTime = Time.time;
                reaction = "Ignored";
                toggle = 3;
                compareTimeW = Time.time + 1;
                compareTimeW2 = Time.time + 3;
                Debug.Log("REACTED: " + reaction);

                // DOTS RESET
                wait = false;
                remove = true;
                Resett();

                return;
            }

            //IF NOT WAITING, RESET
        }
        else if (wait == false)
        {
            Resett();
        }
    }
}
