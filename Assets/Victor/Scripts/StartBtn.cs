using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    [SerializeField]
    public string nomeDaCena;

    public void Sair()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
