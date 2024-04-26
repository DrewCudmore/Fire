using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = false;
    public GameObject barrel;
    public GameObject fullBarrel;

    public Item Interact()
    {
        if (barrel != null)
        {
            FillBarrel();
        }

        return Item.None;
    }

    public void FillBarrel()
    {
        Vector3 position = barrel.transform.position;
        barrel.SetActive(false);
        Instantiate(fullBarrel, position, Quaternion.identity);
    }
}
