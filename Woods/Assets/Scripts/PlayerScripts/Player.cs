using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float interactionRange = 4f;
    private GameManager gameManager;

    private List<Item> inventory = new List<Item>();

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        HandleInteractions();
        HandleRestartInput();
    }

    private void HandleInteractions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    AddToInventory(interactable.Interact());
                }
            }
        }
    }

    private void HandleRestartInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.KillPlayer("Player Pressed 'R'");
        }
    }

    // If this class gets too large, we can extract inventory management to a singleton InventoryManager
    private void AddToInventory(Item item)
    {
        if (item != Item.None)
        {
            inventory.Add(item);
        }
    }

    public void RemoveFromInventory(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
        }
    }

    public bool CheckInventory(Item item, int num = 1)
    {
        int itemCount = 0;

        foreach (Item inventoryItem in inventory)
        {
            if (inventoryItem == item)
            {
                itemCount++;
                if (itemCount >= num)
                {
                    return true; 
                }
            }
        }

        return false;
    }


}
