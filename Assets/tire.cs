using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tire : MonoBehaviour
{
    private float mx;
    private float my; 

    private Vector2 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transformPos.x) * Mathf Ra2dDeg - 90f;

        transform.localPosition = Quaternion.Euler(0, 0, angle);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx,my).normalised * speed;
    }
}
