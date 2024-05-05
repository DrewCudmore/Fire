using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveAudioHandler : MonoBehaviour
{
    public bool turnOnCave ;
    public bool caveBoundPassed ;
    // Start is called before the first frame update
    void Start()
    {
        turnOnCave = true;
        caveBoundPassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        caveBoundPassed = true;
        if (turnOnCave)
        {
            turnOnCave = false;
            caveBoundPassed = false;
        }
        else
        {
            turnOnCave = true;
            caveBoundPassed = false;
        }
        
    }
}
