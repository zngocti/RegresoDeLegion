using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderYunque : MonoBehaviour {

    public GameObject jugador;
    ManejoDelJugador miControl;
    AtributosPersonaje misAtributos;

    public GameObject parte1;
    public GameObject parte2;
    public GameObject parte3;

    public float tiempoMuerto = 120;

    bool activable = true;
    float ataqueBase = 3;
    float ataqueWave = 1;

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

    public void activarYunque()
    {
        if (activable)
        {
            activable = false;
            misAtributos.sumarAtaque(ataqueBase + ataqueWave * AdministradorEnemigos.getWave());
            miAudioSource.PlayOneShot(poder);
            StartCoroutine(recargar());
        }
    }

    IEnumerator recargar()
    {
        parte1.SetActive(false);
        parte2.SetActive(false);
        parte3.SetActive(false);
        yield return new WaitForSeconds(tiempoMuerto);
        activable = true;
        parte1.SetActive(true);
        parte2.SetActive(true);
        parte3.SetActive(true);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.prenderYunque();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.apagarYunque();
        }
    }
}
