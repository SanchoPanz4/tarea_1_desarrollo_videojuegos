using UnityEngine;

public class SensorDireccion : MonoBehaviour
{
    public bool bloqueado = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            bloqueado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            bloqueado = false;
        }
    }
}