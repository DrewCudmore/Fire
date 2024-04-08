using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameObject player;
    PlayerMovement playerMovement;
    private Transform lastCheckpoint;

    public float fadeDuration = 1f;
    public Image fadePanel;
    public TextMeshProUGUI deathText;

    private bool waitForInput = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager when reloading
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Transform checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }

    public Transform GetLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void RespawnPlayer()
    {

        if (lastCheckpoint != null)
        {
            if (player != null)
            {
                player.transform.position = lastCheckpoint.position;
                player.transform.rotation = lastCheckpoint.rotation;
            }
            else
            {
                Debug.LogWarning("Player object not found!");
            }
        }
        else
        {
            Debug.LogWarning("No checkpoint set!");
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void KillPlayer(string deathReason)
    {
        //Debug.Log(lantern.myLight.intensity);

        fadePanel.gameObject.SetActive(true);

        if (playerMovement != null)
        {
            playerMovement.disableMovement();
        }

        StartCoroutine(FadeToDeathScreen(deathReason));
    }

    IEnumerator FadeToDeathScreen(string deathReason)
    {
        // Fade out
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadePanel.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadePanel.color = Color.black;

        // Show death text
        deathText.gameObject.SetActive(true);
        deathText.text = "You died!\nCause of death: " + deathReason + "\n\nPress Space to Respawn";
        waitForInput = true;

        // Wait for spacebar input
        while (waitForInput)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                waitForInput = false;
            }
            yield return null;
        }

        // Respawn the player
        RespawnPlayer();

        // Fade in
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadePanel.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadePanel.color = Color.clear;

        // Disable canvas elements after fading back
        fadePanel.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);

        // Renable movement
        if (playerMovement != null)
        {
            playerMovement.enableMovement();
        }
    }
}
