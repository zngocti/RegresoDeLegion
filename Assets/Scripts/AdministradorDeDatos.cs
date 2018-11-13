using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdministradorDeDatos : MonoBehaviour {

    static float puntos = 0;
    static bool jugando = true;

    public GameObject jugador;

    public Text misPuntos;
    public Text wave;
    public Text vida;
    public Text ataque;

    AtributosPersonaje atributosJugador;

    public GameObject miCanvas;
    public Text puntajeFinal;
    public Text waveFinal;

    // Use this for initialization
    void Start()
    {
        atributosJugador = jugador.GetComponent<AtributosPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        misPuntos.text = "Puntos: " + puntos;
        wave.text = "Wave: " + AdministradorEnemigos.getWave();
        vida.text = "Vida: " + atributosJugador.getVida() + " / " + atributosJugador.getVidaMax();
        ataque.text = "Ataque: " + atributosJugador.getAtaque();

        if(!jugando)
        {
            miCanvas.SetActive(true);
            puntajeFinal.text = "Tu Puntaje: " + puntos;
            waveFinal.text = "Wave Alcanzada: " + AdministradorEnemigos.getWave();
        }
    }

    public static void resetDatos()
    {
        jugando = true;
        puntos = 0;
    }

    public static float getPuntos()
    {
        return puntos;
    }

    public static void sumarPuntos(float num)
    {
        puntos = puntos + num;
    }

    public static bool getJugando()
    {
        return jugando;
    }

    public static void finJuego()
    {
        jugando = false;
    }
}
