using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportamientoEnemigo : MonoBehaviour {

    public Transform jugador;

    NavMeshAgent miNav;
    AtributosPersonaje misAtributos;

    public float segundosCheckJugador = 3;

    // Use this for initialization
    void Start () {
        miNav = GetComponent<NavMeshAgent>();
        misAtributos = GetComponent<AtributosPersonaje>();

        miNav.speed = misAtributos.getVelocidadMovimiento();
        StartCoroutine(checkJugador());
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void setObjetivo(GameObject elJugador)
    {
         jugador = elJugador.transform;
    }

    private IEnumerator checkJugador()
    {
        while (true)
        {
            if (misAtributos.getEstaVivo() && AdministradorDeDatos.getJugando() && misAtributos.getEstaEnUso())
            {
                if(jugador != null)
                {
                    miNav.SetDestination(jugador.position);
                    transform.LookAt(jugador);
                }
            }
            yield return new WaitForSeconds(segundosCheckJugador);
        }
    }

    public void apagarNav()
    {
        miNav.enabled = false;
    }

    public void prenderNav()
    {
        miNav.enabled = true;
    }
}
