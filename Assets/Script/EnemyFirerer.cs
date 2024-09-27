using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirerer : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;

    public float FireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootEveryRate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootEveryRate()
    {
        while (true) // Boucle infinie
        {
            Shoot(); // Appel de la fonction shoot
            yield return new WaitForSeconds(FireRate); // Attente de 1 seconde
        }
    }

    private void Shoot()
    {
        Instantiate(Projectile, transform.position, transform.rotation);
    }
}
