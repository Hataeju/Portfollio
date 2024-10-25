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
    // ���� ������Ʈ�� Ȱ��ȭ�ɶ����� ȣ��Ǵ� ����Ƽ �̺�Ʈ�Լ�
    private void OnEnable()
    {
        Debug.Log("Ȱ��ȭ ��.");
        for(int i = 0; i< obstacles.Length; i++)
        {
            // 1/3Ȯ���� ��ֹ��� Ȱ��ȭ�ϴ� �ڵ�
            
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
