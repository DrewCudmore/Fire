using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToSwitchTo;
    public bool fadeOut = false;
    public float fadeDuration = 4f;
    public AudioSource audioSource;

    private GameManager gameManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component exists
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found!");
        }

        DontDestroyOnLoad(gameObject);

        gameManager = GameManager.Instance;
    }

    public void SwitchSceneWithFadeOut()
    {
        gameManager.FadeOutScreen(fadeDuration);
        Invoke("SwitchScene", fadeDuration); // Invoke SwitchScene after the fadeDuration
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneToSwitchTo);
    }

    private void OnDestroy()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            PlayAudio();
            if (fadeOut)
            {
                SwitchSceneWithFadeOut();
            }
            else
            {
                SceneManager.LoadScene(sceneToSwitchTo);
            }

        }
    }

    private void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
