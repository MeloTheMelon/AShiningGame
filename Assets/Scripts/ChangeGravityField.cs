using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityField : MonoBehaviour {

    public static bool reset = false;

    public bool change;

    public ChangeGravityField otherCGF;

    public string gravityAxis1;
    public bool gravityBool1;

    public string gravityAxis2;
    public bool gravityBool2;

    void Start()
    {
        change = true;
    }

    void Update()
    {
        if (reset)
        {
            otherCGF.change = true;
            reset = false;
        }

       

    }

    void OnTriggerEnter(Collider c)
    {
        if (!c.gameObject.GetComponent<Player>().justPorted&&change)
        {
            otherCGF.change = false;
            if(GravityHandler.currentGravityBool == gravityBool1 && GravityHandler.currentGravityAxis.Equals(gravityAxis1))
            {
                GravityHandler.changeGravity(gravityAxis2, gravityBool2);
                StartCoroutine(c.gameObject.GetComponent<Player>().portedPlayer());
            }
            else
            {
                GravityHandler.changeGravity(gravityAxis1, gravityBool1);
                StartCoroutine(c.gameObject.GetComponent<Player>().portedPlayer());
            }

        }else if(!c.gameObject.GetComponent<Player>().justPorted && !change)
        {
            
            otherCGF.change = true;
            change = true;
        }
    }
}
