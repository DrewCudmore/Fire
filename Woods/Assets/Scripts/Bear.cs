using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Rigidbody rb;
    Animator ani;

    public BoxCollider startWalking;
    public BoxCollider attackPlayer;

    public int triggerCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

        startWalking = GetComponent<BoxCollider>();
        attackPlayer = GetComponent<BoxCollider>();

        ani.SetBool("Walking", false);
        ani.SetBool("Running", false);
        ani.SetBool("Turning", false);
        ani.SetBool("Attack", false);
        ani.SetBool("Eating", false);
        ani.SetBool("Sitting", false);
        ani.SetBool("Sleeping", true);
        //ani.SetBool("", false);
        //ani.SetBool("", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerCounter++;
            Debug.Log("current trigger value on enter " + triggerCounter);
            if (triggerCounter == 1)
            {
                Debug.Log("bear started walking");
                ani.SetBool("Walking", true);
                ani.SetBool("Sleeping", false);
            }
            else if (triggerCounter == 2)
            {
                Debug.Log("bear attacked");
                ani.SetBool("Attack", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerCounter == 2)
            {
                Debug.Log("bear stop attack");
                ani.SetBool("Attack", false);
            }
            else if (triggerCounter == 1)
            {
                Debug.Log("bear stop walking");
                ani.SetBool("Walking", false);
                ani.SetBool("Sleeping", true);
            }
            triggerCounter--;
            Debug.Log("current trigger value on exit " + triggerCounter);
        }
    }
}
