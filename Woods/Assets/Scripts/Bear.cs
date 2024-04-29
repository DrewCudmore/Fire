using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MonoBehaviour
{
    Animator ani;
    private GameManager gameManager;

    //public BoxCollider startWalking;
    public BoxCollider chasePlayer;
    public BoxCollider attackPlayer;

    public int triggerCounter = 0;
    public bool targettingPlayer = false;

    public Transform target;
    public Transform home;
    public Transform berries;
    public Transform berriesLook;
    NavMeshAgent agent;

    public Transform[] waypoints;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        ani = GetComponent<Animator>();

        //startWalking = GetComponent<BoxCollider>();
        chasePlayer = GetComponent<BoxCollider>();
        attackPlayer = GetComponent<BoxCollider>();

        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        

        ani.SetBool("Walking", true);
        ani.SetBool("Running", false);
        ani.SetBool("Turning", false);
        ani.SetBool("Attack", false);
        ani.SetBool("Eating", false);
        ani.SetBool("Sitting", false);
        ani.SetBool("Sleeping", false);
        //ani.SetBool("", false);
        //ani.SetBool("", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!targettingPlayer)
        {
            if (waypoints.Length > 0)
            {
                Transform point = waypoints[currentIndex];
                if (Vector3.Distance(transform.position, point.position) < 0.01f)
                {
                    currentIndex = (currentIndex + 1) % waypoints.Length;
                    //Debug.Log(currentIndex);
                }
                else
                {
                    agent.SetDestination(point.position);
                }
            }
            else
            {
                ani.SetBool("Sleeping", true);
                ani.SetBool("Walking", false);
                agent.enabled = false;
            }
        }
        if (Barrel.isFull)
        {
            agent.SetDestination(berries.position);
            chasePlayer.enabled = false;
            attackPlayer.enabled = false;
            if (agent.remainingDistance < 0.01f)
            {
                ani.SetBool("Eating", true);
                ani.SetBool("Walking", false);
                transform.LookAt(berriesLook);
            }
            //if (Vector3.Distance(transform.position, berries.position) < 0.01f)
            //{
            //}
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
                //case 1:
                //    ani.SetBool("Walking", true);
                //    ani.SetBool("Sleeping", false);
                //    break;

                case 1:
                    agent.SetDestination(target.position);
                    targettingPlayer = true;
                    break;

                case 2:
                    if (!Barrel.isFull)
                    {
                        ani.SetBool("Attack", true);
                        gameManager.KillPlayer("BEAR ATTACK AAAAAAAAAAHHHHH");
                    }

                    break;

                default:
                    break;
            }
        }
        //if (other.CompareTag("Waypoints"))
        //{
        //    Debug.Log("waypoint A reached");
        //    StartPatrolling(ref index);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (triggerCounter)
            {
                //case 1:
                //    ani.SetBool("Walking", false);
                //    ani.SetBool("Sleeping", true);
                //    agent.ResetPath();
                //    break;

                case 1:
                    targettingPlayer = false;
                    break;

                case 2:
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
