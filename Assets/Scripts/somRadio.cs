using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somRadio : MonoBehaviour
{

    private GameObject player;

    public GameObject mensagemRadio;


    [SerializeField] private AudioSource radioAudioSource;
    [SerializeField] private AudioClip radioAudioClip;

    bool isSoundOn = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f){
            
            if (isSoundOn){
            mensagemRadio.SetActive(false);

            } else {
            mensagemRadio.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E) && !isSoundOn){

                mensagemRadio.SetActive(false);
                radioAudioSource.PlayOneShot(radioAudioClip);
                StartCoroutine(tempoDesligarSom(0.5f)); 
                
            }
        } else {
            mensagemRadio.SetActive(false);

        }

        
    }

    IEnumerator tempoDesligarSom(float duration)
    {
        yield return new WaitForSeconds(duration);

        isSoundOn = true;
    }
}
