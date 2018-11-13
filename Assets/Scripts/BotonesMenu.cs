using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonesMenu : MonoBehaviour {

    public Button botonIniciar;
    public Button botonInstrucciones;
    public Button botonCreditos;
    public Button botonSalir;

    public Button botonVolverInstrucciones;
    public Button botonVolverCreditos;

    public GameObject menu;
    public GameObject instrucciones;
    public GameObject creditos;

    // Use this for initialization
    void Start () {
        Button btnIni = botonIniciar.GetComponent<Button>();
        btnIni.onClick.AddListener(IniciarPartida);

        Button btnInst = botonInstrucciones.GetComponent<Button>();
        btnInst.onClick.AddListener(Instrucciones);

        Button btnCred = botonCreditos.GetComponent<Button>();
        btnCred.onClick.AddListener(Creditos);

        Button btnSalir = botonSalir.GetComponent<Button>();
        btnSalir.onClick.AddListener(SalirDelJuego);

        Button btnVolverIns = botonVolverInstrucciones.GetComponent<Button>();
        btnVolverIns.onClick.AddListener(VolverDeInstrucciones);

        Button btnVolverCred = botonVolverCreditos.GetComponent<Button>();
        btnVolverCred.onClick.AddListener(VolverDeCreditos);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void IniciarPartida()
    {
        SceneManager.LoadScene("Pantalla Principal");
    }

    void Instrucciones()
    {
        menu.SetActive(false);
        instrucciones.SetActive(true);
    }

    void Creditos()
    {
        menu.SetActive(false);
        creditos.SetActive(true);
    }

    void VolverDeInstrucciones()
    {
        instrucciones.SetActive(false);
        menu.SetActive(true);
    }

    void VolverDeCreditos()
    {
        creditos.SetActive(false);
        menu.SetActive(true);
    }

    void SalirDelJuego()
    {
        Application.Quit();
    }
}
