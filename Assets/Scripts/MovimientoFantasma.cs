using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velFantasma = 5f;
    public float radioDeteccion = 3.0f;
    public LayerMask capaParedes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DetectarObjetos();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Paso por: " + gameObject.name);
    }
/*    void DetectarObjetos()
    {   
        Collider[] objetosCercanos = Physics.OverlapSphere(transform.position, radioDeteccion, capaParedes);
        foreach(Collider col in objetosCercanos)
        {
            if(col.gameObject == gameObject) continue;
            Debug.Log("Objeto: "+ col.gameObject.name);
        }
    }
*/
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velFantasma * Time.deltaTime);
    }
}
