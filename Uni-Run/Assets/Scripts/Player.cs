using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class Player : MonoBehaviour
{
    public AudioClip dieClip;
    public float jumpForce = 700f;

    private int jumpCount;
    private bool isGround;
    private bool isDie;
    private bool toSlide;

    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private AudioSource audioSource;
    private CircleCollider2D circleCollider;

    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie) return;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount<2)
        {
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.AddForce(new Vector2 (0, jumpForce));
            audioSource.Play();
            jumpCount++;
        }
        // ������ ������ �߰�
        // �����̽��� �� ��,  ������ٵ��� �ӷ��� 0�̻��϶�
        // ��� ���϶�
        else if (Input.GetKeyUp(KeyCode.Space) && playerRigidBody.velocity.y >0)
        {
            playerRigidBody.velocity *= 0.5f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            circleCollider.offset = new Vector2(0,-0.57f);
            circleCollider.radius = 0.2f;
            toSlide = true;
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            circleCollider.offset = new Vector2(0, -0.04382628f);
            circleCollider.radius = 0.7061737f;
            toSlide = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidBody.AddForce(new Vector2(jumpForce, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidBody.AddForce(new Vector2(-jumpForce, 0));
        }

        animator.SetBool("isGround", isGround);
        animator.SetBool("toSlide", toSlide);
    }

    // ���� �浹�� ���۵ɶ� �ѹ� ȣ��Ǵ� ����Ƽ �̺�Ʈ �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹 �������� ������ ���� �迭�� �ְ�, �� �� 0��° �ε����� ��, �������ڸ��ڸ� �ǹ��Ѵ�.
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
            jumpCount = 0;
        }
        
    }

    // ���� �浹�� ���� �� �ѹ� ȣ��Ǵ� ����Ƽ �̺�Ʈ �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }

    // Ʈ���� �浹�� ���۵� �� �ѹ� ȣ��Ǵ� ����Ƽ �̺�Ʈ �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dead"))
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("toDie");
        audioSource.clip = dieClip;
        audioSource.Play();

        isDie = true;
        
        gameManager.GameOver();

    }
}
