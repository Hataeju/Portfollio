using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float width;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        width = box.size.x; // 박스 콜라이더의 폭을 가져온다.
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -width)
        {
            Vector3 moveTo = new Vector3(width, 0, 0);
            transform.position = moveTo;
        }
    }
}
