using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //these lists have all the dialogue for each phase of questions
    public List<string> phaseOneDialogue;
    public List<string> phaseTwoDialogue;

    //holds the phase we're currently going through
    List<string> currentDialogue;

    //tracks the current phase and the line we're on in that phase
    int phaseIndex = 0;
    int dialogueIndex = 0;

    //game object for all buttons
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject nextButton;

    //text component that is showing the dialogue
    public TMP_Text dialogueBox;

    //"score" for how much of a clown u r
    int clownyLove = 0;

    // Start is called before the first frame update
    void Start()
    {
        //turn off the choice buttons
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        currentDialogue = phaseOneDialogue;
        SetDialogueText();
    }

    void SetDialogueText() {
        //set the dialogue component to show the line we're on
        dialogueBox.text = currentDialogue[dialogueIndex];
    }

    public void AdvanceDialog()
    {
        //go to the next line
        dialogueIndex++;
        SetDialogueText();
        //if we're on the last line of dialogue
        if (dialogueIndex == currentDialogue.Count - 1)
        {
            //show the choices
            SetupChoices();
        }
    }

    void SetupChoices() {
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
    }

    public void FaceyChoice()
    {
        //if we press "no", just go to the next phase of questions
        GoToNextPhase();
    }

    public void ClownyChoice()
    {
        //if we press "yes", increase clowny's score and then go to the next phase
        clownyLove++;
        GoToNextPhase();
    }

    void GoToNextPhase() {
        //turn on the next button and turn off the choice buttons
        nextButton.SetActive(true);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        //reset the dialogue line counter
        dialogueIndex = 0;
        //depending on the phase
        //run an animation and determine what the next phase is
        switch (phaseIndex)
        {
            case 0:
                currentDialogue = phaseTwoDialogue;
                phaseIndex = 1;
                break;
        }
        SetDialogueText();
    }

}
