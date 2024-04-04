using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = true;

    public Item Interact()
    {
        Destroy(this.gameObject);

        return Item.Axe;
    }
}
