using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MonoBehaviour
{
    public Rigidbody rb;
    Animator ani;
    private GameManager gameManager;

    public BoxCollider startWalking;
    public BoxCollider attackPlayer;

    public int triggerCounter = 0;
    public bool targettingPlayer = false;

    public Transform target;
    NavMeshAgent agent;
    private Vector3 home;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

        startWalking = GetComponent<BoxCollider>();
        attackPlayer = GetComponent<BoxCollider>();

        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

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
        if (!targettingPlayer)
        {
            agent.Move(home);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerCounter++;
            Debug.Log("current trigger value on enter " + triggerCounter);
            switch (triggerCounter)
            {
                case 1:
                    ani.SetBool("Walking", true);
                    ani.SetBool("Sleeping", false);
                break;

                case 2:
                    agent.SetDestination(target.position);
                    targettingPlayer = true;
                break;

                case 3:
                    ani.SetBool("Attack", true);
                    gameManager.KillPlayer("BEAR ATTACK AAAAAAAAAAHHHHH");

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
                    agent.ResetPath();
                    break;

                case 2:
                    //agent.Move(home);
                    targettingPlayer = false;
                    break;

                case 3:
                    ani.SetBool("Attack", false);
                    //triggerCounter--;
                    break;

                default:
                    break;
            }
            triggerCounter--;
        }
    }
}
