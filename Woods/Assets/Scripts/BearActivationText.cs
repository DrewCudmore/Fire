using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearActivationText : MonoBehaviour
{
    private TextPanel textPanel;
    private int needHelp = 0;
    private bool berries;

    void Start()
    {
        textPanel = FindObjectOfType<TextPanel>();
       
    }
    private void Update()
    {
        berries = Barrel.isFull;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (berries)
        {
            gameObject.SetActive(false);
        }
        else if (needHelp <= 2)
        {
            textPanel.DisplayText("I should find some food to draw away the bear");
            needHelp += 1;
        }
        else
        {
            textPanel.DisplayText("I should find a way to draw away the bear so I can go into the cave...");
        }

    }
}