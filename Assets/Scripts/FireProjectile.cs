using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float delay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject clone = Instantiate(projectilePrefab, transform.position, transform.rotation);

            Destroy(clone, delay);
        }
    }
}
