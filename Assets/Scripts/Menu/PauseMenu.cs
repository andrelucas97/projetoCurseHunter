using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public Transform pauseMenu;
    [SerializeField] private AudioSource musicaMenuAudioSource;
    [SerializeField] private AudioClip musicaMenuAudioClip;

    private AudioSource[] allAudioSources;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        allAudioSources = FindObjectsOfType<AudioSource>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf){
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

        foreach (AudioSource audioSource in allAudioSources){
            if (audioSource != musicaMenuAudioSource){
                audioSource.Pause();
            }
        }

        musicaMenuAudioSource.PlayOneShot(musicaMenuAudioClip);



    }

    public void ResumeGame(){
        pauseMenu.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;

        foreach (AudioSource audioSource in allAudioSources){
            if (audioSource != musicaMenuAudioSource){
                audioSource.UnPause();
            }
        }
    }
}

