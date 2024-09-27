using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float vitesse = 1.0f;
    public float vie = 100f;
    public float degatsAuJoueur = 20f; // D�g�ts inflig�s au joueur
    private Transform joueur; // Le joueur est maintenant priv�

    private Playermvt target;

    // Initialisation
    private void Start()
    {
        joueur = GameObject.FindWithTag("Joueur").GetComponent<Transform>();
        target = GameObject.FindWithTag("Joueur").GetComponent<Playermvt>();
    }

    // Mouvement de base
    private void Update()
    {
        DeplacerVersJoueur();
    }

    // Fonction priv�e pour d�placer l'ennemi vers le joueur
    private void DeplacerVersJoueur()
    {
        transform.position = Vector3.MoveTowards(transform.position, joueur.position, vitesse * Time.deltaTime);
    }

    // D�tection de collision avec un trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si l'objet en collision a le tag "joueur"
        if (collision.CompareTag("Joueur"))
        {
            // R�cup�re le script "NewBehaviourScript" depuis l'objet en collision
            Playermvt joueurScript = collision.gameObject.GetComponent<Playermvt>();

            if (joueurScript != null)
            {
                joueurScript.PrendreDegats(degatsAuJoueur);
            }
        }
    }

    // M�thode pour infliger des d�g�ts � l'ennemi
    public void PrendreDegats(float montant)
    {
        vie -= montant;
        if (vie <= 0)
        {
            Debug.Log("Died");
            if (target != null)
            {
                target.GainExp();
            }
            Detruire();
        }
    }

    // Fonction priv�e pour d�truire l'ennemi
    private void Detruire()
    {
        Destroy(gameObject);
    }
}