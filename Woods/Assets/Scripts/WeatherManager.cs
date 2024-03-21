using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager Instance;

    public enum WeatherStatus
    {
        Clear,
        Rain,
        Thunder
    }

    public WeatherStatus currentWeather = WeatherStatus.Clear;

    public AudioClip clearAudio;
    public AudioClip rainAudio;
    public AudioClip thunderAudio;
    private AudioSource audioSource;

    public ParticleSystem rainParticleSystem;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayAudioForWeather();
    }

    void Update()
    {
        // Test with keys, later this can be called by different scripts if the player walks
        // into a new area or accomplishes something that changes the weather

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandleClear();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandleRain();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandleThunder();
        }
    }

    void PlayAudioForWeather()
    {
        audioSource.Stop();

        switch (currentWeather)
        {
            case WeatherStatus.Clear:
                audioSource.clip = clearAudio;
                break;
            case WeatherStatus.Rain:
                audioSource.clip = rainAudio;
                break;
            case WeatherStatus.Thunder:
                audioSource.clip = thunderAudio;
                break;
        }

        audioSource.Play();
    }

    void HandleClear()
    {
        currentWeather = WeatherStatus.Clear;
        StopRain();
        PlayAudioForWeather();
    }

    void HandleRain()
    {
        currentWeather = WeatherStatus.Rain;
        StartRain();
        PlayAudioForWeather();
    }

    // We could make this stop rain as well if we want only thunder
    void HandleThunder()
    {
        currentWeather = WeatherStatus.Thunder;
        PlayAudioForWeather();

        //TODO: Implement thunder audio, thunder particles/prefab
    }

    void StartRain()
    {
        if (rainParticleSystem != null && !rainParticleSystem.isPlaying)
        {
            rainParticleSystem.Play();
        }
    }

    void StopRain()
    {
        if (rainParticleSystem != null && rainParticleSystem.isPlaying)
        {
            rainParticleSystem.Stop();
            rainParticleSystem.Clear();
        }
    }

}
