using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{
    private CheckersGraveyard graveyard;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        if (graveyard == null)
            graveyard = FindObjectOfType<CheckersGraveyard>();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = graveyard.Winners + " wins!";
    }
}
