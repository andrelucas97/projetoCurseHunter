using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armarioCozinha : MonoBehaviour
{

    private GameObject player;
    private Animator armarioAbrir;

    public GameObject mensagemAbrirArmario;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        armarioAbrir = GetComponentInParent<Animator>();       
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 0.9f){
            mensagemAbrirArmario.SetActive(true);

            if (Input.GetKey(KeyCode.E)){
                
                mensagemAbrirArmario.SetActive(false);
                armarioAbrir.enabled = true;
            }
        } else {
            mensagemAbrirArmario.SetActive(false);

        }

        if (armarioAbrir.enabled == true){
            mensagemAbrirArmario.SetActive(false);
        }


    }
}
