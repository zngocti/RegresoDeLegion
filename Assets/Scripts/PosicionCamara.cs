using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionCamara : MonoBehaviour {

    public GameObject jugador;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate ()
    {
        transform.position = jugador.transform.position + new Vector3(-10, 8, -10);
    }
}
