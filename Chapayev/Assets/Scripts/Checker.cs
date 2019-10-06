using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public Material highlightedMat;
    public Material defaultMat;
    public string color;
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

    public void Hit(Vector3 direction, float power)
    {
        GetComponent<Rigidbody>().velocity = direction * power * Time.deltaTime;
    }
}
