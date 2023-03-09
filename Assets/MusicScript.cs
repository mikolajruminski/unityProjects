using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource music;
    public Slider slider;
    float volume = 1;

    public static MusicScript Instance = null;

    private void Awake() {

        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
       slider.value = PlayerPrefs.GetFloat("MusicVolume");
        
    }

    // Update is called once per frame
    void Update()
    {
    
       music.volume = slider.value;
       
    }
    
    public void SavePrefs() {
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
        PlayerPrefs.Save();
    }
}
