using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public TextMeshProUGUI tmpscore;
    public TextMeshProUGUI highscore;
    public GameObject gameOverUI;

    private int score = 0;

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
   /* [SerializeField] Scrolling scrolling1;
    [SerializeField] Scrolling scrolling2;*/

    private void Update()
    {
        if(Input.GetKeyDown(jumpKey)&& isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // 유니티에디터 에서는 동작하지 않습니다. 빌드를 한 어플리케이션의 상태에서만 동작
            Application.Quit();
        }
    }
    
    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(isGameOver);
        /* Debug.Log("stop1");
         *//*
         Debug.Log("stop2");
         scrolling1.SetSpeed(0);
         Debug.Log("stop3");
         scrolling2.SetSpeed(0);*/
        float bestscore = PlayerPrefs.GetFloat("BestScore");

        if (bestscore < score)
        {
            bestscore = score;

            PlayerPrefs.SetFloat("BestScore", bestscore);
        }

        highscore.text = "최고점수 : " + ((int)bestscore).ToString();
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            tmpscore.text = "점수 " + score.ToString();
            
        }
    }
}
