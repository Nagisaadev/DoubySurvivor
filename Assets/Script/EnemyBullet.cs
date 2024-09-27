using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float TimeLeft = 3f;
    public float speed = 3f;

    public float damage = 2f;

    private Transform joueur;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Joueur").GetComponent<Transform>();
        Vector3 Look = transform.InverseTransformPoint(joueur.position);
        float Angle = MathF.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, Angle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si l'objet en collision a le tag "joueur"
        if (collision.CompareTag("Joueur"))
        {
            // R�cup�re le script "NewBehaviourScript" depuis l'objet en collision
            Playermvt joueurScript = collision.gameObject.GetComponent<Playermvt>();

            if (joueurScript != null)
            {
                joueurScript.PrendreDegats(damage);
                Destroy(gameObject);
            }
        }
    }
}
