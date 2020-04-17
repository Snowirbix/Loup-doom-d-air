using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    //IEnumerator LoadSceneAsync ()
    //{
    //    fade.gameObject.SetActive(true);
    //    while (fade.color.a < 1f)
    //    {
    //        fade.color = new Color(fade.color.r, fade.color.g , fade.color.b , fade.color.a + 0.05f);
    //        yield return null;
    //    }

    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("City_Main");

    //    // Wait until the asynchronous scene fully loads
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }
    //    PlayerController.instance.transform.SetPositionAndRotation(initialPosition, Quaternion.identity);
    //    while (fade.color.a > 0f)
    //    {
    //        fade.color = new Color(fade.color.r, fade.color.g , fade.color.b , fade.color.a - 0.02f);
    //        yield return null;
    //    }
    //    yield return new WaitForSeconds(1f);
    //    fade.gameObject.SetActive(false);
    //    transition.StartTransformation();
        
    //}

    //protected IEnumerator FadeOut ()
    //{
    //    while (fade.color.a > 0f)
    //    {
    //        fade.color = new Color(fade.color.r, fade.color.g , fade.color.b , fade.color.a - Time.deltaTime);
    //        yield return null;
    //    }
    //    fade.gameObject.SetActive(false);
    //}

    //protected IEnumerator FadeIn ()
    //{
    //    fade.gameObject.SetActive(true);
    //    while (fade.color.a < 1f)
    //    {
    //        fade.color = new Color(fade.color.r, fade.color.g , fade.color.b , fade.color.a + Time.deltaTime);
    //        yield return null;
    //    }
    //}
}
