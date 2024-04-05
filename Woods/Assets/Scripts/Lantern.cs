using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    // Start is called before the first frame update
    public Light myLight;
    public float deincrementLight;
    private float deincrementIntensity = .0001f;
    private GameManager gameManager;

    void Start()
    {
        myLight = GetComponent<Light>();
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        myLight.intensity -= (deincrementLight * deincrementIntensity);
        checkBurnout();
    }

    void checkBurnout()
    {
        if (myLight.intensity <= 0.0)
        {
            gameManager.KillPlayer("Lantern burned out\nRefill lantern at a campfire");
        }
    }


}
