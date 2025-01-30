using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }
}
