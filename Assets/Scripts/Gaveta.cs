using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaveta : MonoBehaviour
{
    public static bool pegueiPorta = false;

    private GameObject player;
    private Animator gavetaAbrir;

    public GameObject chavePorta;

    public GameObject mensagemTeste;


    public GameObject mensagemChave;
    public GameObject mensagemGaveta; // abrir cadeado
    public GameObject mensagemGavetaTrancada; // gaveta trancada
    public GameObject cadeadoObjeto; // objeto cadeado
    public GameObject mensagemAbrirGaveta; // abrir gaveta
    public GameObject mensagemChaveAdicionadoPorta;

    public bool gavetaAberta = false;
    public bool chavePeguei = false;
    public bool pegarChave = false;

    [SerializeField] private AudioSource cadeadoAudioSource;
    [SerializeField] private AudioClip cadeadoAudioClip;

    [SerializeField] private AudioSource cadeadoAbrindoAudioSource;
    [SerializeField] private AudioClip cadeadoAbrindoAudioClip;

    [SerializeField] private AudioSource chavePortaAudioSource;
    [SerializeField] private AudioClip chavePortaAudioClip;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gavetaAbrir = GetComponentInParent<Animator>();

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            if (PlayerChave.peguei == true)
            {
                if (cadeadoObjeto == true){
                    mensagemGaveta.SetActive(true);
                    }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!gavetaAberta)
                    {
                        cadeadoAbrindoAudioSource.PlayOneShot(cadeadoAbrindoAudioClip);

                        Destroy(cadeadoObjeto);
                        mensagemGaveta.SetActive(false);
                        gavetaAbrir.enabled = true;
                        gavetaAberta = true;
                        StartCoroutine(tempoPegarChave(0.5f));

                    }


                }

                if (gavetaAberta && (chavePeguei == false) && pegarChave)
                    {
                        if (Vector3.Distance(transform.position, chavePorta.transform.position) < 1.5f)
                        {
                            mensagemChave.SetActive(true);

                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                pegueiPorta = true;
                                chavePeguei = true;
                                chavePortaAudioSource.PlayOneShot(chavePortaAudioClip);
                                Destroy(chavePorta);
                                mensagemChave.SetActive(false);
                                StartCoroutine(ShowAndHideMessage(2.0f));
                            }
                        }
                        else
                        {
                            mensagemChave.SetActive(false);
                        }
                    }
            }
            else
            {
                mensagemGavetaTrancada.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)){
                    cadeadoAudioSource.PlayOneShot(cadeadoAudioClip);
                }

            }
        }
        else
        {
            mensagemGaveta.SetActive(false);
            mensagemGavetaTrancada.SetActive(false);
            //mensagemChave.SetActive(false);

        }
    }

    IEnumerator ShowAndHideMessage(float duration)
    {
        mensagemChaveAdicionadoPorta.SetActive(true);
        yield return new WaitForSeconds(duration);
        mensagemChaveAdicionadoPorta.SetActive(false);
    }

    IEnumerator tempoPegarChave(float duration)
    {
        yield return new WaitForSeconds(duration);
        pegarChave = true;
    }
}
