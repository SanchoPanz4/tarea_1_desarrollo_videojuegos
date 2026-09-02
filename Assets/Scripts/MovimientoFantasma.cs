using UnityEngine;

public class FantasmaSensores : MonoBehaviour
{
    public Transform jugador;
    public float velFantasma = 3f;

    public SensorDireccion sensorEste;
    public SensorDireccion sensorOeste;
    public SensorDireccion sensorNorte;
    public SensorDireccion sensorSur;

    private Vector3 direccionActual = Vector3.right;

    void Update()
    {
        ElegirCamino();
        transform.position += direccionActual * velFantasma * Time.deltaTime;
    }

    void ElegirCamino()
    {
        // para que no tiemble entre 2 direcciones
        if (!EstaBloqueada(direccionActual) && Random.value > 0.3f) return;

        Vector3 mejorDir = direccionActual;
        float distMin = Mathf.Infinity;

        // Revisamos las 4 direcciones
        if (!sensorEste.bloqueado)
        {
            float d = Vector3.Distance(transform.position + Vector3.right, jugador.position);
            if (d < distMin) { distMin = d; mejorDir = Vector3.right; }
        }
        if (!sensorOeste.bloqueado)
        {
            float d = Vector3.Distance(transform.position + Vector3.left, jugador.position);
            if (d < distMin) { distMin = d; mejorDir = Vector3.left; }
        }
        if (!sensorNorte.bloqueado)
        {
            float d = Vector3.Distance(transform.position + Vector3.forward, jugador.position);
            if (d < distMin) { distMin = d; mejorDir = Vector3.forward; }
        }
        if (!sensorSur.bloqueado)
        {
            float d = Vector3.Distance(transform.position + Vector3.back, jugador.position);
            if (d < distMin) { distMin = d; mejorDir = Vector3.back; }
        }

        direccionActual = mejorDir;
    }

    bool EstaBloqueada(Vector3 dir)
    {
        if (dir == Vector3.right)   return sensorEste.bloqueado;
        if (dir == Vector3.left)    return sensorOeste.bloqueado;
        if (dir == Vector3.forward) return sensorNorte.bloqueado;
        if (dir == Vector3.back)    return sensorSur.bloqueado;
        return false;
    }
}