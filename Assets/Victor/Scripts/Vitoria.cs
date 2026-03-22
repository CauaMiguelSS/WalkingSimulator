using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public Image fadeImage;          // imagem preta (full screen)
    public CanvasGroup winUI;        // painel de vitória
    public AudioSource music;        // música de fundo
    public float fadeTime = 2f;

    bool activated = false;

    void Start()
    {
        // começa invisível
        Color c = fadeImage.color;
        c.a = 0f;
        fadeImage.color = c;

        winUI.alpha = 0f;
        winUI.interactable = false;
        winUI.blocksRaycasts = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        float t = 0f;
        float startVolume = music != null ? music.volume : 0f;
        Color c = fadeImage.color;

        // fade + diminuir música
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float v = t / fadeTime;

            c.a = Mathf.Lerp(0f, 1f, v);
            fadeImage.color = c;

            if (music != null)
                music.volume = Mathf.Lerp(startVolume, 0f, v);

            yield return null;
        }

        // final
        if (music != null) music.Stop();

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        winUI.alpha = 1f;
        winUI.interactable = true;
        winUI.blocksRaycasts = true;
    }
}