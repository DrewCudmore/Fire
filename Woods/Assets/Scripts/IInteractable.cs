using UnityEngine;

public interface IInteractable
{
    Item Interact();
}

// Anything that needs to enter the player inventory
public enum Item
{
    None,          
    Axe,          
    Wood,          
}