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
        // Input Manager에서 Vertical축과 Horizontal축의 입력을 받아옵니다.
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
        // 벡터의 normalized를 하면 벡터의 길이를 1로 만듭니다.
        // 예를 들어, vertical, horizontal 모두 1인 경우, direction의 크기는 1보다 크게 될 수 있는데, 이를 1로 맞춰줍니다.
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

        // rigidbody.velocity는 해당 물체가 1초당 움직이는 거리를 말합니다.
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
            uiText.text = other.gameObject.name + "님과 대화하기 [E]";
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
