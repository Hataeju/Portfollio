using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private int platformCount = 3;

    [SerializeField] float spawnTimeMin = 1.25f;
    [SerializeField] float spawnTimeMax = 2.25f;
    private float spawnTime;
    private float lastSpawnTime;

    [SerializeField] float posYMin = -3.5f;
    [SerializeField] float posYMax = 1.5f;
    private float posX = 20f;

    private GameObject[] platforms;
    private int currentIndex;

    private GameManager gameManager;

    // ������Ʈ Ǯ�� : �����Ҽ� �ִ� ������Ʈ�� �ʿ��� �� �ٽ� �����ϴ� ��� (������ �ı��� ������ �÷��͸� ���߽�Ű�� ����)
    Vector2 poolPosition = new Vector2(0, -25f);



    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[platformCount];

        for(int i = 0; i< platforms.Length; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        spawnTime = 0;
        lastSpawnTime = 0;
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        // ���� ������� �������� �ʵ���
        if (gameManager.isGameOver)
        {
            return;
        }

        // ���� ���� ����
        // Time.time : ���� �����ӿ����� ���� ���ۺ��� ������� �帥 �ð�

        // 1ȸ : 0 >= 0 + 0
        // 2ȸ : 

        if(Time.time >= lastSpawnTime + spawnTime)
        {
            lastSpawnTime = Time.time;

            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

            float posY = Random.Range(posYMin, posYMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(posX, posY);

            /*if(currentIndex < platformCount-1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = ;
            }*/


            // �ε����� 0,1,2 ��ȸ
            currentIndex = ++currentIndex % platforms.Length;
        }
    }
}
