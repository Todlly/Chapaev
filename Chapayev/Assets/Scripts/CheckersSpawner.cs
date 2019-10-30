using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersSpawner : MonoBehaviour
{
    public GameObject blackChecker, whiteChecker;

    [SerializeField]
    private GameObject[] blackSpawners = new GameObject[8];
    [SerializeField]
    private GameObject[] whiteSpawners = new GameObject[8];

    private void Start()
    {
        foreach (var spawner in blackSpawners)
        {
            GameObject.Instantiate(blackChecker, spawner.transform.position, spawner.transform.rotation);
        }

        foreach (var spawner in whiteSpawners)
        {
            GameObject.Instantiate(whiteChecker, spawner.transform.position, spawner.transform.rotation);
        }
    }
}
