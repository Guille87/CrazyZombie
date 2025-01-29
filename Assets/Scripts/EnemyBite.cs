using UnityEngine;

public class EnemyBite : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("ApplyDamage", 1);
        }
    }
}
