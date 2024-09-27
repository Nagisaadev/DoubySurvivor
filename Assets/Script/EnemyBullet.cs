using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 3f;

    public float damage = 2f;

    private Transform joueur;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Joueur").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }
}
