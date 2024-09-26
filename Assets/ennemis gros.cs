using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemisgros : MonoBehaviour
{
    public float vitesse = 1.0f;
    private Transform joueur;
    
    void Start()
    {
        joueur = GameObject.FindWithTag("joueur").GetComponent<Transform>();


    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, joueur.position, vitesse * Time.deltaTime);
        
    }
}
