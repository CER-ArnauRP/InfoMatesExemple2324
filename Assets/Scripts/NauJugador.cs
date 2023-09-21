using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float _velNau;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();

        DisparaBala();
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        // Quan la nau toqui un objecte, automàticament es cridarà aquest mètode.
        // El valor de objecteTocat, serà l'objecte que hem tocat (per exempel, un número).
        if (objecteTocat.tag == "Numero")
        {
            Destroy(gameObject);
        }
    }

    private void MovimentNau()
    {
        // Trobar límits pantalla.
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = spriteRenderer.bounds.size.x / 2;
        float altura = spriteRenderer.bounds.size.y / 2;

        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        float limitSuperior = Camera.main.orthographicSize - altura;
        float limitInferior = -Camera.main.orthographicSize + altura;

        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");

        // Moure nau.
        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;

        Vector2 novaPos = transform.position; // Ens retorna la posici� actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitInferior, limitSuperior);

        transform.position = novaPos;
    }

    private void DisparaBala()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bala = Instantiate(Resources.Load("Prefabs/bala") as GameObject);
            bala.transform.position = transform.position;
        }
    }

}
