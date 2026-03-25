using UnityEngine;
using UnityEngine.SceneManagement;

public class MudancadeCena : MonoBehaviour
{
    [SerializeField] private string cena;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IAmPlayer player))
        {
            SceneManager.LoadScene(cena);
        }
    }
    public void Cena()
    {
        SceneManager.LoadScene("Game");
    }
}
