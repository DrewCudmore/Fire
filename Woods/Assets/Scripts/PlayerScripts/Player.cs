using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float interactionRange = 4f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Awake()
    {
        //gameManager = GameManager.Instance;

        //// Not needed for initial spawn
        //if (gameManager && gameManager.getLastCheckpoint() != null)
        //{
            
        //    Transform spawn = gameManager.getLastCheckpoint();

        //    this.transform.position = spawn.position;
        //    this.transform.rotation = spawn.rotation;
        //}

        //print(gameManager);

        //if (gameManager)
        //{
        //    print(gameManager.getLastCheckpoint());
        //}
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
            {
                // Check if the hit object is interactable
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.ShowDeathScreen("Player Pressed R");
            //this.transform.position = new Vector3(1, 1, 1);
        }

    }



}
