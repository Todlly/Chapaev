using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    private LineRenderer line;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void DrawLine(Vector3 point1, Vector3 point2)
    {
        Vector3[] positions = new Vector3[] { point1, point2 };
        if (line.positionCount != 2)
            line.positionCount = 2;
        line.SetPositions(positions);
    }

    public void EraseLine()
    {
        line.positionCount = 0;
    }
}
