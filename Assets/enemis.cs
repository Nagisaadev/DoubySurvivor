    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemis : MonoBehaviour
{
    public float rapidité;
    private Transform joueur;
    public float arreter;
   
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Joueur").GetComponent<Transform>();
    }

   
    void Update()
    {
        
            transform.position = Vector2.MoveTowards(transform.position, joueur.position, rapidité * Time.deltaTime);  
     
    }
}
