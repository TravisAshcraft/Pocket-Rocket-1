using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }
}
