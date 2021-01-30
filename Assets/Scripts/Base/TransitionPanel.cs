using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;
using DG.Tweening.Core;

public class TransitionPanel : UIBase<TransitionPanel> {

    public const string UIPath = "Prefabs/";

    public CanvasGroup group;
    private bool animationFinish = false;
    private float transitionDuration = 0.3f; //轉換場景持續時間

    private AsyncOperation asyncLoad;
    private AsyncOperation asyncUnLoad;

    [HideInInspector]
    public List<string> hideScenes = new List<string>();

    [HideInInspector]
    public string currentNani;
    [HideInInspector]
    public int currentStartLineIndex = 0;
    [HideInInspector]
    public bool loadSlotAvg = false;
    [HideInInspector]
    public bool loginReview = false;
    private Action callback;

    protected override void Awake() {
        base.Awake();

        //SceneManager.activeSceneChanged += ChangedActiveScene;
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update() {
        //Debug.LogError( group.alpha );
    }


    public void LoadScene( string name ) {

        OutFade(() => { StartCoroutine(LoadYourAsyncScene(name)); });


    }


    IEnumerator LoadYourAsyncScene( string name )
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        InFade(null);
    }


    public void OutFade( Action onComplete )
    {
        group.DOFade(1f, transitionDuration).SetEase(Ease.OutQuad).OnComplete(() => {

            if (onComplete != null) onComplete();
        });
    }

    public void InFade( Action onComplete )
    {
        group.DOFade(0f, transitionDuration).SetEase(Ease.InQuad).OnComplete(() => {

            if (onComplete != null) onComplete();
        });
    }



    /*
    //Async/await版本
    public async UniTask LoadNani( string name, string unloadScene = null, string hideBeforeScene = null ) {

        //await UniTask.Delay( 100 );
        //hideAll功能
        //var managers = Engine.GetAllServices<IActorManager>();
        //await UniTask.WhenAll( managers.SelectMany( m => m.GetAllActors() ).Select( a => a.ChangeVisibilityAsync( false, 0f ) ) );

        //List<string> resetUI = new List<string> { "IScriptPlayer", "ITextPrinterManager" };
        //await Engine.GetService<IStateManager>().ResetStateAsync( resetUI.ToArray() );

        group.DOFade( 1f, 0.3f ).SetEase( Ease.OutQuad ).OnComplete( () => {

            animationFinish = true;
        } );


        asyncLoad = SceneManager.LoadSceneAsync( name, LoadSceneMode.Additive );
        asyncLoad.allowSceneActivation = false;

        while( !asyncLoad.isDone ) {

            if( asyncLoad.progress >= 0.9f && animationFinish )
                asyncLoad.allowSceneActivation = true;

            await UniTask.Yield( PlayerLoopTiming.PostLateUpdate );// replace yield return null
        }

        if( hideBeforeScene != null ) {
            foreach( var item in SceneManager.GetSceneByName( hideBeforeScene ).GetRootGameObjects() ) { //隱藏前場景
                item.SetActive( false );
            }
        }

        SceneManager.SetActiveScene( SceneManager.GetSceneByName( name ) );//繳活新的場景

        //var player = Engine.GetService<IScriptPlayer>();
        //await player.PreloadAndPlayAsync( "chapter0_1" );
        
        //UnLoadEvent
        if( unloadScene != null ) asyncUnLoad = SceneManager.UnloadSceneAsync( unloadScene );

        if( asyncUnLoad != null ) {
            while( !asyncUnLoad.isDone ) {

                await UniTask.Yield( PlayerLoopTiming.PostLateUpdate );// replace yield return null
            }
        }
        //------

        group.DOFade( 0f, 0.3f ).SetEase( Ease.InQuad ).OnComplete( () => {
            asyncLoad = null;
            asyncUnLoad = null;
            animationFinish = false;
        } );


    }
    */
 



    /*
    void OnSceneLoaded( Scene scene, LoadSceneMode mode ) {

        if( scene.name.Equals( "Avg" ) && currentNani != "" ) {

            var player = Engine.GetService<IScriptPlayer>();
            player.PreloadAndPlayAsync( currentNani );

        }
    }
    */

 
}
