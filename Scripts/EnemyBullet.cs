using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;
    public float bulletSpeed = 5f;

    private Rigidbody2D rb;

    private Vector3 direction;

    public float lifeTime;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(damageAmount);

            Destroy(gameObject);
        }

        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
