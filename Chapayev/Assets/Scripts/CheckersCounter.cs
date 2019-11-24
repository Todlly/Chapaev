using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckersCounter : MonoBehaviour
{

    private int count;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        count = 8;
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        textMesh.text = "x" + count;
    }

    public void RemovePoint()
    {
        count--;
        textMesh.text = "x" + count;
    }
}
