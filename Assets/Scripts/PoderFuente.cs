using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderFuente : MonoBehaviour {

    public GameObject jugador;

    public GameObject agua;
    public GameObject luz;

    public float tiempoMuerto = 120;

    ManejoDelJugador miControl;
    AtributosPersonaje misAtributos;

    bool activable = true;
    float curacionBase = 5;
    float curacionWave = 3;

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

    public void activarFuente()
    {
        if (activable)
        {
            activable = false;
            misAtributos.curarVida(curacionBase + curacionWave * AdministradorEnemigos.getWave());
            miAudioSource.PlayOneShot(poder);
            StartCoroutine(recargar());
        }
    }

    IEnumerator recargar()
    {
        agua.SetActive(false);
        luz.SetActive(false);
        yield return new WaitForSeconds(tiempoMuerto);
        activable = true;
        agua.SetActive(true);
        luz.SetActive(true);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.prenderFuente();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            miControl.apagarFuente();
        }
    }
}
