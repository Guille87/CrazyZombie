using UnityEngine;

public class PowerUpApply : MonoBehaviour
{
    const int POWER = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("ApplyDamage", -POWER);
        }

        Destroy(gameObject);
    }
}
