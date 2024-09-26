using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermvt : MonoBehaviour

{
    public Rigidbody2D rb;
    public float Vitesse = 85f;
    public Vector2 mouvement;

    // Ajout d'une variable pour la vie du joueur
    public float vie = 100f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + mouvement * Vitesse * Time.deltaTime);
    }

    // M�thode pour infliger des d�g�ts
    public void PrendreDegats(float montant)
    {
        vie -= montant;
        if (vie <= 0)
        {
            Mourir();
        }
    }

    // M�thode appel�e lorsque la vie atteint z�ro
    private void Mourir()
    {
        Debug.Log("Le joueur est mort");
        Destroy(gameObject);
    }
}
