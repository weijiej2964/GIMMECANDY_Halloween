using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMaster : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneTo(string scene)
    {
        StartCoroutine(_LoadScene(scene));
    }

    IEnumerator _LoadScene(string scene)
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(scene);
    }


}
