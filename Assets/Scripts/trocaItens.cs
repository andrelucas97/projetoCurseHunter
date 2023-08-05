using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trocaItens : MonoBehaviour
{

    public GameObject isqueiro;
    public GameObject lanterna;
    public GameObject luzLanterna;
    public GameObject crucifixo;

    [SerializeField] private AudioSource lanternaAudioSource;
    [SerializeField] private AudioClip lanternaAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        isqueiro.SetActive(true);
        lanterna.SetActive(false);
        crucifixo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            isqueiro.SetActive(true);
            lanterna.SetActive(false);
            luzLanterna.SetActive(false);
            crucifixo.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            isqueiro.SetActive(false);
            lanterna.SetActive(true);
            lanternaAudioSource.PlayOneShot(lanternaAudioClip);
            luzLanterna.SetActive(true);
            crucifixo.SetActive(false);
        }

        if ((PlayerCruc.pegueiCruc) && (Input.GetKeyDown(KeyCode.Alpha3))){
            isqueiro.SetActive(false);
            lanterna.SetActive(false);
            luzLanterna.SetActive(false);
            crucifixo.SetActive(true);
        }
    }
}
