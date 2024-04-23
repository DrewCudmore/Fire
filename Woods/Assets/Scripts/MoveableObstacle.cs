using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObstacle : MonoBehaviour
{

    public SpecialTorch blueTorch;
    public SpecialTorch redTorch;
    public SpecialTorch greenTorch;

    public float moveSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckColors())
        {
            MoveAway();
        }
    }

    private bool CheckColors()
    {
        return blueTorch.isCorrectColor && redTorch.isCorrectColor && greenTorch.isCorrectColor;
    }

    private void MoveAway()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }



}
