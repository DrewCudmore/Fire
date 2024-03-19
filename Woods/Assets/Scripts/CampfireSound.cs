using UnityEngine;

public class CampfireSound : MonoBehaviour
{
    public float maxDistance = 10f; // Max distance at which the audio will be heard at full volume

    private AudioSource audioSource;
    private GameObject player; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player GameObject not found.");
            return;
        }

        // Get distance between the campfire and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        float volume = 1f - Mathf.Clamp01(distanceToPlayer / maxDistance);
        audioSource.volume = volume;
    }
}
