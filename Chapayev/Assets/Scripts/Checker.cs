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
        GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Checker")
            GetComponent<AudioSource>().Play();
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
