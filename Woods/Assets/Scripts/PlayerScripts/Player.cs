using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cam;
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

            if (Physics.Raycast(cam.position, cam.forward, out hit, interactionRange))
            {
                TryGettingItem(hit);
                TryShowingDialogue(hit);
            }
        }
    }

    private void TryGettingItem(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out IInteractable interactable))
        {
            AddToInventory(interactable.Interact());
        }
    }

    private void TryShowingDialogue(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out IDialogue dialogueComponent))
        {
            TextPanel.instance.DisplayText(dialogueComponent.dialogue);
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

        HandleInventoryInteractions(item);
    }

    private void HandleInventoryInteractions(Item item)
    {
        if (item == Item.Axe)
        {
            EnableChoppingTrees();
        }
        else if (item == Item.Wood && inventory.Count(item => item == Item.Wood) >= 3)
        {
            EnableFixingBridge();
        }
    }

    private void EnableChoppingTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("ChoppableTree");

        foreach (GameObject tree in trees)
        {
            if (tree.GetComponent<IInteractable>() != null)
            {
                tree.GetComponent<IInteractable>().CanInteract = true;
            }
        }
    }

    private void EnableFixingBridge()
    {
        BrokenBridge brokenBridge = FindObjectOfType<BrokenBridge>();
        IInteractable interactableBridge = brokenBridge.GetComponent<IInteractable>();
        if (interactableBridge != null)
        {
            interactableBridge.CanInteract = true;
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
