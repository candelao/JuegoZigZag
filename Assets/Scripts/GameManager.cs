using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int TotalEstrellas = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el objeto no se destruya al cargar una nueva escena
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Asegura que solo haya una instancia de este objeto
        }
    }

    public void AñadirEstrella()
    {
        TotalEstrellas++;
        // Aquí puedes actualizar el UI o realizar cualquier otra acción necesaria
    }

    public void ReiniciarContador()
    {
        TotalEstrellas = 6;
        // Reiniciar o actualizar el UI según sea necesario
    }
}

