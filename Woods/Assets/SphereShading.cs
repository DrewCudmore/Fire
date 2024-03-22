using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShading : MonoBehaviour
{
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("true");
            mat.SetColor("_EmissionColor", new Color32(42, 163, 158, 0));
        }

    }
}
