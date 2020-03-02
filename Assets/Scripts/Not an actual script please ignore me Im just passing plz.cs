using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NotanactualscriptpleaseignoremeImjustpassingplz : MonoBehaviour
{


    static bool SetSchneiderDEBUG(ref int[,] playerCards, ref int[,] playedCards, int manyCards, ref bool isSingle, ref int r2, ref int r3,
                              ref int isPlayedAce, ref int isSchwarz, ref bool playSchwarz)
    {
        System.Random rnd = new System.Random();

        int trials = 0;
        isSchwarz = rnd.Next(50); //SCHWARZ OR MATADOR, 50% chance
                                        //r2 and r3 are random numbers used to reference cards

        if (howManyLeft(playerCards, 0, manyCards) == 1) isSingle = true; //IF THERE'S ONLY ONE CARD LEFT, IT IS SINGLE
        else isSingle = TrueOrFalse(rnd.Next(2)); //SINGLE OR DOUBLE, 50% chance



        if (isSchwarz < 25) //IT IS SCHWARZ
        {
            playSchwarz = true;

            if (isSingle == true) //IT IS SINGLE SCHWARZ
            {
                //PICK RANDOM CARD IN RANGE FROM 0 TO manyCards
                do
                {
                    r2 = rnd.Next(manyCards);
                } while (playerCards[0, r2] == 9999);

                //CHECK FOR AN ACE
                if (GetCardValue(playerCards[0, r2]) == 14) //GetCardValue returns simple card value, eg 11 instead of 311 for a Jack (instead of 111/211/311/411) or 5 for a 5 (instead of 105/205/305/405)
                {
                    isPlayedAce = rnd.Next(2); //CHOOSE IF ACE IS PLAYED AS 1 OR 14
                    if (isPlayedAce == 0)
                    {
                        playedCards[0, 0] = playerCards[0, r2] - 13; //PLAY THE ACE AS 1
                        playedCards[0, 1] = 9999;
                    }
                    else
                    {
                        playedCards[0, 0] = playerCards[0, r2];    //PLAY THE ACE AS 14
                        playedCards[0, 1] = 9999;
                    }

                    return true;
                }


                //SINGLE SCHWARZ WITH NO ACE
                playedCards[0, 0] = playerCards[0, r2]; //PLAY THE CARD
                playedCards[0, 1] = 9999;
                return true;

            }
            else //IT IS DOUBLE SCHWARZ 
            {
                //PICK RANDOM CARDS; RETURN FALSE IF CAN'T REROLL 
                do
                {
                    r2 = rnd.Next(manyCards);
                    r3 = rnd.Next(manyCards);

                    if (r2 == r3 || playerCards[0, r2] == 9999 || playerCards[0, r3] == 9999)
                    {
                        trials++;
                        if (trials > 20) return false;
                    }
                } while (r2 == r3 || playerCards[0, r2] == 9999 || playerCards[0, r3] == 9999);


                //IF CARDS ADD UP TO MORE THAN 14, CHECK FOR ACES AND PLAY THE ACES, OR REROLL
                while (GetCardValue(playerCards[0, r2]) + GetCardValue(playerCards[0, r3]) > 14)
                {
                    //THERE ARE ACES, DECIDE HOW TO PLAY
                    if (GetCardValue(playerCards[0, r2]) == 14 || GetCardValue(playerCards[0, r3]) == 14) //CHECK IF THERE IS AN ACE
                    {
                        if (GetCardValue(playerCards[0, r2]) == 14 && GetCardValue(playerCards[0, r3]) == 14) //BOTH CARDS ARE ACE
                        {
                            playedCards[0, 0] = playerCards[0, r2] - 13; //PLAY THE ACE AS 1
                            playedCards[0, 1] = playerCards[0, r3] - 13; //PLAY THE ACE AS 1
                            return true;
                        }

                        if (GetCardValue(playerCards[0, r2]) == 14) //FIRST CARD IS THE ACE
                        {
                            playedCards[0, 0] = playerCards[0, r2] - 13; //PLAY THE OTHER CARD 
                            playedCards[0, 1] = playerCards[0, r3];      //PLAY THE ACE AS 1
                            return true;
                        }

                        if (GetCardValue(playerCards[0, r3]) == 14) //SECOND CARD IS THE ACE
                        {
                            playedCards[0, 0] = playerCards[0, r2];      //PLAY THE OTHER CARD 
                            playedCards[0, 1] = playerCards[0, r3] - 13; //PLAY THE ACE AS 1
                            return true;
                        }
                    }


                    //THERE ARE NO ACES, HAVE TO REROLL (because playerCards[0, r2] + playerCards[0, r3] > 14)
                    do
                    {
                        r2 = rnd.Next(manyCards);
                        r3 = rnd.Next(manyCards);

                        if (r2 == r3 || playerCards[0, r2] == 9999 || playerCards[0, r3] == 9999)
                        {
                            trials++;
                            if (trials > 20) return false;
                        }
                    } while (r2 == r3 || playerCards[0, r2] == 9999 || playerCards[0, r3] == 9999);
                }

                //CHECK FOR AN ACE 
                if (GetCardValue(playerCards[0, r2]) == 14) //FIRST CARD IS AN ACE
                {
                    playedCards[0, 0] = playerCards[0, r2] - 13; //PLAY THE ACE AS 1
                    playedCards[0, 1] = playerCards[0, r3];      //PLAY THE OTHER CARD
                    return true;
                }

                if (GetCardValue(playerCards[0, r3]) == 14) //SECOND CARD IS THE ACE
                {
                    playedCards[0, 0] = playerCards[0, r2];      //PLAY THE OTHER CARD 
                    playedCards[0, 1] = playerCards[0, r3] - 13; //PLAY THE ACE AS 1
                    return true;
                }

                //PLAY THE CARDS - NO ACES, DON'T ADD UP TO MORE THAN 14
                playedCards[0, 0] = playerCards[0, r2];
                playedCards[0, 1] = playerCards[0, r3];
                return true;
            }
        }//END OF SCHWARZ

        //IT IS MATADOR
        if (isSchwarz >= 25)
        {
            playSchwarz = false;

            if (isSingle == true) //IT IS SINGLE MATADOR
            {
                //PICK RANDOM CARD
                do
                {
                    r2 = rnd.Next(manyCards);
                } while (playerCards[0, r2] == 9999);

                //CHECK FOR AN ACE
                if (GetCardValue(playerCards[0, r2]) == 14)
                {
                    isPlayedAce = rnd.Next(2); //CHOOSE IF ACE IS PLAYED AS 1 OR 14

                    if (isPlayedAce == 0)
                    {
                        playedCards[0, 0] = playerCards[0, r2] - 13; //PLAY THE ACE AS 1
                        playedCards[0, 1] = 9999;
                        return true;
                    }
                    else
                    {
                        playedCards[0, 0] = playerCards[0, r2];     //PLAY THE ACE AS 14
                        playedCards[0, 1] = 9999;
                        return true;
                    }
                }

                //IT IS NOT AN ACE, PLAY THE CARD
                playedCards[0, 0] = playerCards[0, r2];
                return true;

            }
            else //IT IS DOUBLE MATADOR
            {
                //PICK RANDOM CARDS
                do
                {
                    r2 = rnd.Next(manyCards);
                    r3 = rnd.Next(manyCards);
                } while (r2 == r3 || playerCards[0, r2] == 9999 || playerCards[0, r3] == 9999);



                //MAKE SURE playerCards[0, r2] IS GREATER THAN playerCards[0, r3]
                if (GetCardValue(playerCards[0, r2]) < GetCardValue(playerCards[0, r3]))
                {
                    (r2, r3) = (r3, r2);
                }


                //CHECK FOR AN ACE IN A REGULAR MATADOR
                if (GetCardValue(playerCards[0, r2]) == 14 || GetCardValue(playerCards[0, r3]) == 14)
                {
                    isPlayedAce = rnd.Next(2); //CHOOSE IF THE ACE IS PLAYED AS 14 OR 1

                    if (isPlayedAce == 0) //PLAY THE ACE AS 1
                    {
                        playedCards[0, 1] = playerCards[0, r2] - 13; //PLAY ACE AS 1, [0,1] BACAUSE IT IS NOW THE SMALLER NUMBER
                        playedCards[0, 0] = playerCards[0, r3];
                    }
                    else //PLAY THE ACE AS 14
                    {
                        playedCards[0, 0] = playerCards[0, r2]; //PLAY ACE AS 14
                        playedCards[0, 1] = playerCards[0, r3];
                    }

                    return true;
                }
                else
                {
                    //NO ACES
                    playedCards[0, 0] = playerCards[0, r2];
                    playedCards[0, 1] = playerCards[0, r3];
                }

                //CHECK FOR DOUBLE ZERO MATADOR
                if (GetCardValue(playerCards[0, r2]) == GetCardValue(playerCards[0, r3]))
                {
                    //CHECK IF BOTH CARDS ARE ACES 
                    if (GetCardValue(playerCards[0, r2]) == 14 && GetCardValue(playerCards[0, r3]) == 14)
                    {
                        isPlayedAce = rnd.Next(2); //CHOOSE IF ACES ARE PLAYED AS 14 OR 1

                        if (isPlayedAce == 1)
                        {
                            //DOUBLE ZERO MATADOR WITH 2 ACES
                            playedCards[0, 0] = playerCards[0, r2];
                            playedCards[0, 1] = playerCards[0, r3];
                            return true;
                        }
                        else
                        {
                            //DOUBLE 13 MATADOR WITH 2 ACES
                            playedCards[0, 0] = playerCards[0, r2];
                            playedCards[0, 1] = playerCards[0, r3] - 13;
                            return true;
                        }
                    }

                    //NON-ACE DOUBLE ZERO MATADOR
                    playedCards[0, 0] = playerCards[0, r2];
                    playedCards[0, 1] = playerCards[0, r3];
                    return true;

                }

                return true;
            }
        }

        return true;
    }//SetSchneiderA

    static int GetCardValue(int a)
    {
        return a - 1;
    }

    static int howManyLeft(int[,] a, int b, int c0)
    {
        return a[0,0] + 1;
    }

    static bool TrueOrFalse(int a)
    {
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
