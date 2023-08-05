using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPorta : MonoBehaviour
{

    private GameObject player;
    private Animator portaAbrir;

    public GameObject mensagemPorta;

    [SerializeField] private AudioSource portaAudioSource;
    [SerializeField] private AudioClip portaAudioClip;  

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        portaAbrir = GetComponentInParent<Animator>();        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.1f){
            mensagemPorta.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)){

                mensagemPorta.SetActive(false);
                portaAbrir.enabled = true;
                portaAudioSource.PlayOneShot(portaAudioClip);


            }
        } else {
            mensagemPorta.SetActive(false);

        }

        if (portaAbrir.enabled == true){
            mensagemPorta.SetActive(false);

        }
        
    }
}
