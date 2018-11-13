using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonGameOver : MonoBehaviour {

    public Button botonJugar;
    public Button botonMenu;

    // Use this for initialization
    void Start () {
        Button btnJugar = botonJugar.GetComponent<Button>();
        btnJugar.onClick.AddListener(NuevaPartida);

        Button btnMenu = botonMenu.GetComponent<Button>();
        btnMenu.onClick.AddListener(VolverAlMenu);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void NuevaPartida()
    {
        resetStats();
        SceneManager.LoadScene("Pantalla Principal");
    }

    void VolverAlMenu()
    {
        resetStats();
        SceneManager.LoadScene("Menu");
    }

    static public void resetStats()
    {
        AdministradorEnemigos.resetEnemigos();
        AdministradorDeDatos.resetDatos();
    }
}
