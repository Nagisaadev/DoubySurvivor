using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    // variables gun
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    //[range (0.1f, 1f)]
    //[SerializeField] private float fireRate = 0.5f;

    private Rigidbody2D rb;
    private float mx;
    private float my; 

    Vector2 MousePos;
    
        // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
        StartCoroutine(ShootEverySecond());
    }

    IEnumerator ShootEverySecond()
    {
        while (true) // Boucle infinie
        {
            Shoot(); // Appel de la fonction shoot
            yield return new WaitForSeconds(1f); // Attente de 1 seconde
        }
    }

    
    

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(MousePos.y - transform.position.y, MousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f ;

        transform.localRotation = Quaternion.Euler(0, 0, angle);


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}

