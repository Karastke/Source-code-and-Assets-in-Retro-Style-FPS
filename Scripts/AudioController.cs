using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo, enemyDeath, enemyShot, gunShot, health, playerHurt, backgroundMusic;

    private void Awake() 
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAmmoPickup()
    {
        ammo.Stop();
        ammo.Play();
    }
    
    public void PlayEnemyDeath()
    {
        enemyDeath.Play();
    }

    public void PlayEnemyShot()
    {
        enemyShot.Play();
    }

    public void PlayeGunShot()
    {
        gunShot.Stop();
        gunShot.Play();
    }

    public void PlayHealthPickup()
    {
        health.Stop();
        health.Play();
    }

    public void PlayPlayerHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }
}
