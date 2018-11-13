using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour {

    BoxCollider miCollider;
    public GameObject pinches;
    public GameObject jugador;

    AtributosPersonaje atributosJugador;
    bool disponible = true;

    float ataque = 0;
    float ataqueBase = 5;
    float ataquePorWave = 3;

	// Use this for initialization
	void Start () {
        miCollider = GetComponent<BoxCollider>();
        atributosJugador = jugador.GetComponent<AtributosPersonaje>();
        StartCoroutine(funcionPinches());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player") && disponible)
        {
            disponible = false;
            atributosJugador.impacto(ataque);
        }
    }

    IEnumerator funcionPinches()
    {
        while(AdministradorDeDatos.getJugando())
        {
            ataque = ataqueBase + ataquePorWave * AdministradorEnemigos.getWave();
            disponible = true;
            pinches.transform.Translate(Vector3.up * 3);
            miCollider.enabled = true;
            yield return new WaitForSeconds(2);

            disponible = false;
            pinches.transform.Translate(Vector3.down * 3);
            miCollider.enabled = false;
            
            if (AdministradorEnemigos.getWave() < 3)
            {
                yield return new WaitForSeconds(Random.Range(5, 9));
            }
            else if (AdministradorEnemigos.getWave() < 7)
            {
                yield return new WaitForSeconds(Random.Range(4, 7));
            }
            else
            {
                yield return new WaitForSeconds(3);
            }
        }
    }
}
