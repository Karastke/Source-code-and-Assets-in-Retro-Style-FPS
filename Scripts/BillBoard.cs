 
 using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    void Update()
    {
        transform.LookAt(PlayerController.instance.transform.position, Vector3.back);
    }
}
