using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocity = 5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y += velocity * Time.deltaTime;
        transform.position = novaPos;

        float limitSuperior = Camera.main.orthographicSize;

        if (transform.position.y >= limitSuperior) {
            Destroy(gameObject);
        }
    }
}
