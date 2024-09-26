using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermvt : MonoBehaviour

{
    public Rigidbody2D rb;
    public float Vitesse = 85f;
    public Vector2 mouvement;
    private Animator Animator; 

    // Ajout d'une variable pour la vie du joueur
    public float vie = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + mouvement * Vitesse * Time.deltaTime);

        if (mouvement.y == 1)
        {

            Animator.SetBool("IsBackward", true);

        }
        else 
        {
            Animator.SetBool("IsBackward", false);
        }

        if (mouvement.magnitude>0)
        {
            Animator.SetBool("IsRunning", true);
        }
        else 
        {
            Animator.SetBool("IsRunning", false);
        }
        if (mouvement.x < 0)
        {
            // Inverser l'échelle sur l'axe X pour faire face à gauche
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (mouvement.x > 0)
        {
            // Remettre l'échelle normale pour faire face à droite
            transform.localScale = new Vector3(1, 1, 1);
        }
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
