using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObstacle : MonoBehaviour
{

    public GameObject blueTorch;
    public GameObject redTorch;
    public GameObject greenTorch;

    public float moveSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckLit())
        {
            MoveAway();
        }
    }

    private bool CheckLit()
    {
        return blueTorch.GetComponent<IInteractable>().CanInteract && redTorch.GetComponent<IInteractable>().CanInteract && greenTorch.GetComponent<IInteractable>().CanInteract;
    }

    private void MoveAway()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }



}
