using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = true;
    public bool colorBlue;
    public bool colorRed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void ChangeColor()
    {
        if (colorBlue)
        {
            player.GetComponentInChildren<Lantern>().changeColorBlue = true;
            player.GetComponentInChildren<Lantern>().ChangeColor();
        }
        if (colorRed)
        {
            player.GetComponentInChildren<Lantern>().changeColorRed = true;
            player.GetComponentInChildren<Lantern>().ChangeColor();
        }
    }

    public Item Interact()
    {
        ChangeColor();
        return Item.None;
    }
}
