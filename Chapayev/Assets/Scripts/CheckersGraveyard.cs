using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersGraveyard : MonoBehaviour
{
    [SerializeField]
    private GameObject[] whiteGraves = new GameObject[8];
    [SerializeField]
    private GameObject[] blackGraves = new GameObject[8];
    public string Winners;
    public GameObject WinMenu;

    public CheckersCounter whiteCounter, blackCounter;

    private int whiteGravesCounter = 0, blackGravesCounter = 0;

    public void PutToGraveyard(GameObject diedChecker, string color)
    {
        if (color == "white")
        {
            diedChecker.transform.position = whiteGraves[whiteGravesCounter].transform.position;
            whiteGravesCounter++;
            whiteCounter.RemovePoint();
        }else if(color == "black")
        {
            diedChecker.transform.position = blackGraves[blackGravesCounter].transform.position;
            blackGravesCounter++;
            blackCounter.RemovePoint();
        }

        diedChecker.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        diedChecker.GetComponent<Collider>().enabled = false;

        if (whiteGravesCounter == 8)
        {
            Winners = "Black";
            WinMenu.SetActive(true);
        }else if(blackGravesCounter == 8)
        {
            Winners = "White";
            WinMenu.SetActive(true);
        }
    }
}
