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
        FindObjectOfType<HighlightingRay>().ClearAliveCheckers();
        foreach (var spawner in blackSpawners)
        {
            GameObject checker = GameObject.Instantiate(blackChecker, spawner.transform.position, spawner.transform.rotation);
            FindObjectOfType<HighlightingRay>().AddAliveChecker(checker);
        }

        foreach (var spawner in whiteSpawners)
        {
            GameObject checker = GameObject.Instantiate(whiteChecker, spawner.transform.position, spawner.transform.rotation);
            FindObjectOfType<HighlightingRay>().AddAliveChecker(checker);
        }
    }
}
