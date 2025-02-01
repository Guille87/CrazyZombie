using UnityEngine;
using System.Collections;
using TMPro;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab; // Prefab de la bala
    [SerializeField] Transform firePoint; // Punto de disparo
    [SerializeField] float fireRate = 0.2f; // Velocidad de disparo
    [SerializeField] int magazineSize = 7; // Balas en el cargador
    [SerializeField] float reloadTime = 2f; // Tiempo de recarga

    [SerializeField] TextMeshProUGUI ammoText; // Texto UI para las balas
    [SerializeField] TextMeshProUGUI reloadText; // Texto UI para la recarga

    private int currentAmmo; // Balas actuales en el cargador
    private bool isReloading = false;
    private float nextFireTime = 0f;

    void Start()
    {
        currentAmmo = magazineSize;
        UpdateAmmoUI();
    }

    void Update()
    {
        if (isReloading) return; // No se puede disparar si está recargando

        // Disparar con el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        // Recargar con el botón izquierdo del ratón si no hay balas
        else if (Input.GetMouseButtonDown(0) && currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }

        // Recargar con la tecla R si no está recargando y no está lleno el cargador
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < magazineSize)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        // Lanza un rayo desde el centro de la cámara
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        
        // Si el rayo golpea algo, la bala irá hacia allí, si no, irá hacia adelante
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100); // Un punto lejano en la dirección de la cámara
        }

        // Calcula la dirección de disparo
        Vector3 shootDirection = (targetPoint - firePoint.position).normalized;

        // Instancia la bala y ajusta su rotación
        Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
        
        currentAmmo--;
        UpdateAmmoUI();
    }

    IEnumerator Reload()
    {
        if (currentAmmo < magazineSize)
        {
            isReloading = true;
            float elapsedTime = 0f;

            reloadText.text = "Recargando...";

            while (elapsedTime < reloadTime)
            {
                elapsedTime += Time.deltaTime;
                reloadText.text = "Recargando... " + Mathf.Ceil(reloadTime - elapsedTime) + "s";
                yield return null;
            }

            currentAmmo = magazineSize;
            isReloading = false;

            UpdateAmmoUI();

            reloadText.text = "";
        }
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = $"{currentAmmo} / ∞";
        }
    }
}
