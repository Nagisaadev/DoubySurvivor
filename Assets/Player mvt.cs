using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermvt : MonoBehaviour

{
public Rigidbody2D rb;
public float Vitesse = 5f; 
Vector2 mouvement;

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
}
