using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private int i = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
        }
        if (i > 0)
        {
            i++;
        }
        if (i == 15)
        {
            Debug.Break();
        }
    }
}
