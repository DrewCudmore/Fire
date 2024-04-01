using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IInteractable
{

    public Item Interact()
    {
        Destroy(this.gameObject);
        return Item.Axe;
    }
}
