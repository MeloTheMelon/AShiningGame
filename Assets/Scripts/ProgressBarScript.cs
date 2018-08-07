using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour {

    public Slider progressVisObj;
    public Image progressFill;
    public static float value, yellowEnd, greenEnd; //Value given in %;	
   

	// Update is called once per frame
	void Update () {
        if (value < 0) value = 0;

        if(value >= yellowEnd)
        {
            progressFill.color = Color.Lerp(Color.yellow, Color.green, (value - yellowEnd) / (1 - yellowEnd));
        }
        else
        {
            progressFill.color = Color.Lerp(Color.red, Color.yellow, (value * (1/yellowEnd)));
        }

        if (value <= 0)
            Debug.Log("You lose");

        progressVisObj.value = value;
	}
}
