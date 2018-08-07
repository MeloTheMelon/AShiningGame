using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject destination;
    public string gravityAxis;
    public bool gravityBool;

    GravityHandler g;

    void Start()
    {
        g = GameObject.FindGameObjectsWithTag("GH")[0].GetComponent<GravityHandler>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (!c.gameObject.GetComponent<Player>().justPorted) {
            ChangeGravityField.reset = true;
            GravityHandler.changeGravity(destination.GetComponent<Portal>().gravityAxis, destination.GetComponent<Portal>().gravityBool);
            StartCoroutine(c.gameObject.GetComponent<Player>().portedPlayer());
            c.gameObject.transform.position = destination.transform.position;
        }
    }

}
