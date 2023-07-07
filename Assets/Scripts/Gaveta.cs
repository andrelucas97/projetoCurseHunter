using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaveta : MonoBehaviour
{

    private GameObject player;
    private Animator gavetaAbrir;


    public GameObject mensagemGaveta; // abrir cadeado
    public GameObject mensagemGavetaTrancada; // gaveta trancada
    public GameObject cadeadoObjeto; // objeto cadeado
    public GameObject mensagemAbrirGaveta; // abrir gaveta
    


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gavetaAbrir = GetComponentInParent<Animator>();

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f){
            if (PlayerChave.peguei == true){
                mensagemGaveta.SetActive(true);
                if (Input.GetKey(KeyCode.E)){
                    Destroy(cadeadoObjeto);
                    mensagemGaveta.SetActive(false);
                    gavetaAbrir.enabled = true;



                }
            }

            else {
                mensagemGavetaTrancada.SetActive(true);
            }
        }

        else {
            mensagemGaveta.SetActive(false);
            mensagemGavetaTrancada.SetActive(false);
        }
    }
}
