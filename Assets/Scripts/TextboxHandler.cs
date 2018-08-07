using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxHandler : MonoBehaviour {

    public Text textbox;
    bool textboxOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (textboxOpen && Input.GetKeyDown(KeyCode.Space))
        {
            clearTextbox();
        }
	}

    public void pickUpItemTextbox(string item)
    {
        textbox.text = "You got a " + item;
        textboxOpen = true;
    }

    public void useItemTextbox(string item)
    {
        textbox.text = "You used the " + item;
        textboxOpen = true;
    }

    public void itemNotInInventoryTextbox(string item)
    {
        textbox.text = "You don't have the " + item;
        textboxOpen = true;
    }

    void clearTextbox()
    {
        textbox.text = "";
        textboxOpen = true;
    }
}
