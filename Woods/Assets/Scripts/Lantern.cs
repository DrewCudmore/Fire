using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    //blue
    public GameObject blueLight;
    public bool changeColorBlue = false;

    public bool changeColorRegular;
    public GameObject regularLight;

    public void ChangeColor()
    {
        if (changeColorBlue)
        {
            regularLight.SetActive(false);
            blueLight.SetActive(true);
            changeColorBlue = false;
        }
        if (changeColorRegular)
        {
            blueLight.SetActive(false);
            regularLight.SetActive(true);
            changeColorRegular = false;
        }

    }
}
