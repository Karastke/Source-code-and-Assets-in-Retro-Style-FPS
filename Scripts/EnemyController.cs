using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D rigid;

    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = 0.5f;

    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //유클리드 거리를 계산하는 정적메서드 Distance, 적(transform.position)과 플레이어(PlayerController.instance.transform.position)간의 거리를 계산함. playerRange값 보다 가까운 경우에만 적이 플레이어를 추적함
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rigid.velocity = playerDirection.normalized * moveSpeed;

            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    AudioController.instance.PlayEnemyShot();
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }

        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            AudioController.instance.PlayEnemyDeath();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
           
        }
    }

}
