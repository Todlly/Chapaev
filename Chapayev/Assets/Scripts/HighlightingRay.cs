using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightingRay : MonoBehaviour
{
    DirectionIndicator LineDrawer;
    Camera cam;
    int layerCheckers, layerBoard;
    private Checker selChecker, movingChecker;
    private bool selected = false, holded = false;
    private Vector3 direction;

    private Turns turnsManager;
    void Start()
    {
        LineDrawer = GameObject.FindObjectOfType<DirectionIndicator>();
        layerCheckers = LayerMask.GetMask("Checkers");
        layerBoard = LayerMask.GetMask("Board");
        cam = Camera.main;
        turnsManager = FindObjectOfType<Turns>();
    }

    void Update()
    {
        //selecting the checker under the cursor        
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray bRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerCheckers))
        {
            if (!selected)
            {
                if (turnsManager.CheckTurn(hit.transform.gameObject.GetComponent<Checker>()))
                {
                    selChecker = hit.transform.gameObject.GetComponent<Checker>();
                    selChecker.Highlight();
                    selected = true;
                }
            }
        }
        else if (selected)
        {
            if (!holded)
            {
                selChecker.DeHighlight();
                selChecker = null;
                selected = false;
            }
        }


        if (Input.GetMouseButton(0))
        {
            if (selected)
            {
                if (!holded)
                {
                    holded = true;
                }
                // getting hit direction
                RaycastHit boardHit;
                Physics.Raycast(bRay, out boardHit, Mathf.Infinity, layerBoard);
                Vector3 from = new Vector3(boardHit.point.x, selChecker.transform.position.y, boardHit.point.z);
                direction = selChecker.transform.position - from;
                if (direction.magnitude > 0.73f) //drawing aim
                    LineDrawer.DrawLine(boardHit.point + new Vector3(0f, 0.1f, 0f), selChecker.transform.position - (direction.normalized * 0.74f));
                else
                    LineDrawer.EraseLine();
            }
        }
        else if (holded) // hitting and deselecting
        {
            selChecker.Hit(direction, 300f);
            LineDrawer.EraseLine();
            movingChecker = selChecker;
            holded = false;
        }

        if (movingChecker != null && movingChecker.GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            turnsManager.ChangeTurn();
            movingChecker = null;
        }

    }

    public void ClearMovingChecker()
    {
        movingChecker = null;
    }

    public bool CheckChecker(GameObject checker)
    {
        if (checker.GetComponent<Checker>() == movingChecker)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
