using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    GameManager gameManager;
    bool issteped;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }
    // 게임 오브젝트과 활성화될때마다 호출되는 유니티 이벤트함수
    private void OnEnable()
    {
        Debug.Log("활성화 됨.");
        for(int i = 0; i< obstacles.Length; i++)
        {
            // 1/3확률로 장애물을 활성화하는 코드
            
            if(Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
        issteped = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < -0.7 && !issteped )
        {
            gameManager.AddScore(10);
            issteped = true;
        }
    }
}
