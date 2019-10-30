using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersGraveyard : MonoBehaviour
{
    [SerializeField]
    private GameObject[] whiteGraves = new GameObject[8];
    [SerializeField]
    private GameObject[] blackGraves = new GameObject[8];

    private int whiteGravesCounter = 0, blackGravesCounter = 0;

    public void PutToGraveyard(GameObject diedChecker, string color)
    {
        if (color == "white")
        {
            diedChecker.transform.position = whiteGraves[whiteGravesCounter].transform.position;
            whiteGravesCounter++;
        }else if(color == "black")
        {
            diedChecker.transform.position = blackGraves[blackGravesCounter].transform.position;
            blackGravesCounter++;
        }

        diedChecker.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        diedChecker.GetComponent<Collider>().enabled = false;

        if (whiteGravesCounter == 8 || blackGravesCounter == 8)
        {

        }
    }
}
