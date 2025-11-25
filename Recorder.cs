using UnityEngine;
using UnityEngine.Animations;

public class Recorder : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip recordedClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //get the audio from the microphone
        recordedClip = Microphone.Start(null, true, 10, 44100);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Microphone.End(null);
            audioSource.clip = recordedClip;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            recordedClip = Microphone.Start(null, true, 10, 44100);
        }
        
    }
}
