using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungsScript : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource Co2_Collision;
    void Start()
    {
        Co2_Collision = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CO2")
        {
            GameManager._gameManager.InstantiateScore(other.gameObject.transform, 5);
            //Destroy(other.gameObject); Error: disables grabbing!!
            other.gameObject.SetActive(false);
            Co2_Collision.Play();
            GameManager._gameManager.ChangeStatus(0, 5);
        }
    }
}
