using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool getItem;
    public bool useItem;
    public string item;
    public string whatToDo;

    public GameObject player;
    public TextboxHandler tbh;

    public void testInteraction()
    {
        Debug.Log("Meow");
    }
    
    public void interaction()
    {
        if (getItem)
        {
            player.GetComponent<Player>().addItem(item);
            tbh.pickUpItemTextbox(item);

        }else if (useItem)
        {
            if (player.GetComponent<Player>().removeItem(item))
            {
                tbh.useItemTextbox(item);
                doSomething();
            }
            else
            {
                tbh.itemNotInInventoryTextbox(item);
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }

    void doSomething()
    {
        Debug.Log("WhatToDo: " + whatToDo);
        if (whatToDo.Equals("DestroyObject"))
        {
            Debug.Log("Object Destroyed");
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hi");
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<Player>().interactionPossible = true;
            col.gameObject.GetComponent<Player>().inCollision = this.gameObject;
        }

    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Bye");
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<Player>().interactionPossible = false;
            
        }

    }

}
