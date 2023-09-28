using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nauJugador;
    public GameObject textGameOver;
    public GameObject titolJoc;
    public GameObject butoInici;
    public GameObject generadorNumeros;

    public enum EstatsGameManager
    {
        Inici,
        Jugant,
        GameOver
    }

    private EstatsGameManager _estatGameManager;

    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualitzaEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Inici:

                nauJugador.SetActive(false);
                titolJoc.SetActive(true);
                textGameOver.SetActive(false);
                butoInici.SetActive(true);
                //generadorNumeros.GetComponent<GeneradorNumeros>().AturaGeneracioNums();

                break;

            case EstatsGameManager.Jugant:

                nauJugador.SetActive(true);
                titolJoc.SetActive(false);
                textGameOver.SetActive(false);
                butoInici.SetActive(false);
                generadorNumeros.GetComponent<GeneradorNumeros>().IniciaGeneracioNums();

                break;

            case EstatsGameManager.GameOver:

                nauJugador.SetActive(false);
                titolJoc.SetActive(false);
                textGameOver.SetActive(true);
                butoInici.SetActive(false);
                generadorNumeros.GetComponent<GeneradorNumeros>().AturaGeneracioNums();

                break;
        }
    }

    public void SetEstatGameManager(EstatsGameManager estat)
    {
        _estatGameManager = estat;
        ActualitzaEstatGameManager();
    }

    public void PassarAEstatJugant()
    {
        _estatGameManager = EstatsGameManager.Jugant;
        ActualitzaEstatGameManager();
    }
}
