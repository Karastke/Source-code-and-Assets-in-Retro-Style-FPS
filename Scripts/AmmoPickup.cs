using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 25;


private void OnTriggerEnter2D(Collider2D other) 
{
    if (other.tag == "Player")
    {
            AudioController.instance.PlayAmmoPickup();
            PlayerController.instance.currentAmmo += ammoAmount;
            PlayerController.instance.UpdateAmmoUI();
            Destroy(gameObject);
    }
    

}
}
