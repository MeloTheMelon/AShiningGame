using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressMenuScript : MonoBehaviour {
    
    public Text recepy;

    public float val;

    public static void setProgressVal(float value) {
        ProgressBarScript.value = value;
    }

    public static void setColorKeys(float yellowEnd, float greenEnd) {
        ProgressBarScript.yellowEnd = yellowEnd;
        ProgressBarScript.greenEnd = greenEnd;
    }

    public void setRecepyText(string text) {
        recepy.text = text;
    }

	// Use this for initialization
	void Start () {
        setColorKeys(0.5f,1.0f);
        setProgressVal(1.0f);
    }
}
