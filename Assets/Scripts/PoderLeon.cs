using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderLeon : MonoBehaviour
{
    public GameObject jugador;
    ManejoDelJugador miControl;

    public GameObject estrellas;

    bool activable = true;
    float puntosBase = 20;
    float puntosWave = 5;
    public float tiempoMuerto = 120;

    public AudioClip poder;
    public AudioSource miAudioSource;

    // Use this for initialization
    void Start()
    {
        miControl = jugador.GetComponent<ManejoDelJugador>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activarLeon()
    {
        if(activable)
        {
            activable = false;
            AdministradorDeDatos.sumarPuntos(puntosBase + puntosWave * AdministradorEnemigos.getWave());
            miAudioSource.PlayOneShot(poder);
            StartCoroutine(recargar());
        }
    }

    IEnumerator recargar()
    {
        estrellas.SetActive(false);
        yield return new WaitForSeconds(tiempoMuerto);
        activable = true;
        estrellas.SetActive(true);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.prenderLeon();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.apagarLeon();
        }
    }
}
