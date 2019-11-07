using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    public string turn;
    public GameObject posWhite, posBlack, neededPosition;
    bool camIsMoving;
    private void Start()
    {
        this.transform.position = posWhite.transform.position;
        this.transform.rotation = posWhite.transform.rotation;
        turn = "white";
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ChangeTurn();
        }
        ChangeCameraPosition();
    }
    private void ChangeCameraPosition()
    {
        if (camIsMoving && neededPosition != null)
        {
            if ((neededPosition.transform.position - this.transform.position).magnitude >= 0.01f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, neededPosition.transform.position, 5f * Time.deltaTime);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, neededPosition.transform.rotation, 0.06f);
            }
            else
            {
                this.transform.position = neededPosition.transform.position;
                this.transform.rotation = neededPosition.transform.rotation;
                neededPosition = null;
                camIsMoving = false;
            }
        }
    }
    public bool CheckTurn(Checker checker)
    {
        if (checker.color == turn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeTurn()
    {
        if (turn == "white")
        {
            neededPosition = posBlack;
            camIsMoving = true;
            turn = "black";
        }
        else
        {
            neededPosition = posWhite;
            camIsMoving = true;
            turn = "white";
        }
    }
}
