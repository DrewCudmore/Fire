using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = true;
    public GameObject berryParent;

    public Item Interact()
    {
        Destroy(berryParent);

        return Item.Berries;
    }
}