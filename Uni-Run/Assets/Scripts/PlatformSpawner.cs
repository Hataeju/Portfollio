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

    // 오브젝트 풀링 : 재사용할수 있는 오브젝트를 필요할 때 다시 재사용하는 기법 (생성과 파괴는 가비지 컬렉터를 유발시키기 때문)
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
        // 게임 오버라면 생성하지 않도록
        if (gameManager.isGameOver)
        {
            return;
        }

        // 발판 생성 로직
        // Time.time : 현재 프레임에서의 게임 시작부터 현재까지 흐른 시간

        // 1회 : 0 >= 0 + 0
        // 2회 : 

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


            // 인덱스가 0,1,2 순회
            currentIndex = ++currentIndex % platforms.Length;
        }
    }
}
