using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    // 직렬화 : 다른 곳에서 사용하기 용이하도록 포맷을 바꿔주는 기능
    // SerializeField : 비공개이지만 유니티 에디터에서는 접근 가능하도록 하는 어트리뷰터(속성)
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
        // transform을 움직이려고 할때 Time.delateTime을 곱해줘야 한다
        // 어떤 값에  Time.delataime을 곱하면 1이된다(프레임이 어떻드)
        // 초당 왼쪽으로 -10만큼 움직이는 코드
        if (!gameManager.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * scrollingSpeed);
        }
        
        // Time.deltaTime : 이전 프레임과 현재 프레임 간의 간격

        // 40프레임
        // 600프레임
        // 15배

        /*Debug.Log(Time.deltaTime);*/
    }

    /*public void SetSpeed(float speed)
    {
        scrollingSpeed=speed;
        Debug.Log("stop");
    }*/
}
