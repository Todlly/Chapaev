using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightingRay : MonoBehaviour
{
    DirectionIndicator LineDrawer;
    Camera cam;
    int layerCheckers, layerBoard;
    private Checker selChecker, movingChecker;
    private bool selected = false, holded = false, checkersSteady = true;
    private Vector3 direction;
    private List<GameObject> aliveCheckers = new List<GameObject>();

    private Turns turnsManager;

    public void AddAliveChecker(GameObject checker)
    {
        aliveCheckers.Add(checker);
    }
    public void DeleteAliveChecker(GameObject checker)
    {
        aliveCheckers.Remove(checker);
    }

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
                if (direction.magnitude > 0.22f) //drawing aim
                {
                    LineDrawer.DrawLine(boardHit.point + new Vector3(0f, 0.1f, 0f), selChecker.transform.position - (direction.normalized * 0.22f));
                }
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

        foreach(GameObject checker in aliveCheckers)
        {
            if(checker.GetComponent<Rigidbody>().velocity.magnitude != 0)
            {
                checkersSteady = false;
            }
        }

        if (movingChecker != null && checkersSteady)
        {
            turnsManager.ChangeTurn();
            movingChecker = null;
        }

        checkersSteady = true;
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
