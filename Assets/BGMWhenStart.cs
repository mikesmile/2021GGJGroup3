using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMWhenStart : MonoBehaviour
{
    public GameObject StartedBGM;
    // public GameObject AfterS_BGM;
    void Start()
    {
        Instantiate(StartedBGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (Test.S_BGM == true)
        {
            Destroy(gameObject);
            // AfterS_BGM.SetActive(true);
        }
    }
}
