using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsForAudioScript : MonoBehaviour
{

    public GameObject sparks;
    public Text openMenu;
    public GameObject menuBG;
    public GameObject player;
    public GameObject cam;
    public GameObject audioSound;
    public GameObject[] lights = new GameObject[3];

    public Slider volume;

    public bool sparksActive;

    // Start is called before the first frame update
    void Start()
    {
        sparks.SetActive(false);
        openMenu.enabled = false;
        menuBG.SetActive(false);

        lights = GameObject.FindGameObjectsWithTag("Lights");
    }

    // Update is called once per frame
    void Update()
    {

        audioSound.GetComponent<AudioSource>().volume = volume.value;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            openMenu.enabled = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
    
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            openMenu.enabled = false;
            menuBG.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
            cam.GetComponent<CameraScript>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.Escape))
        {
            openMenu.enabled = true;
            menuBG.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            cam.GetComponent<CameraScript>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            openMenu.enabled = false;
            menuBG.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void activateSparks()
    {
        sparks.SetActive(true);

    }

    public void deactivateSparks()
    {
        sparks.SetActive(false);

    }

    public void activateLights()
    {

       // lights = GameObject.FindGameObjectsWithTag("Lights");

        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }

    }

    public void deactivateLights()
    {

       // lights = GameObject.FindGameObjectsWithTag("Lights");

        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }

    }

}
