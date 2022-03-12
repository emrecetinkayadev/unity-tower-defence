using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentScene;
    int waitingTime = 2;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
        {
            StartCoroutine(WaitAndLoadScene());
        }

    }

    void LoadStartScreen(){
        SceneManager.LoadScene("Start Screen");
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(waitingTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void CheckLivesforNextScene(int lives){
        if(lives <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Play Game");
    }

    public void QuitApp(){
        Application.Quit();
    }
}
