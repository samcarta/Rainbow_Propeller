using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioMixer mixer;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject title;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMusicVolumeChange(float value)
    {
        mixer.SetFloat("Music Volume", value);
    }

    public void OnSFXVolumeChange(float value)
    {
        mixer.SetFloat("Sound Effects Volume", value);
    }

    public void OptionsClose()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
        title.SetActive(true);
    }
}
