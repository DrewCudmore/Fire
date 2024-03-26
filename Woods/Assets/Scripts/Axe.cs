using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IInteractable
{
    private void Start()
    {
        print("Axe script started");
    }

    public Item Interact()
    {
        print("Interacting");
        //Destroy(this.gameObject);
        return Item.Axe;
    }
}
