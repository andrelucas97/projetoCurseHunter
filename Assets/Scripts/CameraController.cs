using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float alturaCamera = 1.3f;
    public float Sensibilidade = 300.0f;
    public float limiteRotacao = 45.0f;
    float rotX;
    float rotY;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        rotX += MouseX * Sensibilidade * Time.deltaTime;
        rotY -= MouseY * Sensibilidade * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, -limiteRotacao, limiteRotacao);
        transform.rotation = Quaternion.Euler(rotY, rotX, 0);
    }

    private void LateUpdate(){
        transform.position = player.position + player.up * alturaCamera;
    }
}
