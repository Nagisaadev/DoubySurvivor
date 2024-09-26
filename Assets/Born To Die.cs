using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornToDie : MonoBehaviour
{
    public void TimeToDie()
    {
        Debug.Log($"{gameObject.name} has been killed!");
        Destroy(gameObject);
    }
}
