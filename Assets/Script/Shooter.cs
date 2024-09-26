using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform firingPoint;

    [SerializeField] private GameObject MainBody;

    Vector2 MousePos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootEverySecond());
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = MainBody.transform.position;

        float angle = Mathf.Atan2(MousePos.y - transform.position.y, MousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator ShootEverySecond()
    {
        while (true) // Boucle infinie
        {
            Shoot(); // Appel de la fonction shoot
            yield return new WaitForSeconds(1f); // Attente de 1 seconde
        }
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
