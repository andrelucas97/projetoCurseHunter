using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilhas3 : MonoBehaviour
{
    private GameObject player;

    public GameObject mensagemItemPilha;



    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {

            mensagemItemPilha.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)){
                PlayerPilhas.bateriaAtual += 40f;

                if (PlayerPilhas.bateriaAtual > PlayerPilhas.bateriaMaximo){
                    PlayerPilhas.bateriaAtual = PlayerPilhas.bateriaMaximo;
                }
                
                mensagemItemPilha.SetActive(false);


                Destroy(gameObject);
                    
            }
        } else {
            mensagemItemPilha.SetActive(false);

        }
    }
}
