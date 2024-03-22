using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable
{
    public bool isLit;
    public GameObject flames;

    public float maxDistance = 10f; // Max distance at which the audio will be heard at full volume

    private AudioSource audioSource;
    private GameObject player; 

    void Start()
    {
        isLit = false;
        flames.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player GameObject not found.");
            return;
        }

        if (isLit)
        {
            // Get distance between the campfire and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            float volume = 1f - Mathf.Clamp01(distanceToPlayer / maxDistance);
            audioSource.volume = volume;
        }
       
    }

    void LightFire()
    {
        if (isLit) return;

        isLit = true;
        flames.SetActive(true);
        //audioSource.enabled = true;
    }

    public void Interact()
    {
        LightFire();
    }
}
