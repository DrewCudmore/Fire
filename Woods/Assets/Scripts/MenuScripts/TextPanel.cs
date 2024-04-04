using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    [SerializeField] private bool isPanel;
    public TextMeshProUGUI displayText;

    // Static reference to the TextPanel instance
    public static TextPanel instance;

    // Awake is called before Start
    void Awake()
    {
        // Set the static reference to this instance
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TogglePanel();
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

    public void TogglePanel()
    {
        if (textPanel.activeSelf)
        {
            DeactivatePanel();
        }
        else
        {
            ActivatePanel();
        }
    }

    public void DisplayText(string text)
    {
        // Set the display text
        displayText.text = text;

        // Activate the panel
        ActivatePanel();

        // Start the timer coroutine
        StartCoroutine(TurnOffPanelAfterDelay(4f));
    }

    private IEnumerator TurnOffPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the panel after the delay
        DeactivatePanel();
    }
}
