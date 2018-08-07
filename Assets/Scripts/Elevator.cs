using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour {

    public Text text;
    public Image backgroundTop, topArrow, bottomArrow;
    public int startValue = 5;
    public int maxValue, minValue;

    public static int currentLevel;
    public static int goalLevel = 2;
	// Use this for initialization
	void Start () {
        currentLevel = startValue;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentLevel > maxValue)
            currentLevel = maxValue;
        if (currentLevel < minValue)
            currentLevel = minValue;

        if(currentLevel == goalLevel)
        {
            text.text = "<color=#008000ff>" + currentLevel+ "</color>";
            backgroundTop.color = new Color(0, 128, 0);
        }
        else
        {
            text.text = "<color=#a52a2aff>" + currentLevel + "</color>";
            backgroundTop.color = new Color(128, 0, 0);
        }

        if(currentLevel > goalLevel)
        {
            topArrow.color = new Color(128, 0, 0);
            bottomArrow.color = new Color(0, 128, 0);
        }else if(currentLevel < goalLevel)
        {
            topArrow.color = new Color(0, 128, 0);
            bottomArrow.color = new Color(128, 0, 0);
        }
        else
        {
            topArrow.color = new Color(0, 128, 0);
            bottomArrow.color = new Color(0, 128, 0);
        }





    }
}
