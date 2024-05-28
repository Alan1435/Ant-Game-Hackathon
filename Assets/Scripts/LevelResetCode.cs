using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResetCode : MonoBehaviour
{
    [SerializeField] int currentLevelIndex ;

    void Update()
    {
        if (Input.GetButtonDown("Reset"))
        StartCoroutine(LoadNextSceneAsync()) ;
    }

    IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(currentLevelIndex) ;

        while (!asyncload.isDone)
        {
            yield return null ;
        }
    }
}
