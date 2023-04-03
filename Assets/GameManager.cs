using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    SimonButton[] buttons;
    int roundNumber = 5;
    SimonButton[] sequence;
    SimonButton lastPlayerInput;
    int playerInputPosition = 0;
    int victoryNumber = 10;
    bool nextRound = false;
    
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
            int step = r.Next(buttons.Length+1);
            sequence[i] = buttons[step];
        }
    }

    IEnumerator showSequence()
    {
        //make uninteractible
        for(int i = 0; i< sequence.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            sequence[i].AIClick();
        }
    }

    void letPlayerPlay()
    {
        //make interactible
        while (!nextRound)
        {
            takePlayerInput();
        }
    }

    void takePlayerInput()
    {
        SetLatestPlayerButton();
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

    void SetLatestPlayerButton(SimonButton latest)
    {
        lastPlayerInput = latest;
        playerInputPosition++;
    }

    bool checkWinCondition()
    {
        return roundNumber> victoryNumber;
    }
}
