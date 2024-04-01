using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTrigger : MonoBehaviour
{
    public Transform cam;
    public float Distance;
    public bool active = false;
    public GameObject player;
    Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.AddComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Distance);
        active =  hit.collider.gameObject == gameObject;



        if (active == true)
        {
            outline.enabled = true;
            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 10f;
        }

        else if (active == false)
        {
            outline.enabled = false;
            //outline.OutlineMode = Outline.Mode.OutlineHidden;
        }
    }

}
