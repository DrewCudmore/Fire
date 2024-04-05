using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixableBridge : MonoBehaviour
{
    public GameObject fixedBridge;
    public GameObject brokenBridge;
    public GameObject bridgeBlocker;
    private TextPanel textPanel;

    void Start()
    {
        textPanel = FindObjectOfType<TextPanel>();

        fixedBridge = transform.Find("FixedBridge")?.gameObject;
        brokenBridge = transform.Find("BrokenBridge")?.gameObject;
        bridgeBlocker = transform.Find("BridgeBlocker")?.gameObject;

        // Check if FixedBridge is a child of this GameObject
        if (fixedBridge != null && fixedBridge.transform.parent == transform)
        {
            fixedBridge.SetActive(false);
        }
        else
        {
            Debug.LogWarning("FixedBridge not found as a child of the Bridge GameObject.");
        }
    }

    public void FixBridge()
    {
        if (fixedBridge != null && fixedBridge.transform.parent == transform)
        {
            fixedBridge.SetActive(true);
        }
        else
        {
            Debug.LogWarning("FixedBridge not found as a child of the Bridge GameObject.");
        }

        if (brokenBridge != null && brokenBridge.transform.parent == transform)
        {
            brokenBridge.SetActive(false);
        }
        else
        {
            Debug.LogWarning("BrokenBridge not found as a child of the Bridge GameObject.");
        }

        if (bridgeBlocker != null && bridgeBlocker.transform.parent == transform)
        {
            bridgeBlocker.SetActive(false);
        }
        else
        {
            Debug.LogWarning("BrokenBridge not found as a child of the Bridge GameObject.");
        }

    }

}
