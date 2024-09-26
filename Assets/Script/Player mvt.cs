using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermvt : MonoBehaviour

{
    public Rigidbody2D rb;
    public float Vitesse = 5f;
    public float ImmuneBaseTime = 3f;
    private float ImmuneTime;
    public Vector3 movement;

    public bool Immunity;

    // Ajout d'une variable pour la vie du joueur
    public float vie = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Immunity = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * Vitesse;

        if (Immunity == true) {
            ImmuneTime -= Time.deltaTime;
            if (ImmuneTime <= 0) {
                Immunity = false;
            }
        }
    }

    // M�thode pour infliger des d�g�ts
    public void PrendreDegats(float montant)
    {
        if (Immunity == false) {
            vie -= montant;
            Immunity = true;
            ImmuneTime = ImmuneBaseTime;
            if (vie <= 0)
            {
                Mourir();
            }
        }
    }

    // M�thode appel�e lorsque la vie atteint z�ro
    private void Mourir()
    {
        Debug.Log("Le joueur est mort");
        Destroy(gameObject);
    }
}
