using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour {

    public int changeLevelAmount;
    public GameObject button;

    void OnTriggerStay(Collider c)
    {
        if (Input.GetKeyDown(KeyCode.Space)&&c.transform.tag.Equals("Player"))
        {
            if (changeLevelAmount == 0 && Elevator.currentLevel == Elevator.goalLevel)
            {
                Debug.Log("You Won");
            }
            button.GetComponent<Animator>().Play("_Push",-1,0f);
            Elevator.currentLevel += changeLevelAmount;
        }
        
    }


}
