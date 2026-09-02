using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform jugador;
    public Transform[] fantasmas; // ahora es una lista

    private Vector3 posInicialJugador;
    private Vector3[] posInicialFantasmas;

    void Start()
    {
        posInicialJugador = jugador.position;

        posInicialFantasmas = new Vector3[fantasmas.Length];
        for(int i = 0; i < fantasmas.Length; i++)
        {
            posInicialFantasmas[i] = fantasmas[i].position;
        }
    }

    public void MatarJugador()
    {
        jugador.position = posInicialJugador;

        for(int i = 0; i < fantasmas.Length; i++)
        {
            fantasmas[i].position = posInicialFantasmas[i];
            fantasmas[i].GetComponent<FantasmaSensores>().ResetearDireccion();
        }
    }
}