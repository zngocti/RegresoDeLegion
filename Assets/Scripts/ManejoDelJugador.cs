using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoDelJugador : MonoBehaviour {

    float velocidad = 20;

    AtributosPersonaje misAtributos;

    float horizontal = 0;
    float vertical = 0;

    bool ataqueDisponible = true;

    public Animator miAnimator;
    CharacterController miCharacterController;

    public GameObject unAtaque;
    public GameObject[] poolAtaques;
    public AtaqueJugador[] poolAtaqueStat;
    const int cantidadDeAtaques = 10;

    public Transform ataques;
    public Transform salida;

    bool conLeon = false;
    bool conAngel = false;
    bool conYunque = false;
    bool conFuente = false;

    public GameObject leon;
    public GameObject angel;
    public GameObject yunque;
    public GameObject fuente;

    PoderLeon pLeon;
    PoderAngel pAngel;
    PoderYunque pYunque;
    PoderFuente pFuente;

    // Use this for initialization
    void Start () {
        misAtributos = GetComponent<AtributosPersonaje>();

        pLeon = leon.GetComponent<PoderLeon>();
        pAngel = angel.GetComponent<PoderAngel>();
        pYunque = yunque.GetComponent<PoderYunque>();
        pFuente = fuente.GetComponent<PoderFuente>();

        velocidad = misAtributos.getVelocidadMovimiento();

        miCharacterController = GetComponent<CharacterController>();

        for (int i = 0; i < cantidadDeAtaques; i++)
        {
            poolAtaques[i] = Instantiate(unAtaque, new Vector3(150, 0, 0), Quaternion.identity);
            poolAtaqueStat[i] = poolAtaques[i].GetComponent<AtaqueJugador>();
            poolAtaques[i].transform.SetParent(ataques);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(AdministradorDeDatos.getJugando())
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            miCharacterController.SimpleMove(Vector3.right * horizontal * velocidad + Vector3.back * horizontal * velocidad + Vector3.forward * vertical * velocidad + Vector3.right * vertical * velocidad);

            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 225, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 315, 0);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }



            if (horizontal != 0 || vertical != 0)
            {
                miAnimator.SetBool("Caminar", true);
            }
            else
            {
                miAnimator.SetBool("Caminar", false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && ataqueDisponible)
            {
                StartCoroutine(Ataque());
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (conLeon)
                {
                    pLeon.activarLeon();
                }
                else if (conAngel)
                {
                    pAngel.activarAngel();
                }
                else if (conYunque)
                {
                    pYunque.activarYunque();
                }
                else if (conFuente)
                {
                    pFuente.activarFuente();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                BotonGameOver.resetStats();
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private IEnumerator Ataque()
    {
        StartCoroutine(misAtributos.Atacar());
        ataqueDisponible = false;
        miAnimator.SetTrigger("Atacar");
        for (int i = 0; i < cantidadDeAtaques; i++)
        {
            if(poolAtaqueStat[i].getUso() == false)
            {
                poolAtaqueStat[i].setAtaque(misAtributos.getAtaque());
                StartCoroutine(poolAtaqueStat[i].activarAtaque(salida.position, transform));
                i = cantidadDeAtaques;
            }
        }
        yield return null;
        miAnimator.ResetTrigger("Atacar");
        yield return new WaitForSeconds(misAtributos.getCDAtaque());
        ataqueDisponible = true;
    }

    public void setAnimator(Animator unAnimator)
    {
        miAnimator = unAnimator;
    }

    public void prenderLeon()
    {
        conLeon = true;
    }

    public void apagarLeon()
    {
        conLeon = false;
    }

    public void prenderAngel()
    {
        conAngel = true;
    }

    public void apagarAngel()
    {
        conAngel = false;
    }

    public void prenderYunque()
    {
        conYunque = true;
    }

    public void apagarYunque()
    {
        conYunque = false;
    }

    public void prenderFuente()
    {
        conFuente = true;
    }

    public void apagarFuente()
    {
        conFuente = false;
    }
}
