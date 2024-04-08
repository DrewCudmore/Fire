using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    // Start is called before the first frame update
    public Light myLight;
    public float originalIntensity;// = myLight.intensity;
    public float deincrementLight;
    private float deincrementIntensity = .0001f;
    private GameManager gameManager;
    //private 
    
    void Start()
    {
        myLight = GetComponent<Light>();
        gameManager = GameManager.Instance;
        originalIntensity = myLight.intensity;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            myLight.intensity -= (deincrementLight * deincrementIntensity);
            checkBurnout();
        }
    }

    void checkBurnout()
    {
        Debug.Log(myLight.intensity);
        if (myLight.intensity <= 0.0)
        {
            gameManager.KillPlayer("Lantern burned out\nRefill lantern at a campfire");
            myLight.intensity = originalIntensity;
        }
    }


}
