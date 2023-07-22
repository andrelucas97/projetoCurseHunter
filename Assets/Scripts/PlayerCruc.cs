using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCruc : MonoBehaviour
{
    public static bool pegueiCruc = false;

    public GameObject crucifixo;
    public GameObject mensagemItemC;
    public GameObject mensagemCrucAdicionado;


    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, crucifixo.transform.position) < 1.5f){

            mensagemItemC.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)){
                pegueiCruc = true;
                Destroy(crucifixo);
                mensagemItemC.SetActive(false);
                StartCoroutine(ShowAndHideMessageCruc(2.0f));
            }

        } else {
            mensagemItemC.SetActive(false);

        }
    }

    IEnumerator ShowAndHideMessageCruc(float duration){
        mensagemCrucAdicionado.SetActive(true);
        yield return new WaitForSeconds(duration);
        mensagemCrucAdicionado.SetActive(false);
    }
}
