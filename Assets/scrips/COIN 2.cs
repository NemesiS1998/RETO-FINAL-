using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COIN2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Moneda");
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
