using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsForAudioScript : MonoBehaviour
{

    public GameObject sparks;
    public Text openMenu;
    public Image menuBG;

    public bool sparksActive;

    // Start is called before the first frame update
    void Start()
    {
        sparks.SetActive(false);
        openMenu.enabled = false;
        menuBG.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (sparksActive)
            sparks.SetActive(true);

        if (!sparksActive)
            sparks.SetActive(false);

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
            menuBG.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            openMenu.enabled = false;
            menuBG.enabled = false;
        }

    }

}
