using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public Slider slider;

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
        
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
