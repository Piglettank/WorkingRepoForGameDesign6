using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWaitingReaction : MonoBehaviour
{

    public bool changedBool; 
    public void Toggle()
    {
        changedBool = !changedBool; // changes whatever bool to the opposite value of what it was when the function was called 
    }

}
