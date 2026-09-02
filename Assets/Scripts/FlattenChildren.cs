using UnityEngine;

[ExecuteAlways]
public class FlattenChildren : MonoBehaviour
{
    public float targetY = 0f;
    public float flatHeight = 0.1f;
    public Material overrideMaterial;      // opcional: dejar vacio si no quieres cambiar el material
    public bool forceSolidCollider = false; // marcar SOLO en paredes

    void OnValidate() { Apply(); }
    void Awake() { Apply(); }

    void Apply()
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = child.localPosition;
            pos.y = targetY;
            child.localPosition = pos;

            Vector3 scale = child.localScale;
            scale.y = flatHeight;
            child.localScale = scale;

            if (overrideMaterial != null)
            {
                Renderer rend = child.GetComponent<Renderer>();
                if (rend != null) rend.sharedMaterial = overrideMaterial;
            }

            if (forceSolidCollider)
            {
                Collider col = child.GetComponent<Collider>();
                if (col != null) col.isTrigger = false;
            }
        }
    }
}