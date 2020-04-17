using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public IEnumerator LoadSceneAsync (string sceneName, Vector2 startPos, Quaternion startRot)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator FadeIn(Image veil)
    {
        veil.gameObject.SetActive(true);

        while (veil.color.a < 1f)
        {
            veil.color = new Color(veil.color.r, veil.color.g, veil.color.b, veil.color.a + Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator FadeOut(Image veil)
    {
        while (veil.color.a > 0f)
        {
            veil.color = new Color(veil.color.r, veil.color.g, veil.color.b, veil.color.a - Time.deltaTime);
            yield return null;
        }

        veil.gameObject.SetActive(false);
    }

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

}
