using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueNormal : MonoBehaviour {

    AtributosPersonaje misAtributos;
    bool disponible = true;
    public GameObject jugador;
    AtributosPersonaje atributosJugador;

    // Use this for initialization
    void Start () {
        misAtributos = GetComponentInParent<AtributosPersonaje>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player") && disponible)
        {
            atributosJugador.impacto(misAtributos.getAtaque());
            StartCoroutine(misAtributos.muerte());
        }
        if (col.gameObject.tag.Equals("AtaquePlayer"))
        {
            AtaqueJugador ataque = col.GetComponent<AtaqueJugador>();
            misAtributos.impacto(ataque.getAtaque());
            ataque.desactivar();
        }
    }

    public void setObjetivo(GameObject elJugador)
    {
        jugador = elJugador;
        atributosJugador = jugador.GetComponent<AtributosPersonaje>();
    }
}
