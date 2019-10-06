using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Turns turnsManager;

    private HighlightingRay highl;
    void Start()
    {
        turnsManager = FindObjectOfType<Turns>();
        highl = FindObjectOfType<HighlightingRay>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Checker"))
        {
            if (highl.CheckChecker(other.gameObject))
            {
                highl.ClearMovingChecker();
                turnsManager.ChangeTurn();
            }
            GameObject.Destroy(other.gameObject, 0f);
        }
    }
}
