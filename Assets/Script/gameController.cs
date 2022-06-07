using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    int gamePoint = 0;
    public Text txtGamePoint;
    public GameObject touchToStart;
    public GameObject touchToRestart;
    public GameObject gameOver;
    public static bool isGameOver;
    bool replayScene;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Touch screen to start");
        touchToStart.SetActive(true);
        touchToRestart.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 0;
        isGameOver = false;
        replayScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && !replayScene)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
                replayScene = true;
                bgMovement.speed = -3;
            }
        }
        else if (!isGameOver && replayScene)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                touchToStart.SetActive(false);
            }
        }
    }

    public void GetPoint()
    {
        gamePoint++;
        txtGamePoint.text = gamePoint.ToString();
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        touchToRestart.SetActive(true);
        gameOver.SetActive(true);
        //isGameOver = true;
        replayScene = false;
    }
}
