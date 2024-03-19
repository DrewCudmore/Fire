using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    [SerializeField] private bool isPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPanel = !isPanel;
        }

        if (isPanel)
        {
            ActivatePanel();
        }
        else
        {
            DeactivatePanel();
        }
    }

    void ActivatePanel()
    {
        textPanel.SetActive(true);
    }

    void DeactivatePanel()
    {
        textPanel.SetActive(false);
    }

}