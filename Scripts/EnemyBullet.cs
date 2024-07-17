using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;
    public float bulletSpeed = 5f;

    private Rigidbody2D rb;

    private Vector3 direction;

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
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}
