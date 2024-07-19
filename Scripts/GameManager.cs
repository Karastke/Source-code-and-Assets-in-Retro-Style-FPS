using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public GameObject gameOverImage, healthUI, ammoUI;

    void Awake()
    {
        GameManager.instance = this;
    }

    void Start()
    {
        LockCursor();
        gameOverImage.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if (PlayerController.instance.hasDied == true)
        {
            UnlockCursor();
            healthUI.SetActive(false);
            ammoUI.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            LockCursor();
            Time.timeScale = 1;
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
