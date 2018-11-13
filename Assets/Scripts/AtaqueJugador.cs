using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour {

    float puntosDeAtaque = 1;
    bool enUso = false;
    Rigidbody miRigidbody;
    public float fuerza = 5;

    public float duracion = 3;

    // Use this for initialization
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAtaque(float num)
    {
        puntosDeAtaque = num;
    }

    public float getAtaque()
    {
        return puntosDeAtaque;
    }

    public bool getUso()
    {
        return enUso;
    }

    public IEnumerator activarAtaque(Vector3 salida, Transform mirada)
    {
        transform.position = salida;
        enUso = true;
        transform.rotation = mirada.rotation;
        miRigidbody.AddForce(transform.forward * fuerza);
        yield return new WaitForSeconds(duracion);
        if(enUso)
        {
            desactivar();
            enUso = false;
        }
    }

    public void desactivar()
    {
        miRigidbody.velocity = Vector3.zero;
        transform.position = new Vector3(150, 0, 0);
    }
}
