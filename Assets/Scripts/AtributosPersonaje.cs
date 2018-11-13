using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtributosPersonaje : MonoBehaviour {

    public float velocidadMovimiento = 20;
    public float ataque = 2;
    public float ataqueBase = 2;
    public float ataquePorWave = 1;
    public float vida = 100;
    public float vidaMax = 100;
    public float vidaBase = 100;
    public float vidaPorWave = 20;

    public float valor = 10;
    public float valorBase = 10;
    public float valorPorWave = 5;

    bool estaVivo = true;
    bool estaEnUso = false;

    public float cdAtaque = 3;
    
    public GameObject areaAtaque;
    SphereCollider miAtaque;
    AtaqueNormal miAtaqueN;

    public Animator miAnimator;
    NavMeshAgent miNav;

    public AudioClip golpe;
    public AudioClip finJuego;
    public AudioSource miAudioSource;

    // Use this for initialization
    void Awake () {
        if (tag.Equals("Enemigo"))
        {
            miAtaque = areaAtaque.GetComponent<SphereCollider>();
            miNav = GetComponent<NavMeshAgent>();
            miAtaqueN = areaAtaque.GetComponent<AtaqueNormal>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getCDAtaque()
    {
        return cdAtaque;
    }

    public IEnumerator Atacar()
    {
        if (tag.Equals("Enemigo"))
        {
            miAtaque.enabled = true;
            yield return null;
            miAtaque.enabled = false;
        }
    }

    public float getVelocidadMovimiento()
    {
        return velocidadMovimiento;
    }

    public float getAtaque()
    {
        return ataque;
    }

    public void sumarAtaque(float num)
    {
        ataque = ataque + num;
    }

    public bool getEstaVivo()
    {
        return estaVivo;
    }

    public void aumentarVidaMax(float num)
    {
        vidaMax = vidaMax + num;
        vida = vida + num;
    }

    public void curarVida(float num)
    {
        if (vida + num > vidaMax)
        {
            vida = vidaMax;
        }
        else
        {
            vida = vida + num;
        }
    }

    public void impacto(float ataqueEnemigo)
    {
        if(tag.Equals("Player"))
        {
            miAnimator.SetTrigger("Impacto");
            miAudioSource.PlayOneShot(golpe);
        }
        if(vida - ataqueEnemigo <= 0)
        {
            vida = 0;
            estaVivo = false;
            if(tag.Equals("Enemigo"))
            {
                AdministradorDeDatos.sumarPuntos(valor);
            }
            StartCoroutine(muerte());
        }
        else
        {
            vida = vida - ataqueEnemigo;
        }
    }

    public IEnumerator muerte()
    {
        if(transform.tag.Equals("Enemigo"))
        {
            estaVivo = false;
            estaEnUso = false;
            miNav.enabled = false;
            transform.position = new Vector3(130, 0, 0);
            AdministradorEnemigos.restarEnemigo();
            miAudioSource.PlayOneShot(golpe);
        }
        else
        {
            miAnimator.SetTrigger("Morir");
            miAudioSource.Stop();
            miAudioSource.PlayOneShot(finJuego);
            AdministradorDeDatos.finJuego();
            yield return new WaitForSeconds(2);
            miAnimator.ResetTrigger("Impacto");
            miAnimator.ResetTrigger("Morir");
            miAudioSource.Stop();
            miAudioSource.PlayOneShot(finJuego);
            AdministradorDeDatos.finJuego();
        }

    }

    public void activarPersonaje()
    {
        miNav.enabled = true;
        estaVivo = true;
        estaEnUso = true;
        vida = vidaBase + vidaPorWave * AdministradorEnemigos.getWave();
        vidaMax = vida;
        ataque = ataqueBase + ataquePorWave * AdministradorEnemigos.getWave();
        valor = valorBase + valorPorWave;
    }

    public bool getEstaEnUso()
    {
        return estaEnUso;
    }

    public void setObjetivo(GameObject elJugador)
    {
        miAtaqueN.setObjetivo(elJugador);
    }

    public void setAnimator(Animator unAnimator)
    {
        miAnimator = unAnimator;
    }

    public float getVida()
    {
        return vida;
    }

    public float getVidaMax()
    {
        return vidaMax;
    }

    public void setAudioSource(AudioSource unAudioSource)
    {
        miAudioSource = unAudioSource;
    }

    public void subirVelocidad()
    {
        velocidadMovimiento++;
    }
}
