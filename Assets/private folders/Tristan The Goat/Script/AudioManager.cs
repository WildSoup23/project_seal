using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Refrences
    [Header("Refrences")]
    [Tooltip("An audio mixer that has multiple channels")]
    [SerializeField] private AudioMixer mixer;
    [Tooltip("An public static instance of an AudioManager that can be used by anyone, is made sure of that there is only one.")]
    public static AudioManager instance;

    [Space(10)]

    // Keys for diffrent values
    [Header("Keys needed for the diffrent sliders and channels")]
    public const string MASTER_KEY = "masterVolume";
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    // Checks if there is an instance of audiomanger if not sets instances to this. Then sets to dontdestroyonload and if multiple destroy multiple instance.
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume() // Volume saved in volume settiings.cs
    {
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        mixer.SetFloat(VolumeSettingsScript.MIXER_MASTER, Mathf.Log10(masterVolume)* 20);
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        mixer.SetFloat(VolumeSettingsScript.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        mixer.SetFloat(VolumeSettingsScript.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}
