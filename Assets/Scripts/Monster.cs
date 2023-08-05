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

    public GameObject somMonster;

    [SerializeField] private AudioSource passosMonsterAudioSource;
    [SerializeField] private AudioClip[] passosMonsterAudioClip;

    [SerializeField] private AudioSource somMonsterAttackAudioSource;
    [SerializeField] private AudioClip somMonsterAttackAudioClip;

    [SerializeField] private AudioSource somMonsterAudioSource;
    [SerializeField] private AudioClip somMonsterAudioClip;


    void Start()
    {
        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        maoInimigo = GameObject.FindWithTag("maoInimigo");
        navMesh.speed = velocidadeInimigo;
        maoInimigo.SetActive(false);

        //somMonsterAudioSource.PlayOneShot(somMonsterAudioClip);

    }

    void Update()
    {
        navMesh.destination = player.transform.position;
        animInimigo.SetBool("walk", true);

        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f){
            navMesh.speed = 0;
            maoInimigo.SetActive(true);
            animInimigo.SetBool("attack", true);

            somMonster.SetActive(false);

            StartCoroutine("ataque");
            
        } else {

            StartCoroutine("tempoMonstro");            
            

        }
    }

    IEnumerator ataque(){
        yield return new WaitForSeconds(2.8f);
        animInimigo.SetBool("attack", false);
        maoInimigo.SetActive(false);

        navMesh.speed = velocidadeInimigo;
    }

    private void PassosMonster(){
        passosMonsterAudioSource.PlayOneShot(passosMonsterAudioClip[Random.Range(0, passosMonsterAudioClip.Length)]);
    }

    private void monsterAttack(){
        somMonsterAttackAudioSource.PlayOneShot(somMonsterAttackAudioClip);

    }

    IEnumerator tempoMonstro(){
        yield return new WaitForSeconds(2.0f);
        somMonster.SetActive(true);
    }
}
