using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{

    private void Awake()
    {
        
    }
    public static bool S_BGM = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScene( string name )
    {
        TransitionPanel.Self.LoadScene( name ); 
        S_BGM = true;
    }



}
