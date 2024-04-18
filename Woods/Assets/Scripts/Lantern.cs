using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    //blue
    public GameObject blueLight;
    public GameObject redLight;
    public GameObject greenLight;
    public bool changeColorBlue = false;
    public bool changeColorRed = false;
    public bool changeColorGreen = false;

    public bool changeColorRegular;
    public GameObject regularLight;

    public void ChangeColor()
    {
        if (changeColorBlue)
        {
            regularLight.SetActive(false);
            redLight.SetActive(false);
            greenLight.SetActive(true);
            blueLight.SetActive(true);
            changeColorBlue = false;
        }
        if (changeColorRegular)
        {
            blueLight.SetActive(false);
            redLight.SetActive(false);
            greenLight.SetActive(true);
            regularLight.SetActive(true);
            changeColorRegular = false;
        }

        if (changeColorRed)
        {
            regularLight.SetActive(false);
            blueLight.SetActive(false);
            greenLight.SetActive(true);
            redLight.SetActive(true);
            changeColorRed = false;
        }

        if (changeColorGreen)
        {
            regularLight.SetActive(false);
            blueLight.SetActive(false);
            redLight.SetActive(false);
            greenLight.SetActive(true);
            changeColorGreen = false;
        }

    }
}
