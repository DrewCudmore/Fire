using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentIndex = 0;
    private float speed = 2f;



    //int index = 0;
    //public Bear bear;
    //public List<Transform> Waypoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        //bear = GetComponent<Bear>();
        //bear = GameObject.FindGameObjectWithTag("Bear");
    }

    // Update is called once per frame
    void Update()
    {
        Transform point = waypoints[currentIndex];
        if (Vector3.Distance(transform.position, point.position) < 0.01f)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        //if (other.CompareTag("Bear"))
        //{
        //    StartPatrolling(ref index);
        //}
    }

    void StartPatrolling(ref int index)
    {
        //if (index > Waypoints.Count)
        //{
        //    index = 0;
        //}
        //Debug.Log("start patrolling");
        //bear.StartPatrolling(ref index);
        
        //index++;
    }
}
