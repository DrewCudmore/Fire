using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    // Start is called before the first frame update
    public Light myLight;
    private float originalIntensity;// = myLight.intensity;
    private float originalRange;
    private Color originalColor;

    private float deincrementLight = .0009f;

    public float deincrementIntensity;
    public float deincrementRange;
    private float colorChangeRate = .0008f;

    private GameManager gameManager;
    //private 
    
    void Start()
    {
        myLight = GetComponent<Light>();
        gameManager = GameManager.Instance;
        originalIntensity = myLight.intensity;
        originalRange = myLight.range;
        originalColor = myLight.color;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            myLight.intensity -= (deincrementLight * deincrementIntensity);
            myLight.range -= (deincrementLight * deincrementRange);
            float colorLight = myLight.color.g;
            colorLight += colorChangeRate * Time.deltaTime;
            myLight.color = new Color(myLight.color.r, colorLight, myLight.color.b, myLight.color.a);
            checkBurnout();
        }
    }

    public void ResetLantern()
    {
        myLight.intensity = originalIntensity;
        myLight.range = originalRange;
        myLight.color = originalColor;
    }
    void checkBurnout()
    {
        //Debug.Log(myLight.intensity);
        if (myLight.intensity <= 0.0)
        {
            gameManager.KillPlayer("Lantern burned out\nRefill lantern at a campfire");
            ResetLantern();
        }
    }


}
