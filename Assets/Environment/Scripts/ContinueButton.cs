using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ContinueButton : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Controls control;

    void Awake()
    {
        control = new Controls();

        control.FreeMovement.Continue.performed += Continue_started;
    }
    void Start()
    {
        text = gameObject.Q<TextMeshProUGUI>();

        if(Gamepad.current != null)
        {
            text.text = "Press 'B' to continue";
        }
        else
        {
            text.text = "Press 'Enter' to continue";
        }
    }

    private void Continue_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Dialog.instance.NextSentence();
    }

    void OnEnable()
    {
        control.FreeMovement.Enable();
    }

    void OnDisable()
    {
        control.FreeMovement.Disable();
    }
}
