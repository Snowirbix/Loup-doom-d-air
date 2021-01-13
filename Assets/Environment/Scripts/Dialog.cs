using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public List<string> listSentences;
    private int index = 0;
    public float typeSpeed = 0.2f;
    public GameObject continueButton;
    public GameObject canvas;
    private IEnumerator coroutine;

    public static Dialog instance;
    void Awake()
    {
        instance = this;
    }

    public IEnumerator Type()
    {
        foreach(char letter in listSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);           
        }
    }

    public void NextSentence()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        
        continueButton.SetActive(false);
        if (index <= listSentences.Count - 1)
        {           
            textDisplay.text = "";
            coroutine = Type();
            StartCoroutine(coroutine);
            index++;
        }
        else
        {
            textDisplay.text = "";
        }
    }
    void Update()
    {
        if(listSentences.Count > 0)
        {
            continueButton.SetActive(true);
        }

        if(textDisplay.text == "")
        {
            if(canvas.activeSelf)
            {
                canvas.SetActive(false);
            }
        }
        else
        {
            canvas.SetActive(true);
        }

    }

}
