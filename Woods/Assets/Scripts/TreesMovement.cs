using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float timer_cooldown = 1f;
    private bool timer_locked_out = false;

    Vector3 treePosition;
    public float treeSpeed;
    public float treeShakeAmount;
    public bool shakeTree;

    void Start()
    {
        treePosition = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shakeTree)
        {
            Vector3 tempTreePos = treePosition;
            tempTreePos.x += Mathf.Sin(Time.time * treeSpeed) * treeShakeAmount;
            transform.position = tempTreePos;
            ShakeTreeTime();
        }
        
        
    }

    private void ShakeTreeTime()
    {
        if (timer_locked_out == false)
        {
            timer_locked_out = true;

            StartCoroutine(ShakeTime());
        }
    }

    IEnumerator ShakeTime()
    {
        yield return new WaitForSeconds(timer_cooldown);
        timer_locked_out = false;
        shakeTree = false;
    }
}
