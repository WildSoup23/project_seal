using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Refrences
    [SerializeField] private AudioMixer mixer;
    public static AudioManager instance;

    // Keys for diffrent values
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
