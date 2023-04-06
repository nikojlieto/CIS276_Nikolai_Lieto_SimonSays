using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    //buttons for playing
    SimonButton[] buttons;
    //number of rounds to beat to win
    int victoryNumber = 2;
    //shows + tracks current round
    int roundNumber = 1;
    //sets size of sequence
    int arraySize = 2;
    //sequence to match, reset after each round
    SimonButton[] sequence = new SimonButton[2];
    //for checking against sequence
    SimonButton lastPlayerInput;
    //for checking against sequence/checking for next round
    int playerInputPosition = 0;
    //shows round number
    [SerializeField]
    public TextMeshProUGUI roundDisplay;
    //button appears for win message
    [SerializeField]
    Button winDisplay;
    
    void Start()
    {
        //start game, reset ui elements
        playGame();
        roundDisplay.text = "Round: "+ roundNumber;
        winDisplay.gameObject.SetActive(false);
    }

    void playGame()
    {       //check if you won before continuing
            //right now it continues anyway...?
            //tried moving win condition check from here and things got worse ;_;

            if(checkWinCondition())
            {
                winDisplay.gameObject.SetActive(true);
            } else {
                generateSequence();
                StartCoroutine(showSequence());
                letPlayerPlay();
            }
                
            
    }

    void generateSequence()
    {
        var r = new System.Random();
        for(int i = 0; i< arraySize; i++)
        {
            int step = r.Next(buttons.Length-1);
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
        //debug statements for testing
        Debug.Log("sequence length "+sequence.Length);
        Debug.Log("round "+roundNumber );
        for(int i = 0; i< sequence.Length; i++)
        {
            Debug.Log("button "+i);
            yield return new WaitForSeconds(1f);
            //some issue here?
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
    }

    //executes on button press
    public void SetLatestPlayerButton(SimonButton latest)
    {
        lastPlayerInput = latest;
        //check whether to continue to next round
        if(playerInputPosition == arraySize)
        {
            roundNumber++;
            //try moving victory check here?
            //it did not work for sure!
                arraySize= arraySize+2;
                roundDisplay.text = "Round: "+ roundNumber;
                sequence = new SimonButton[arraySize];
                playGame();  
        } else {
            //check if input matches, if not restart round
            if(sequence[playerInputPosition] != lastPlayerInput)
            {
                playerInputPosition = 0;
                StartCoroutine(showSequence());
                letPlayerPlay();
            } else {
                playerInputPosition++;
            }
        }
        
    }

    bool checkWinCondition()
    {
        return roundNumber> victoryNumber;
    }

    public void RestartRoutine()
    //if restart button is clicked
    {
        roundNumber = 1;
        arraySize = roundNumber*2;
        roundDisplay.text = "Round: "+ roundNumber;
        sequence = new SimonButton[arraySize];
        playGame();

    }
}
