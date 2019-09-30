using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightingRay : MonoBehaviour
{
    Camera cam;
    int layerCheckers, layerBoard;
    private Checker selChecker;
    private bool selected = false, holded = false;
    private Vector3 direction;
    void Start()
    {
        layerCheckers = LayerMask.GetMask("Checkers");
        layerBoard = LayerMask.GetMask("Board");
        cam = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray bRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerCheckers))
        {
            if (!selected)
            {
                selChecker = hit.transform.gameObject.GetComponent<Checker>();
                selChecker.Highlight();
                selected = true;
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
                RaycastHit boardHit;
                Physics.Raycast(bRay, out boardHit, Mathf.Infinity, layerBoard);
                Debug.Log(direction.ToString());
                Debug.Log("hitpos " + boardHit.point);
                Vector3 from = new Vector3(boardHit.point.x, selChecker.transform.position.y, boardHit.point.z);
                direction = selChecker.transform.position - from;
            }
        }
        else if (holded)
        {
            selChecker.transform.gameObject.GetComponent<Rigidbody>().AddForce(direction * 300);
            holded = false;
        }
    }
}
