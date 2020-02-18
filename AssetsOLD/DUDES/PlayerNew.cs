using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerNew : MonoBehaviour
{
    public GameObject[] dots = new GameObject[3];
    public static string reaction;
    public static bool newDude;
    public static bool buttonHighFive = false;
    public static bool buttonFakeOut = false;
    public static bool ignore = false;
    public static bool cooldown = false;
    private float currentTime = 0;
    static float compareTime = 0;
    private float compareTimeW = 0;
    private float compareTimeW2 = 0;
    private float compareTimeW3 = 0;
    private int dotCount;
    private int toggle = 0;
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
        compareTimeW2 = compareTimeW + 3;
        compareTimeW3 = Time.time;
        buttonHighFive = true;
    }
    //ACTIVATED BY THE FAKE_OUT BUTTON
    public void ToggleFakeOut()
    {
        buttonFakeOut = true;
        wait = false;
        toggle = 2;
        compareTimeW = Time.time + 1;
        compareTimeW2 = compareTimeW + 3;
    }
    public void ToggleIgnore()
    {
        toggle = 3;
        compareTimeW = Time.time + 1;
        compareTimeW2 = compareTimeW + 3;
        compareTimeW3 = Time.time;
        reaction = "Ignored";
        ignore = true;
        remove = true;
        wait = false;
        Resett();
        Debug.Log("REACTED: " + reaction);
    }
    //SET REACTION TO HIGH FIVE
    public void SetReactionHF()
    {
        reaction = "High Five";
        Debug.Log("REACTED: " + reaction);
    }
    //SET REACTION TO FAKE OUT
    public void SetReactionFO()
    {
        reaction = "Fake Out";
        Debug.Log("REACTED: " + reaction);
    }
    //ACTIVATE SPAWN OF A NEW DUDE IN FIXED UPDATE
    public void NewDudeSetup()
    {
        newDude = true;
        remove = true;
    }
    //REMOVE ALL THE DOTS
    public void Resett()
    {
        CancelInvoke();
        compareTime = Time.time + 4.5f; //NEW TIMESTAMP FOR THE 'IGNORED' REACTION
        compareTimeW3 = Time.time + 8.5f;
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
        //compareTimeW3 = Time.time;
    }
    // FIXED UPDATE
    void FixedUpdate()
    {
        //UPDATE WAITING TIME
        currentTime = Time.time;
        compareTimeW3 = Time.time;
        //MAKE A NEW DUDE
        if (newDude == true)
        {
            Resett();           //REMOVE EXISITING DOTS
            newDude = false;    //JUST 1 MORE DUDE
            wait = true;        //WAITING STARS
            invoke = true;      //YES, ADD NEW DOTS
            remove = false;     //NO, WE'RE NOT REMOVING EXISTING DOTS
            cooldown = false;
            dotCount = -1;      //RESET THE dotCount
        }
        if (toggle == 1 || toggle == 2 || toggle == 3)
        {
            remove = true;
            if (Time.time >= compareTimeW)
            {
                if (toggle == 1) SetReactionHF();
                if (toggle == 2) SetReactionFO();
            }
            if (Time.time >= compareTimeW2)
            {
                toggle = 0;
                cooldown = true;
                newDude = true;
                reaction = "";
            }
        }
        //ADD 1 DOT PER SECOND
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
            Invoke("NewDot", 1f);
            invoke = false;
        }
        //CHECK FOR IGNORED REACTION
       /* if (Time.time >= compareTimeW3)
        {
            currentTime = Time.time;
            reaction = "Ignored";
            toggle = 3;
            compareTimeW = Time.time + 1;
            compareTimeW2 = compareTimeW + 3;
            ignore = true;
            // DOTS RESET
            wait = false;
            remove = true;
            Resett();
            return;
        }*/
    }
}