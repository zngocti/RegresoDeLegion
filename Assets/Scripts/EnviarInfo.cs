using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviarInfo : MonoBehaviour {

    AtributosPersonaje misAtributos;

    Animator miAnimator;

	// Use this for initialization
	void Start () {

	}

    void Awake()
    {
        misAtributos = GetComponentInParent<AtributosPersonaje>();
        miAnimator = GetComponent<Animator>();

        misAtributos.setAnimator(miAnimator);
        ManejoDelJugador miManejo = GetComponentInParent<ManejoDelJugador>();
        miManejo.setAnimator(miAnimator);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
