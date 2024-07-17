using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D rb;    
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public Camera viewCam;

    public float mouseSensitivity = 1f;

    public GameObject bulletImpact;

    public int currentAmmo;

    public Animator gunAnim;

    public int currentHealth;
    public int maxHealth;

    public GameObject deadScreen;
    private bool hasDied;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져와서 초기화
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(!hasDied)
        {
                    // 이동 입력 처리
        // 'Horizontal'과 'Vertical' 축의 입력을 받아 Vector2로 저장
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // 수평 이동 벡터 계산 (캐릭터의 '위' 방향을 기준으로 입력값의 x축 사용)
        Vector3 moveHorizontal = transform.up * -moveInput.x;

        // 수직 이동 벡터 계산 (캐릭터의 '오른쪽' 방향을 기준으로 입력값의 y축 사용)
        Vector3 moveVertical = transform.right * moveInput.y;

        // 최종 이동 벡터 계산 및 Rigidbody2D의 속도 설정
        rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        // 마우스 입력 처리
        // 'Mouse X'와 'Mouse Y' 축의 입력을 받아 Vector2로 저장하고 감도 조절
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        // 플레이어의 회전 처리
        // 현재 회전 각도를 가져와서 z축을 기준으로 마우스 입력값을 빼서 회전 적용
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

        if(Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("I'm looking at " + hit.transform.name);
                Instantiate(bulletImpact, hit.point, transform.rotation);

                if (hit.transform.tag == "Enemy")
                {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                }
            }
            else
            {
                Debug.Log("I'm looking at nothing");
            }
                        currentAmmo --;
            gunAnim.SetTrigger("Shoot");
            }

        }
        }

        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            hasDied = true;
        }
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
