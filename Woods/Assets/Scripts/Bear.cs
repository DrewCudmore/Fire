using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Rigidbody rb;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

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
            ani.SetBool("Walking", true);
            ani.SetBool("Sleeping", false);
        }
    }
}
