using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public Material highlightedMat;
    public Material defaultMat;
    public string color;
    private Renderer rend;
    public GameObject floor;
    private CheckersGraveyard graveYard;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        graveYard = FindObjectOfType<CheckersGraveyard>();
    }

    public void Highlight()
    {
        rend.material = highlightedMat;
    }

    private void Update()
    {
        if(transform.position.y <= floor.transform.position.y)
        {
            Die();
        }
    }

    public void DeHighlight()
    {
        rend.material = defaultMat;
    }

    public void Hit(Vector3 direction, float power)
    {
        GetComponent<Rigidbody>().velocity = direction * power * Time.deltaTime;
    }

    private void Die()
    {
        HighlightingRay manager = FindObjectOfType<HighlightingRay>();
        manager.DeleteAliveChecker(gameObject);
        PointAdd();
    }

    private void PointAdd()
    {
        graveYard.PutToGraveyard(gameObject, color);
    }
}
