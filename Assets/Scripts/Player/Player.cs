using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int vidaPlayer = 1;
    public float velocidadeCorrida = 5;
    public float velocidadeAndar = 3;
    public Camera cameraPlayer;
    public GameObject sangueTela;
    public GameObject iconCrucifixo;

    public GameObject mensagemMorte;

    private float velocidadePlayer;
    private Vector3 direcoes;
    private Animator anim;

    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioSource passosCorrendoAudioSource;
    [SerializeField] private AudioClip[] passosAudioClip;
    [SerializeField] private AudioClip[] passosCorrendoAudioClip;


    void Start()
    {
        anim = GetComponent<Animator>();
        sangueTela.SetActive(false);
        iconCrucifixo.SetActive(false);
    }

    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");
        float InputRun = Input.GetAxis("correr");

        direcoes = new Vector3(InputX, 0, InputZ);
        if (InputX != 0 || InputZ != 0){
            var camrotation = cameraPlayer.transform.rotation;
            camrotation.x = 0;
            camrotation.z = 0;
            anim.SetBool("walk", true);
            transform.Translate(0, 0, velocidadePlayer * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcoes) * camrotation, 5 * Time.deltaTime);

            if (InputRun != 0){
                anim.SetBool("run", true);
                velocidadePlayer = velocidadeCorrida;
            }
            else {
                anim.SetBool("run", false);
                velocidadePlayer = velocidadeAndar;
            }
        }

        else if (InputX == 0 && InputZ ==0){
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }

        if (vidaPlayer <= 0){
            velocidadePlayer = 0;
            mensagemMorte.SetActive(true);
            //StartCoroutine("morte");

        }

        if (PlayerCruc.pegueiCruc == true){
            iconCrucifixo.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "maoInimigo"){
            vidaPlayer -= 1;
            sangueTela.SetActive(true);
        }
    }

    //IEnumerator morte(){
    //    yield return new WaitForSeconds(4.0f);
    //    SceneManager.LoadScene("GameOver");
    //}

    private void Passos(){
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }

    private void PassosCorrendo(){
        passosCorrendoAudioSource.PlayOneShot(passosCorrendoAudioClip[Random.Range(0, passosAudioClip.Length)]);

    }
}
