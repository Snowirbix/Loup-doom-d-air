using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public List<string> listSentences;
    private bool triggerOnce = false;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!triggerOnce && collider.gameObject.tag == "Player")
        {
            Dialog.instance.listSentences.AddRange(listSentences);
            Dialog.instance.NextSentence();
            triggerOnce = true;
        }

    }
}
