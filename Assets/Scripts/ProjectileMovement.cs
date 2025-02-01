using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    const float SPEED = 50.0f;
    const float LIFETIME = 5f;

    void Start()
    {
        Destroy(gameObject, LIFETIME);
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * SPEED * Time.deltaTime);
    }
}
