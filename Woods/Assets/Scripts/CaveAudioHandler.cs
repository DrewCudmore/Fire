using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveAudioHandler : MonoBehaviour
{
    public bool inCave ;
    // Start is called before the first frame update
    void Start()
    {
        inCave = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(inCave);
    }

    private void OnTriggerEnter(Collider other)
    {
        inCave = !inCave;
    }
}
