using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToSwitchTo;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component exists
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found!");
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SwitchScene()
    {
        PlayAudio();
        SceneManager.LoadScene(sceneToSwitchTo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            SwitchScene();
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
