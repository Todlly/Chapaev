using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checker"))
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
