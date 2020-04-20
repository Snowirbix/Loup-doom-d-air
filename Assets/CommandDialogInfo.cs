using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CommandDialogInfo : MonoBehaviour
{
    DialogTrigger dialog;
    public string sentenceKeyboard;
    public string sentenceGamepad;
    
    void Awake()
    {
        dialog = gameObject.Q<DialogTrigger>();

        if(Gamepad.current != null)
        {
            dialog.listSentences.Add(sentenceGamepad);
        }
        else
        {
            dialog.listSentences.Add(sentenceKeyboard);
        }

    }

}
