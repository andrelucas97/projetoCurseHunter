using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChave : MonoBehaviour
{
    public static bool peguei = false;


    public GameObject chaveObjeto;
    public GameObject chavePorta;


    public GameObject mensagemItem;
    public GameObject mensagemChaveAdicionado;

    [SerializeField] private AudioSource chaveAudioSource;
    [SerializeField] private AudioClip chaveAudioClip;

    void Update()
    {
        if (Vector3.Distance(transform.position, chaveObjeto.transform.position) < 1.5f){
            
            mensagemItem.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)){
                peguei = true;
                chaveAudioSource.PlayOneShot(chaveAudioClip);
                Destroy(chaveObjeto);
                mensagemItem.SetActive(false);           
                StartCoroutine(ShowAndHideMessage(2.0f));
            }
        } else {            
            mensagemItem.SetActive(false);
        }       
    }

    IEnumerator ShowAndHideMessage(float duration){
        mensagemChaveAdicionado.SetActive(true);
        yield return new WaitForSeconds(duration);
        mensagemChaveAdicionado.SetActive(false);
    }

   
}
