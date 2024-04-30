using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = false;
    public GameObject barrel;
    public GameObject fullBarrel;
    private TextPanel textPanel;

    public static bool isFull = false;
    public bool isFullBarrel;
    public BoxCollider boxText;
    private void Start()
    {
        textPanel = FindObjectOfType<TextPanel>();
    }
    private void Update()
    {
        if (isFullBarrel)
        {
            isFull = true;
            boxText.enabled = false;
        }
    }
    public Item Interact()
    {
        if (barrel != null)
        {
            FillBarrel();
            
        }
        this.CanInteract = false;
        textPanel.DisplayText("The bear should eat these now.");
        return Item.None;
    }

    public void FillBarrel()
    {
        isFull = true;
        Vector3 position = barrel.transform.position;
        boxText.enabled = false;
        Instantiate(fullBarrel, position, Quaternion.identity);
        barrel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isFullBarrel)
        {
            textPanel.DisplayText("I could put food here for the bear.");
        }
       
    }
}
