using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    // Start is called before the first frame update
    public Light myLight;
    public float deincrementLight;
    private float deincrementIntensity = .0001f;
    void Start()
    {
        myLight = GetComponent<Light>();


    }

    // Update is called once per frame
    void Update()
    {
        myLight.intensity -= (deincrementLight * deincrementIntensity);
    }
}
