using UnityEngine;

public class BulletHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
