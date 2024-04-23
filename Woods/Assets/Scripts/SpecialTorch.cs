using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTorch : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool CanInteract { get; set; } = true;
    private GameObject lanternColor;
    public GameObject blueLight;
    public GameObject redLight;
    public GameObject greenLight;
    public GameObject regLight;

    public bool blue;
    public bool red;
    public bool green;

    void Start()
    {
        lanternColor = GameObject.FindGameObjectWithTag("LanternColor");
    }

    public Item Interact()
    {
        Torch();
        //Debug.Log("hi");
        return Item.None;
    }

    void Torch()
    {
        if (lanternColor.GetComponent<Lantern>().colorBlue)
        {
            redLight.SetActive(false);
            greenLight.SetActive(false);
            blueLight.SetActive(true);
            regLight.SetActive(false);
            //if (blue)
            //{
            //    CanInteract = false;
            //}

        }
        if (lanternColor.GetComponent<Lantern>().colorRed)
        {
            blueLight.SetActive(false);
            redLight.SetActive(true);
            greenLight.SetActive(false);
            regLight.SetActive(false);
            //if (red)
            //{
            //    CanInteract = false;
            //}
        }
        if (lanternColor.GetComponent<Lantern>().colorGreen)
        {
            blueLight.SetActive(false);
            redLight.SetActive(false);
            greenLight.SetActive(true);
            regLight.SetActive(false);
            //if (green)
            //{
            //    CanInteract = false;
            //}
        }
        if (lanternColor.GetComponent<Lantern>().colorReg)
        {
            blueLight.SetActive(false);
            redLight.SetActive(false);
            greenLight.SetActive(false);
            regLight.SetActive(true);
        }
    }
}
