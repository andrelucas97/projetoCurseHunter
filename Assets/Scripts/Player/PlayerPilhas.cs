using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPilhas : MonoBehaviour
{
    public GameObject pilha;
    public GameObject pilha2;
    public GameObject pilha3;
    public GameObject pilha4;
    
    public GameObject mensagemSemPilha;
    public GameObject luzLanterna;
    public Image barraDeProgresso;

    public GameObject mensagemTeste;

    public static float bateriaAtual = 40f;
    public static float bateriaMaximo = 100f;

    public Color corVerde = new Color(0f, 0.5943396f, 0.1097162f);
    public Color corAmarelo = new Color(0.5960785f, 0.5705061f, 0f);
    public Color corVermelho = new Color(0.6698113f, 0.02470707f, 0f);

    public float taxaDescarregamento = 2f;

    public float dateTimeTeste = 0f;

    private float ultimaRecarga;
    

    void Start()
    {
        ultimaRecarga = Time.time;        
        InvokeRepeating("DescarregarBateria", 1f, 1f);

    }

    void Update()
    {    

        float proporcaoBateria = bateriaAtual / bateriaMaximo;
        barraDeProgresso.transform.localScale = new Vector3(proporcaoBateria, 1f, 1f);     
    }

    void DescarregarBateria(){
    if (!luzLanterna.activeSelf){
        ultimaRecarga = Time.time;
        return;
        }
    
    float segundosDesdeRecarga = Time.time - ultimaRecarga;
    ultimaRecarga = Time.time;

    float bateriaDescarregada = taxaDescarregamento * segundosDesdeRecarga;

    bateriaAtual -= bateriaDescarregada;
    bateriaAtual = Mathf.Max(bateriaAtual, 0f);

    float proporcaoBateria = bateriaAtual / bateriaMaximo;
    barraDeProgresso.transform.localScale = new Vector3(proporcaoBateria, 1f, 1f);

    if ((proporcaoBateria > 1f / 2f)){
        barraDeProgresso.color = corVerde;
    }

    else if ((proporcaoBateria <= 1f / 2f) && (proporcaoBateria > 1f / 3f)){
        barraDeProgresso.color = corAmarelo;
        }
    else if (proporcaoBateria <= 1f / 3f){
        barraDeProgresso.color = corVermelho;
        }

    if (bateriaAtual <= 0f){
        luzLanterna.SetActive(false);
        }
    }

    void ExibirDateTime(){
    System.DateTime dataAtual = System.DateTime.Now;
    Debug.Log("Data e hora atual: " + dataAtual);
    }
}
