using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPuzzle : MonoBehaviour
{
    private bool ready=true;
  
    public enum Type
    {
        reset,
        backOneMove,

    }
    [SerializeField] private Type type;
    [SerializeField] private PuzzleController puzzleController;
    private MessageController messageController;
    private void Start()
    {
        messageController = GameObject.FindGameObjectWithTag("Message").GetComponent<MessageController>();
    }
    private void OnMouseEnter()
    {
        if (type == Type.reset)
        {
            messageController.ShowButtonMessage("Reset", true);
        }
        else if (type == Type.backOneMove)
        {
            messageController.ShowButtonMessage("Back", true);
        }
    }
    private void OnMouseExit()
    {
        messageController.ShowButtonMessage("", false);
    }
    private void OnMouseOver()
    {
        if (ready)
        {
         

            if (Input.GetMouseButtonDown(0))
            {
                ready = false;
                if (type == Type.reset)
                {

                    SoundController.playSound(SoundController.blipSound);
                    puzzleController.ResetGame();
                    StartCoroutine(waiter());
                }
                else if (type == Type.backOneMove)
                {

                    SoundController.playSound(SoundController.blipSound);
                    puzzleController.BackOneMove();
                    StartCoroutine(waiter());
                }
              
               
            }
        }
    }
    IEnumerator waiter()
    {
       
        yield return new WaitForSeconds(0.3f);
        ready = true;
    }
}

    
