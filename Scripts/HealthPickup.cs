using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.AddHealth(healthAmount);

            Destroy(gameObject);
        }
    }

}
