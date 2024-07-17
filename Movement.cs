using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotateSpeed = 50.0f;


    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
