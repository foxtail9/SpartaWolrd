using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] private float speed = 1000.0f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D childCollider;
    public Text uiText;
    public GameObject Talkui;
    public Text NpcName;
    public GameObject NpcTalkUI;

    void Start()
    {
        childCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input Manager���� Vertical��� Horizontal���� �Է��� �޾ƿɴϴ�.
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        if (mousePosition.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        // ������ normalized�� �ϸ� ������ ���̸� 1�� ����ϴ�.
        // ���� ���, vertical, horizontal ��� 1�� ���, direction�� ũ��� 1���� ũ�� �� �� �ִµ�, �̸� 1�� �����ݴϴ�.
        Vector2 direction = new Vector2(horizontal, vertical);
        direction = direction.normalized;

        if (horizontal != 0 || vertical != 0) 
        {
            animator.SetInteger("AnimState", 2);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        // rigidbody.velocity�� �ش� ��ü�� 1�ʴ� �����̴� �Ÿ��� ���մϴ�.
        rigidbody.velocity = direction * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Talkui.activeSelf)
            {
                StartConversation();
            }
        }
    }
    private void StartConversation()
    {
        NpcTalkUI.SetActive(true);
        Talkui.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Talkui.SetActive(true);
            NpcName.text = other.gameObject.name;
            uiText.text = other.gameObject.name + "�԰� ��ȭ�ϱ� [E]";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NpcTalkUI.SetActive(false);
            Talkui.SetActive(false); 
            uiText.text = ""; 
        }
    }
}
