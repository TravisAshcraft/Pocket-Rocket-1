using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;
    GameManager gameManager;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
