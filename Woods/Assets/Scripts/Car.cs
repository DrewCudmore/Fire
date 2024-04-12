using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; } = true;
    private GameManager gameManager;

    private SceneSwitcher sceneSwitcher;


    public Item Interact()
    {
        gameManager.FadeOutScreen(gameManager.fadeDuration);
        sceneSwitcher.sceneToSwitchTo = "EndDriving";
        sceneSwitcher.SwitchSceneWithFadeOut(2);

        return Item.None;
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = this.GetComponent<SceneSwitcher>();
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
