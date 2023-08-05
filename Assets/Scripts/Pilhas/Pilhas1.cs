using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilhas1 : MonoBehaviour
{
    private GameObject player1;

    public GameObject mensagemItemPilha;



    void Start()
    {
        player1 = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player1.transform.position) < 1.5f)
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
