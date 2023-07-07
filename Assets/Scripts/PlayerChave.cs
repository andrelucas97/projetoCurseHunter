using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChave : MonoBehaviour
{
    public static bool peguei = false;
    public GameObject chaveObjeto;
    public GameObject mensagemChave;
    public GameObject mensagemChaveAdicionado;

    void Update()
    {
        if (gameObject != null){
            if (Vector3.Distance(transform.position, chaveObjeto.transform.position) < 1.5f){
                mensagemChave.SetActive(true);

                if (Input.GetKey(KeyCode.E)){
                    peguei = true;
                    Destroy(chaveObjeto);
                    mensagemChave.SetActive(false);           
                    StartCoroutine(ShowAndHideMessage(2.0f));
                }
            }
            else {
                mensagemChave.SetActive(false);
            }
        }
    }

    IEnumerator ShowAndHideMessage(float duration){
        mensagemChaveAdicionado.SetActive(true);
        yield return new WaitForSeconds(duration);
        mensagemChaveAdicionado.SetActive(false);
    }
}
