using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    private bool isOn = true; //is flashlight on or off?

    [SerializeField] private AudioSource lanternaAudioSource;
    [SerializeField] private AudioClip lanternaAudioClip;



    // Use this for initialization
    void Start()
    {
        //set default off
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            //toggle light
            isOn = !isOn;
            //turn light on
            if (isOn)
            {
                lanternaAudioSource.PlayOneShot(lanternaAudioClip);
                lightGO.SetActive(true);
            }
            //turn light off
            else
            {
                lanternaAudioSource.PlayOneShot(lanternaAudioClip);
                lightGO.SetActive(false);

            }
        }
    }
}
