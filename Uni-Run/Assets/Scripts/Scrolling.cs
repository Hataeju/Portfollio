using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    // ����ȭ : �ٸ� ������ ����ϱ� �����ϵ��� ������ �ٲ��ִ� ���
    // SerializeField : ����������� ����Ƽ �����Ϳ����� ���� �����ϵ��� �ϴ� ��Ʈ������(�Ӽ�)
    [SerializeField] private float scrollingSpeed = 10f;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // vector3.left = new vector3( -1, 0, 0);
        // transform�� �����̷��� �Ҷ� Time.delateTime�� ������� �Ѵ�
        // � ����  Time.delataime�� ���ϸ� 1�̵ȴ�(�������� ���)
        // �ʴ� �������� -10��ŭ �����̴� �ڵ�
        if (!gameManager.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * scrollingSpeed);
        }
        
        // Time.deltaTime : ���� �����Ӱ� ���� ������ ���� ����

        // 40������
        // 600������
        // 15��

        /*Debug.Log(Time.deltaTime);*/
    }

    /*public void SetSpeed(float speed)
    {
        scrollingSpeed=speed;
        Debug.Log("stop");
    }*/
}
