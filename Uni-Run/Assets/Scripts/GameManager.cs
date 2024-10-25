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
            // ����Ƽ������ ������ �������� �ʽ��ϴ�. ���带 �� ���ø����̼��� ���¿����� ����
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

        highscore.text = "�ְ����� : " + ((int)bestscore).ToString();
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            tmpscore.text = "���� " + score.ToString();
            
        }
    }
}
