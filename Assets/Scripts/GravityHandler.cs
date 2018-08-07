using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour {

    public static string currentGravityAxis = "y";
    public static bool currentGravityBool = true;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Gravity: " + Physics.gravity);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            changeGravity("x", true);
            ChangeGravityField.reset = true;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            changeGravity("y", false);
            ChangeGravityField.reset = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            changeGravity("z", false);
            ChangeGravityField.reset = true;
        }

    }

    public static void changeGravity(string axis,bool positive)
    {
        //Debug.Log("1 0 0");
        //Physics.gravity = new Vector3(9.81f, 0, 0);
        

        currentGravityAxis = axis;
        currentGravityBool = positive;

        Vector3 newGrav = new Vector3();
        Vector3 newTra = new Vector3();
        Vector3 newRot = new Vector3();
        if (axis.Equals("x"))
        {
            newGrav = new Vector3(9.81f, 0, 0);
            newTra = new Vector3(0, 0, 1);
            newRot = new Vector3(0, 0, -1);

            

        }else if (axis.Equals("y"))
        {
            newGrav = new Vector3(0, 9.81f, 0);
            newTra = new Vector3(0, 0, 1);
            if (positive)
            {
                newRot = new Vector3(2, 0, 0);
            }
            else
            {
                newRot = new Vector3(0, 0, 0);
            }
        }
        else if (axis.Equals("z"))
        {
            newGrav = new Vector3(0, 0, 9.81f);
            newTra = new Vector3(0, 0, 1);
            newRot = new Vector3(1, 0, 0);
        }
        else
        {
            Debug.LogError("Not an axis");
        }

        if (!positive)
        {
            newGrav *= (-1);
            newRot *= (-1);
        }

        Physics.gravity = newGrav;
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().setMovementVectors(newTra, newRot);
    }


}
