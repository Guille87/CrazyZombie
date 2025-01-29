using TMPro;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    const int MAX_HEALTH = 100;
    [SerializeField] TextMeshProUGUI tmpHealth;

    int health = MAX_HEALTH;

    void Start()
    {
        ApplyDamage(0);
    }

    void ApplyDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            tmpHealth.text = health.ToString();
        }
    }
}
