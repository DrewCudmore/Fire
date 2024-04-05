using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Item> inventory = new List<Item>();
    private TextPanel textPanel;

    private void Start()
    {
        textPanel = FindObjectOfType<TextPanel>();
    }

    public void AddToInventory(Item item)
    {
        if (item != Item.None)
        {
            inventory.Add(item);
            HandleInventoryInteractions(item);
        }
    }

    private void HandleInventoryInteractions(Item item)
    {
        if (item == Item.Axe)
        {
            EnableChoppingTrees();
        }
        else if (item == Item.Wood && inventory.Count(i => i == Item.Wood) >= 2)
        {
            textPanel.DisplayText("That should be enough wood");
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
        return inventory.Count(i => i == item) >= num;
    }
}