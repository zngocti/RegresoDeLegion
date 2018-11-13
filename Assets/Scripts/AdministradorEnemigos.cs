using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorEnemigos : MonoBehaviour {

    static int numeroDeWave = 0;
    static int cantidadDeEnemigos = 0;

    public GameObject jugador;
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public Transform[] spawns;
    public bool[] usarSpawn;

    const int cantidad = 15;

    int pool1 = 5;
    int pool2 = 2;
    int pool3 = 1;

    public GameObject[] poolEnemigos1;
    public GameObject[] poolEnemigos2;
    public GameObject[] poolEnemigos3;

    public AtributosPersonaje[] poolAtributos1;
    public AtributosPersonaje[] poolAtributos2;
    public AtributosPersonaje[] poolAtributos3;

    public ComportamientoEnemigo[] poolComportamiento1;
    public ComportamientoEnemigo[] poolComportamiento2;
    public ComportamientoEnemigo[] poolComportamiento3;

    public AudioSource miAudioSource;

    private GameObject nuevoEnemigo;

    float segundosParacheckear = 10;

    // Use this for initialization
    void Awake () {
        for (int i = 0; i < usarSpawn.Length; i++)
        {
            usarSpawn[i] = true;
        }

        for (int i = 0; i < cantidad; i++)
        {
            poolEnemigos1[i] = Instantiate(enemigo1, new Vector3(130,0,0), Quaternion.identity);
            poolAtributos1[i] = poolEnemigos1[i].GetComponent<AtributosPersonaje>();
            poolAtributos1[i].setObjetivo(jugador);
            poolAtributos1[i].setAudioSource(miAudioSource);
            poolComportamiento1[i] = poolEnemigos1[i].GetComponent<ComportamientoEnemigo>();
            poolComportamiento1[i].setObjetivo(jugador);
            poolComportamiento1[i].transform.SetParent(this.transform);
        }

        for (int i = 0; i < cantidad; i++)
        {
            poolEnemigos2[i] = Instantiate(enemigo2, new Vector3(130, 0, 0), Quaternion.identity);
            poolAtributos2[i] = poolEnemigos2[i].GetComponent<AtributosPersonaje>();
            poolAtributos2[i].setObjetivo(jugador);
            poolAtributos2[i].setAudioSource(miAudioSource);
            poolComportamiento2[i] = poolEnemigos2[i].GetComponent<ComportamientoEnemigo>();
            poolComportamiento2[i].setObjetivo(jugador);
            poolComportamiento2[i].transform.SetParent(this.transform);
        }

        for (int i = 0; i < cantidad; i++)
        {
            poolEnemigos3[i] = Instantiate(enemigo3, new Vector3(130,0,0), Quaternion.identity);
            poolAtributos3[i] = poolEnemigos3[i].GetComponent<AtributosPersonaje>();
            poolAtributos3[i].setObjetivo(jugador);
            poolAtributos3[i].setAudioSource(miAudioSource);
            poolComportamiento3[i] = poolEnemigos3[i].GetComponent<ComportamientoEnemigo>();
            poolComportamiento3[i].setObjetivo(jugador);
            poolComportamiento3[i].transform.SetParent(this.transform);
        }
       StartCoroutine(checkPosicionJugador());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator checkPosicionJugador()
    {
        while (AdministradorDeDatos.getJugando())
        {
            if(cantidadDeEnemigos == 0)
            {
                numeroDeWave++;
                setCantidades();

                if (jugador.transform.position.x < 0 && jugador.transform.position.z > 0)
                {
                    usarSpawn[0] = false;
                    usarSpawn[1] = false;
                    usarSpawn[2] = false;
                    usarSpawn[3] = false;
                }
                else if (jugador.transform.position.x > 0 && jugador.transform.position.z > 0)
                {
                    usarSpawn[4] = false;
                    usarSpawn[5] = false;
                    usarSpawn[6] = false;
                    usarSpawn[7] = false;
                }
                else if (jugador.transform.position.x < 0 && jugador.transform.position.z < 0)
                {
                    usarSpawn[8] = false;
                    usarSpawn[9] = false;
                    usarSpawn[10] = false;
                    usarSpawn[11] = false;
                }
                else
                {
                    usarSpawn[12] = false;
                    usarSpawn[13] = false;
                    usarSpawn[14] = false;
                    usarSpawn[15] = false;
                }

                spawnearEnemigos();

                for (int i = 0; i < usarSpawn.Length; i++)
                {
                    usarSpawn[i] = true;
                }
            }

            yield return new WaitForSeconds(segundosParacheckear);
        }
    }

    void setCantidades()
    {
        if(numeroDeWave == 2)
        {
            pool1--;
            pool2++;
        }
        else if(numeroDeWave == 3)
        {
            pool1--;
            pool3++;
        }
        else if (numeroDeWave == 4)
        {
            pool2++;
        }
        else if (numeroDeWave == 5)
        { 
            pool3++;
        }
        else if (numeroDeWave == 6)
        {
            pool2++;
            pool3++;
        }
        else if (numeroDeWave < 10)
        {
            pool1--;
            pool2++;
        }
        else if (numeroDeWave == 10)
        {
            pool2--;
            pool3++;
        }
        if (numeroDeWave % 3 == 0)
        {
            aumentarVelocidad();
        }
    }

    private void aumentarVelocidad()
    {
        for (int i = 0; i < cantidad; i++)
        {
            poolAtributos1[i].subirVelocidad();
            poolAtributos2[i].subirVelocidad();
            poolAtributos3[i].subirVelocidad();
        }
    }

    private void spawnearEnemigos()
    {
        int i = 0;
        for (int c = 0; c < pool1; c++)
        {
            for (int e = 0; e < usarSpawn.Length; e++)
            {
                if (usarSpawn[e])
                {
                    poolEnemigos1[i].transform.position = spawns[e].position;
                    poolAtributos1[i].activarPersonaje();
                    i++;
                    usarSpawn[e] = false;
                    cantidadDeEnemigos++;
                    e = usarSpawn.Length;
                }
            }
        }

        i = 0;
        for (int c = 0; c < pool2; c++)
        {
            for (int e = i; e < usarSpawn.Length; e++)
            {
                if (usarSpawn[e])
                {
                    poolEnemigos2[i].transform.position = spawns[e].position;
                    poolAtributos2[i].activarPersonaje();
                    i++;
                    usarSpawn[e] = false;
                    cantidadDeEnemigos++;
                    e = usarSpawn.Length;
                }
            }
        }

        i = 0;
        for (int c = 0; c < pool3; c++)
        {
            for (int e = i; e < usarSpawn.Length; e++)
            {
                if (usarSpawn[e])
                {
                    poolEnemigos3[i].transform.position = spawns[e].position;
                    poolAtributos3[i].activarPersonaje();
                    i++;
                    usarSpawn[e] = false;
                    cantidadDeEnemigos++;
                    e = usarSpawn.Length;
                }
            }
        }
    }

    static public int getWave()
    {
        return numeroDeWave;
    }

    static public void restarEnemigo()
    {
        cantidadDeEnemigos--;
    }

    static public void resetEnemigos()
    {
        numeroDeWave = 0;
        cantidadDeEnemigos = 0;
    }
}
