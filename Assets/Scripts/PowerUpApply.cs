using UnityEngine;

public class PowerUpApply : MonoBehaviour
{
    [SerializeField] AudioClip powerUpSound;
    const int POWER = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("ApplyDamage", -POWER);
            
            AudioSource.PlayClipAtPoint(powerUpSound, transform.position, 0.25f);

            Destroy(gameObject);
        }

    }
}
