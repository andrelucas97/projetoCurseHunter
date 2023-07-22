using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimGame : MonoBehaviour
{

    private GameObject player;

    public GameObject mensagemFimGame;
    public GameObject mensagemGG;
    public GameObject mensagemPortaFechada;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f){
            if (Gaveta.pegueiPorta == true){
                mensagemFimGame.SetActive(true);
                if (Input.GetKey(KeyCode.E)){
                    mensagemFimGame.SetActive(false);
                    mensagemGG.SetActive(true);

                }
                
            } else {
                mensagemPortaFechada.SetActive(true);
            }
        } else {
                mensagemPortaFechada.SetActive(false);
                mensagemFimGame.SetActive(false);
        }
    }
}
