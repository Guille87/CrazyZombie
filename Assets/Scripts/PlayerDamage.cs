using TMPro;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    const int MAX_HEALTH = 200;
    const int INITIAL_HEALTH = 100;
    [SerializeField] TextMeshProUGUI tmpHealth;

    int health;

    void Start()
    {
        health = INITIAL_HEALTH;
        UpdateHealthUI();
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, MAX_HEALTH);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (tmpHealth != null) {
            tmpHealth.text = health.ToString();

            if (health <= 29)
            {
                tmpHealth.color = Color.red;
            }
            else if (health >= 30 && health <= 69)
            {
                tmpHealth.color = Color.yellow;
            }
            else
            {
                tmpHealth.color = Color.green;
            }
        }
    }
}
