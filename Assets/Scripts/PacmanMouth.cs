using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PacmanMouth : MonoBehaviour
{
    public float radius = 0.5f;
    public float chompsPerSecond = 5f; // sube este numero si quieres que mastique mas rapido
    public float maxMouthAngle = 70f;
    public int segments = 32;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        float t = Time.time * chompsPerSecond * Mathf.PI * 2f;
        float mouthAngle = (Mathf.Sin(t) * 0.5f + 0.5f) * maxMouthAngle;
        BuildMesh(mouthAngle);
    }

    void BuildMesh(float mouthAngleDeg)
    {
        Vector3[] vertices = new Vector3[segments + 2];
        int[] triangles = new int[segments * 3];

        vertices[0] = Vector3.zero;

        float startAngle = mouthAngleDeg / 2f;
        float endAngle = 360f - mouthAngleDeg / 2f;
        float angleStep = (endAngle - startAngle) / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (startAngle + angleStep * i) * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * radius;
            float z = Mathf.Cos(angle) * radius;
            vertices[i + 1] = new Vector3(x, 0f, z);
        }

        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}