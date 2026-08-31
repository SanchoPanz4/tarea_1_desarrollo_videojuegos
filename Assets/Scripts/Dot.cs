using UnityEngine;

public class Dot : MonoBehaviour
{
    public int points = 10;

    void Start()
    {
        Debug.Log(gameObject.name + " esta ACTIVO y listo");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " - toque: " + other.name + " (tag: " + other.tag + ")");

        if (other.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(points);

            Destroy(gameObject);
        }
    }
}