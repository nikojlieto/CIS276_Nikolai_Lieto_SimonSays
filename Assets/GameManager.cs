using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    SimonButton[] buttons;
    static int victoryNumber = 10;
    int roundNumber = 5;
    SimonButton[] sequence = new SimonButton[victoryNumber];
    SimonButton lastPlayerInput;
    int playerInputPosition = 0;
    bool nextRound = false;
    
    void Start()
    {
        playGame();
    }

    void playGame()
    {
        while (!checkWinCondition())
        {
            generateSequence();
            StartCoroutine(showSequence());
            letPlayerPlay();
        } 
    }

    void generateSequence()
    {
        var r = new System.Random();
        for(int i = 0; i< roundNumber; i++)
        {
            int step = r.Next(buttons.Length);
            sequence[i] = buttons[step];
        }
    }

    IEnumerator showSequence()
    {
        //make uninteractible
        foreach (SimonButton button in buttons)
        {
            button.interactable = false;
        }
        for(int i = 0; i< sequence.Length; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(0.5f);
            sequence[i].AIClick();
        }
    }

    void letPlayerPlay()
    {
        //make interactible
        foreach (SimonButton button in buttons)
        {
            button.interactable = true;
        }
        while (!nextRound)
        {
            takePlayerInput();
        }
    }

    void takePlayerInput()
    {
        playerInputPosition++;
        checkPlayerInput();
    }

    void checkPlayerInput()
    {
        if(sequence[playerInputPosition] != lastPlayerInput)
        {
            playerInputPosition = 0;
            StartCoroutine(showSequence());
        }
    }

    public void SetLatestPlayerButton(SimonButton latest)
    {
        lastPlayerInput = latest;
        playerInputPosition++;
    }

    bool checkWinCondition()
    {
        return roundNumber> victoryNumber;
    }
}
