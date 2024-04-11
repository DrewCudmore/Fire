using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = true;

    private SceneSwitcher sceneSwitcher;


    public Item Interact()
    {
        sceneSwitcher?.SwitchScene();

        return Item.None;
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = this.GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
