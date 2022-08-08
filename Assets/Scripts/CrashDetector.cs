using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float RelaodDelayInSeconds = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashAudio;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke(nameof(ReloadScene), RelaodDelayInSeconds);
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashAudio);
        }   
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    } 
}
