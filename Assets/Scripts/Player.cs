using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public bool interactionPossible = false;
    private Rigidbody rb;
    public GameObject inCollision;

    public bool justPorted = false;
    public float soundSpeed;

    static Vector3 rotationVector;
    static Vector3 translationVector;
    Quaternion startRotation;

    private List<string> inventory = new List<string>();

    void Start()
    {
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rotationVector = new Vector3(1, 0, 0);
        translationVector = new Vector3(0, 0, 1);
    }

    void Update()
    {
        if (interactionPossible && Input.GetKeyDown(KeyCode.E))
        {
            inCollision.GetComponent<InteractionObject>().interaction();
        }

        Ray ray = new Ray(transform.position, Physics.gravity / 9.81f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag.Equals("Wood"))
            {
                Debug.Log("YAY");

                ProgressMenuScript.setProgressVal(ProgressBarScript.value - soundSpeed*Time.deltaTime);
            }
            else
            {
                if(ProgressBarScript.value < 1.0f)
                    ProgressMenuScript.setProgressVal(ProgressBarScript.value + soundSpeed * Time.deltaTime/5);
            }
        }


    }

    void FixedUpdate()
    {
        float x;
        float z;
        if (GravityHandler.currentGravityAxis.Equals("x") && GravityHandler.currentGravityBool)
        {

            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        }
        else
        {

            x = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            z = -Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        }

        Vector3 movement = -translationVector * x + rotationVector * z;

        //transform.Rotate(rotationVector*x);          //0 1 0
        //transform.Translate(translationVector*z);    //0 0 1
        transform.Translate(movement);

       
        

    }
   
    public void addItem(string item)
    {
        inventory.Add(item);
        Debug.Log("Item added");
    }
    public bool removeItem(string item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log("Item removed");
            return true;
        }
        else
        {
            Debug.Log("Item not in inventory");

            return false;
        }
    }

    public void setMovementVectors(Vector3 tra, Vector3 rot)
    {
        translationVector = tra;
        transform.rotation = startRotation;
        transform.Rotate(-90 * rot);
        //rotationVector = rot;
    }
    
    public IEnumerator portedPlayer()
    {
        justPorted = true;
        Debug.Log("Blocked teleporting");
        yield return new WaitForSeconds(1f);
        Debug.Log("Activated teleporting");
        justPorted = false;


    }

}
