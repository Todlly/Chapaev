using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public Material highlightedMat;
    public Material defaultMat;
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    public void Highlight()
    {
        rend.material = highlightedMat;
    }

    public void DeHighlight()
    {
        rend.material = defaultMat;
    }

    public void Hit()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 300);
    }
}
