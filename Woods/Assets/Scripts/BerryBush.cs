using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = true;
    public GameObject berryParent;
    private TextPanel textPanel;
    private int berriesLeftToCollect = 3;
    void Start()
    {
        textPanel = FindObjectOfType<TextPanel>();
    }
    public Item Interact()
    {
        berriesLeftToCollect -= 1;
        if (berriesLeftToCollect == 2)
        {
            textPanel.DisplayText("I should collect more of these.");
        }
        if (berriesLeftToCollect == 1)
        {
            textPanel.DisplayText("I wonder what I can use these for, I should get more.");
        }
        if (berriesLeftToCollect == 0)
        {
            textPanel.DisplayText("I should put these somewhere to draw away the bear.");
        }
        Destroy(berryParent);

        return Item.Berries;
    }

}
