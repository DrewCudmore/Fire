using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTrigger : MonoBehaviour
{
    public Transform cam;
    public float Distance;
    public bool active = false;
    GameObject[] interactables;

    // Start is called before the first frame update
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject obj in interactables)
        {
            obj.AddComponent<Outline>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in interactables)
        {
            Vector3 diff = obj.transform.position - cam.position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance <= Distance)
            {
                Highlight(obj);
            }
            else
            {
                Unhighlight(obj);
            }
        }
    }

    void Highlight(GameObject closeObj)
    {
        Outline outline = closeObj.GetComponent<Outline>();
        outline.enabled = true;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 10f;
    }

    void Unhighlight(GameObject notCloseObj)
    {
        Outline outline = notCloseObj.GetComponent<Outline>();
        outline.enabled = false;
    }
}
