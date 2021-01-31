using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMWhenGaming : MonoBehaviour
{
    public GameObject GamingBGM;
    void Start()
    {
        Instantiate(GamingBGM);    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
