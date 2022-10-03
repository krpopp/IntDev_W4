using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //these lists have all the dialogue for each phase of questions
    public List<string> phaseOneDialogue;

    //tracks the line we're on in that phase
    int dialogueIndex = 0;

    //game object for all buttons
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject nextButton;

    //text component that is showing the dialogue
    public TMP_Text dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        //turn off the choice buttons
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        SetDialogueText();
    }

    void SetDialogueText() {
        //set the dialogue component to show the line we're on
        dialogueBox.text = phaseOneDialogue[dialogueIndex];
    }

    public void AdvanceDialog()
    {
        dialogueIndex++;
        SetDialogueText();
    }

    void SetupChoices() {
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
    }

}
