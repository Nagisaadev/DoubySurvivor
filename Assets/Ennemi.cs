using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float vitesse = 1.0f;
    public float vie = 100f;
    public float degatsAuJoueur = 20f; // Dégâts infligés au joueur
    private Transform joueur; // Le joueur est maintenant privé

    // Initialisation
    private void Start()
    {
        joueur = GameObject.FindWithTag("joueur").GetComponent<Transform>();
    }

    // Mouvement de base
    private void Update()
    {
        DeplacerVersJoueur();
    }

    // Fonction privée pour déplacer l'ennemi vers le joueur
    private void DeplacerVersJoueur()
    {
        transform.position = Vector2.MoveTowards(transform.position, joueur.position, vitesse * Time.deltaTime);
    }

    // Détection de collision avec un trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet en collision a le tag "joueur"
        if (collision.CompareTag("joueur"))
        {
            // Récupère le script "NewBehaviourScript" depuis l'objet en collision
            NewBehaviourScript joueurScript = collision.gameObject.GetComponent<NewBehaviourScript>();

            if (joueurScript != null)
            {
                // Inflige des dégâts au joueur
                //joueurScript.PrendreDegats(degatsAuJoueur);
            }
           
        }
    }

    // Méthode pour infliger des dégâts à l'ennemi
    public void PrendreDegats(float montant)
    {
        vie -= montant;
        if (vie <= 0)
        {
            Detruire();
        }
    }

    // Fonction privée pour détruire l'ennemi
    private void Detruire()
    {
        Destroy(gameObject);
    }
}