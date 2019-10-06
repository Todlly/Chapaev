using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersSpawner : MonoBehaviour
{
    public GameObject blackSpawners, whiteSpawners, blackChecker, whiteChecker;
    private Transform[] blackPositions, whitePositions;

    private void Start()
    {
        blackPositions = blackSpawners.GetComponentsInChildren<Transform>();
        whitePositions = whiteSpawners.GetComponentsInChildren<Transform>();

        foreach (var transform in blackPositions)
        {
            GameObject.Instantiate(blackChecker, transform.position, transform.rotation);
        }

        foreach (var transform in whitePositions)
        {
            GameObject.Instantiate(whiteChecker, transform.position, transform.rotation);
        }
    }
}
