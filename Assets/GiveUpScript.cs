using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveUpScript : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private Button giveUpButton;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        giveUpButton.onClick.AddListener(RestartRoutine);
    }

    private void RestartRoutine()
    {
        Debug.Log("restart");
        gameManager.RestartRoutine();
    }
}
