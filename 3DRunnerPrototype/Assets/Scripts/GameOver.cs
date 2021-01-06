using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    //private Animator gameOverAnim;

    //private void Awake()
    //{
    //    gameOverAnim = GetComponent<Animator>();
    //}

    void OnEnable()
    {
        PlayerEvents.OnPlayerKilled += StartGameOver;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerKilled -= StartGameOver;
    }

    public void StartGameOver()
    {
        gameOverScreen.SetActive(true);
        //gameOverAnim.SetBool("Activate", true);
    }

    //RETRY BUTTON
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
