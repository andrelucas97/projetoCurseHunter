using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Monster : MonoBehaviour
{

    private Animator animInimigo;
    private NavMeshAgent navMesh;
    private GameObject player;
    public float velocidadeInimigo;
    private GameObject maoInimigo;

    void Start()
    {
        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        maoInimigo = GameObject.FindWithTag("maoInimigo");
        navMesh.speed = velocidadeInimigo;
        maoInimigo.SetActive(false);

    }

    void Update()
    {
        navMesh.destination = player.transform.position;
        animInimigo.SetBool("walk", true);

        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f){
            navMesh.speed = 0;
            maoInimigo.SetActive(true);
            animInimigo.SetBool("attack", true);
            StartCoroutine("ataque");
        }
    }

    IEnumerator ataque(){
        yield return new WaitForSeconds(2.8f);
        animInimigo.SetBool("attack", false);
        maoInimigo.SetActive(false);

        navMesh.speed = velocidadeInimigo;
    }
}
