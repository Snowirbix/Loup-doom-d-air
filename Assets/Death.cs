using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject Spirit;
    private Animator animatorSpirit;
    private Animator animator;

    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.Q<Animator>();
        animatorSpirit = Spirit.Q<Animator>();
    }

    public void death()
    {
        if(!once)
        {
            animatorSpirit.SetTrigger("death");
            animator.SetTrigger("death");
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            animatorSpirit.updateMode = AnimatorUpdateMode.UnscaledTime;
            Time.timeScale = 0;
        }

        once = true;

    }

    public void AnimationDeathHasFinished()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
