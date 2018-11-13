using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderAngel : MonoBehaviour {

    public GameObject jugador;

    public GameObject parte1;
    public GameObject parte2;
    public GameObject parte3;
    public GameObject parte4;

    public float tiempoMuerto = 120;

    ManejoDelJugador miControl;
    AtributosPersonaje misAtributos;

    bool activable = true;
    float vidaExtraBase = 3;
    float vidaExtraWave = 2;

    public AudioClip poder;
    public AudioSource miAudioSource;

    // Use this for initialization
    void Start()
    {
        miControl = jugador.GetComponent<ManejoDelJugador>();
        misAtributos = jugador.GetComponent<AtributosPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activarAngel()
    {
        if (activable)
        {
            activable = false;
            misAtributos.aumentarVidaMax(vidaExtraBase + vidaExtraWave * AdministradorEnemigos.getWave());
            miAudioSource.PlayOneShot(poder);
            StartCoroutine(recargar());
        }
    }

    IEnumerator recargar()
    {
        parte1.SetActive(false);
        parte2.SetActive(false);
        parte3.SetActive(false);
        parte4.SetActive(false);
        yield return new WaitForSeconds(tiempoMuerto);
        activable = true;
        parte1.SetActive(true);
        parte2.SetActive(true);
        parte3.SetActive(true);
        parte4.SetActive(true);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.prenderAngel();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.apagarAngel();
        }
    }
}
