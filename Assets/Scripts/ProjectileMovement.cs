using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    const float SPEED = 50.0f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * SPEED * Time.deltaTime);
    }
}
