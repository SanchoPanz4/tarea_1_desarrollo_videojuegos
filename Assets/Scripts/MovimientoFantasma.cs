using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velFantasma = 5f;
    public float radioDeteccion = 3.0f;
    public LayerMask capaParedes;
    public Vector3 vectorMov = new Vector3(0.0f, 0.0f, 1.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DetectarObjetos();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choco con: " + collision.gameObject.name);
        randomVector();
    }
    void randomVector()
    {
        if(vectorMov.z == 1)
        {
            vectorMov.x = 1;
            vectorMov.z = 0;
        }
        else if(vectorMov.x == 1)
        {
            vectorMov.x = 0;
            vectorMov.z = -1;
        }
        /*
        float x = (float)Random.Range(0,1);
        float y = 0.0f;
        float z = (float)Random.Range(0,1);
        Vector3 vector = new Vector3(x,y,z);
        return vector;
        */
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
        transform.Translate(vectorMov * velFantasma * Time.deltaTime);
    }
}
