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
            //Debug.Log("current trigger value on enter " + triggerCounter);
            switch (triggerCounter)
            {
                case 1:
                    ani.SetBool("Walking", true);
                    ani.SetBool("Sleeping", false);
                break;

                case 2:
                    ani.SetBool("Attack", true);
                    break;

                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (triggerCounter)
            {
                case 1:
                    ani.SetBool("Walking", false);
                    ani.SetBool("Sleeping", true);
                    break;

                case 2:
                    ani.SetBool("Attack", false);
                    break;

                default:
                    break;
            }
            triggerCounter--;
        }
    }
}
