using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject _startingScreenTransition;
    [SerializeField] GameObject _endingScreenTransition;

    // Start is called before the first frame update
    void Start()
    {
        _startingScreenTransition.SetActive(true);
        Invoke("DisableStartingScreenTimer", 5f);
    }

    private void DisableStartingScreenTimer()
    {
        _startingScreenTransition.SetActive(false);
    }

    public void GameScene()
    {
        _endingScreenTransition.SetActive(true);
        Invoke("NextLevel", 1.5f);
    }
    private void NextLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameOverScene()
    {
        _endingScreenTransition.SetActive(true);
        Invoke("MainMenu", 1.5f);
    }
    private void MainMenu()
    {
        SceneManager.LoadScene("Introduction");
    }
}
