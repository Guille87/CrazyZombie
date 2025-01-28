using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    const float SPEED = 10.0f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * SPEED * Time.deltaTime);
    }
}
