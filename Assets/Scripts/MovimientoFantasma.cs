using UnityEngine;

public class FantasmaSensores : MonoBehaviour
{
    public Transform jugador;
    public SensorDireccion sensorEste;
    public SensorDireccion sensorOeste;
    public SensorDireccion sensorNorte;
    public SensorDireccion sensorSur;
    public float velFantasma = 4.5f;
    private Vector3 direccionActual = Vector3.right;

    void Update()
    {
        if (jugador == null) return;
        
        ElegirCamino();
        transform.position += direccionActual * velFantasma * Time.deltaTime;
    }

    void ElegirCamino()
    {
        if (EstaBloqueada(direccionActual))
        {
            direccionActual = BuscarMejorDireccion(true);
            return;
        }
        if (Random.value > 0.1f) return; 

        Vector3 nueva = BuscarMejorDireccion(false);
        if (nueva != Vector3.zero) direccionActual = nueva;
    }

    Vector3 BuscarMejorDireccion(bool permitirVolverse)
    {
        Vector3 opuesta = -direccionActual;
        Vector3 mejorDir = Vector3.zero;
        float distMin = Mathf.Infinity;

        var dirs = new (Vector3 dir, SensorDireccion sensor)[]
        {
            (Vector3.right, sensorEste),
            (Vector3.left, sensorOeste),
            (Vector3.forward, sensorNorte),
            (Vector3.back, sensorSur)
        };

        foreach (var d in dirs)
        {
            if (d.sensor.bloqueado) continue;
            if (!permitirVolverse && d.dir == opuesta) continue;

            float dist = Vector3.Distance(transform.position + d.dir, jugador.position);
            if (dist < distMin)
            {
                distMin = dist;
                mejorDir = d.dir;
            }
        }

        if (mejorDir == Vector3.zero)
        {
            foreach (var d in dirs)
            {
                if (d.sensor.bloqueado) continue;
                float dist = Vector3.Distance(transform.position + d.dir, jugador.position);
                if (dist < distMin)
                {
                    distMin = dist;
                    mejorDir = d.dir;
                }
            }
        }

        return mejorDir == Vector3.zero ? direccionActual : mejorDir;
    }

    bool EstaBloqueada(Vector3 dir)
    {
        if (dir == Vector3.right)   return sensorEste.bloqueado;
        if (dir == Vector3.left)    return sensorOeste.bloqueado;
        if (dir == Vector3.forward) return sensorNorte.bloqueado;
        if (dir == Vector3.back)    return sensorSur.bloqueado;
        return false;
    }
    
    public void ResetearDireccion()
    {
        direccionActual = Vector3.right;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().MatarJugador();
        }
    }

}