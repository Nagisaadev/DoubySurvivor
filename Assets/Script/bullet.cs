using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    [Range(1, 10)]
    [SerializeField] private float speed = 10f ;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 2f ;

    public float damage = 2f;

    private Rigidbody2D rb;
    
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D> ();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate() 
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si l'objet en collision a le tag "joueur"
        if (collision.CompareTag("Enemy"))
        {
            // R�cup�re le script "NewBehaviourScript" depuis l'objet en collision
            Ennemi enemyScript = collision.gameObject.GetComponent<Ennemi>();

            if (enemyScript != null)
            {
                enemyScript.PrendreDegats(damage);
            }
            Destroy(gameObject);
        }
    }

}
