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
    private float halfIntensity;
    private float nearlyOutIntensity;
    public bool textIntensity = false;

    private float deincrementLight = .0009f;

    public float deincrementIntensity;
    public float deincrementRange;
    private float colorChangeRate = .0009f;

    public bool resetLantern = false;

    private GameManager gameManager;
    private TextPanel textPanel;
    //private 

    void Start()
    {
        myLight = GetComponent<Light>();
        textPanel = FindObjectOfType<TextPanel>(); 
        gameManager = GameManager.Instance;
        originalIntensity = myLight.intensity;
        originalRange = myLight.range;
        originalColor = myLight.color;

        halfIntensity = originalIntensity / 2;
        nearlyOutIntensity = 1f;

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
            if((myLight.intensity < halfIntensity) & (myLight.intensity > halfIntensity - .5 ) & (textIntensity == false))
            {
                textIntensity = true;
                LanternBattery(halfIntensity);
            }

            else if ((myLight.intensity < nearlyOutIntensity) & (myLight.intensity > nearlyOutIntensity - .5) & (textIntensity == true))
            {
                textIntensity = false;
                LanternBattery(nearlyOutIntensity);
            }

        }
        if (resetLantern)
        {
            ResetLantern();
            resetLantern = false;
        }
    }

    public void ResetLantern()
    {
        myLight.intensity = originalIntensity;
        myLight.range = originalRange;
        myLight.color = originalColor;
        textIntensity = false;
    }
    void LanternBattery(float intensity)
    {
        
        if (intensity == halfIntensity)
        {
            textPanel.DisplayText("Looks like my light is about halfway out, I should refill it at a campfire.");
        }

        if (intensity == nearlyOutIntensity)
        {
            textPanel.DisplayText("I'm almost out of light, I should refill at a campfire.");
        }
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
