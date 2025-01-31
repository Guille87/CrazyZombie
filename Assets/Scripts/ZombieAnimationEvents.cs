using UnityEngine;

public class ZombieAnimationEvents : MonoBehaviour
{
    ZombieAnim zombieAnim;

    void Start()
    {
        zombieAnim = GetComponentInParent<ZombieAnim>();
    }

    public void ApplyAttackDamage()
    {
        zombieAnim.ApplyAttackDamage();
    }
}
