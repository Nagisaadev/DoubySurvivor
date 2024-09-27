using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermvt : MonoBehaviour

{
    public Rigidbody2D rb;
    public float Vitesse = 5f;
    public float ImmuneBaseTime = 0.25f;
    private float ImmuneTime;
    public Vector3 movement;

    public bool Immunity;
    private Animator Animator; 

    // Ajout d'une variable pour la vie du joueur
    public float vie = 100f;
    public float maxHealth = 100f;

    public float exp = 0f;

    public float nextLvl = 10f;

    public HealthBar hp;
    
    public HealthBar xp;

    // Start is called before the first frame update
    void Start()
    {
        Immunity = false;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * Vitesse;

        if (Immunity == true)
        {
            ImmuneTime -= Time.deltaTime;
            if (ImmuneTime <= 0)
            {
                Immunity = false;
            }
        }
        //rb.MovePosition(rb.position + mouvement * Vitesse * Time.deltaTime);

        if (Input.GetAxis("Vertical") == 1)
        {
            Animator.SetBool("IsBackward", true);
        }
        else 
        {
            Animator.SetBool("IsBackward", false);
        }

        if (movement.magnitude>0)
        {
            Animator.SetBool("IsRunning", true);
        }
        else 
        {
            Animator.SetBool("IsRunning", false);
        }
        if (movement.x < 0)
        {
            // Inverser l'échelle sur l'axe X pour faire face à gauche
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            // Remettre l'échelle normale pour faire face à droite
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // M�thode pour infliger des d�g�ts
    public void PrendreDegats(float montant)
    {
        if (Immunity == false)
        {
            vie -= montant;
            hp.SetHealth(vie, maxHealth);
            Immunity = true;
            ImmuneTime = ImmuneBaseTime;
            if (vie <= 0)
            {

                Mourir();
            }
        }
    }

    // M�thode appel�e lorsque la vie atteint z�ro
    void Mourir()
    {
        Debug.Log("Le joueur est mort");
        Destroy(gameObject);
        ResetScene();
    }

    void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name); 
    }


    void Heal(float amount)
    {
        vie += amount;
        if (vie > maxHealth)
            vie = maxHealth;
        hp.SetHealth(vie, maxHealth);
    }

    void TempShield()
    {
        Immunity = true;
        ImmuneTime = 4.2f;
    }

    public void GainExp()
    {
        exp += 1;
        if (exp >= nextLvl)
        {
            exp = 0f;
            LvUp();
        }
        xp.SetHealth(exp, nextLvl);
    }

    void LvUp () {
        Heal(20);
        nextLvl *= 1.1f;
    }
}

