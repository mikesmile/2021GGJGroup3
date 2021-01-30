
using DG.Tweening;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.EventSystems;

public class Config : MonoBehaviour {
    public static Config Self { get; private set; }

    public static string filePath;
    public static string screenShotPath;
    public static int rootYear = 1987;



    void Awake()
    {
        filePath = Application.persistentDataPath + "/gamesave.dat";
        screenShotPath = Application.persistentDataPath + "/ScreenShot";
    }

    //暫時,實際會依靠點擊存檔
    private void Start() {

        //Engine.OnInitializationFinished += Engine_OnInitializationFinished;

    }

    private void Update() {

        //if( GameObject.FindWithTag( "SettingBtn" ) != null && GameObject.FindWithTag( "SettingBtn" ).activeSelf ) {

        //    if( Input.GetKey( KeyCode.Escape ) ) {
        //        //Debug.Log( "Escape key is being pressed" );
        //        var pointer = new PointerEventData( EventSystem.current );
        //        ExecuteEvents.Execute( GameObject.FindWithTag( "SettingBtn" ), pointer, ExecuteEvents.pointerEnterHandler );
        //        ExecuteEvents.Execute( GameObject.FindWithTag( "SettingBtn" ), pointer, ExecuteEvents.pointerClickHandler );
        //        ExecuteEvents.Execute( GameObject.FindWithTag( "SettingBtn" ), pointer, ExecuteEvents.pointerExitHandler );
        //    }
        //}
    }

    //private void Engine_OnInitializationFinished() {

    //    var audio = Engine.GetService<IAudioManager>();
    //    audio.BgmVolume = SaveDataHandler.Self.saveData.musicVolume;
    //    audio.SfxVolume = SaveDataHandler.Self.saveData.soundVolume;
    //}

    public void RandomInitObject()
    {
        int r = UnityEngine.Random.Range(0,2);

        Debug.LogError(r);
    }
    

    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    public static void LoadConfig() {
        DOTween.Init();
        GameObject config = Instantiate( Resources.Load<GameObject>( "Prefabs/Config" ) );
        Self = config.GetComponent<Config>();
        DontDestroyOnLoad( config );
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadTransition()
    {
        GameObject transitionCanvas = Instantiate(Resources.Load<GameObject>("Prefabs/TransitionCanvas"));
        DontDestroyOnLoad(transitionCanvas);
    }


    //[RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    //public static void LoadSaveData() { //讀遊戲資料(未選擇存檔

    //    if( !File.Exists( filePath ) ) {
    //        SaveDataHandler.Self.Init();
    //    }
    //    else {
    //        SaveDataHandler.Self.saveData = Load();
    //    }

    //}



    //public string getLocalizationText( int id, string str1 = "", string str2 = "", string str3 = "" ) {

    //    var currentLanguage = SaveDataHandler.Self.saveData.currentLanguage;

    //    string txt = "";
    //    //currentLanguage = Language.TW;
    //    if( currentLanguage == Language.EN ) {

    //        txt = TableManager.Self.localizationCsv.GetLocalizationCsvDataFirst( id ).TEXT_US;
    //    }
    //    else if( currentLanguage == Language.TW ) {

    //        txt = TableManager.Self.localizationCsv.GetLocalizationCsvDataFirst( id ).TEXT_TW;
    //    }
    //    else if( currentLanguage == Language.CN ) {

    //        txt = TableManager.Self.localizationCsv.GetLocalizationCsvDataFirst( id ).TEXT_CN;
    //    }

    //    if( str1 != "" ) txt = txt.Replace( "{0}", str1 );
    //    if( str2 != "" ) txt = txt.Replace( "{1}", str2 );
    //    if( str3 != "" ) txt = txt.Replace( "{2}", str3 );

    //    return txt;

    //}

    //public static Texture2D ResetTexture( Texture2D orginalTexture ) {


    //    Texture2D texture = new Texture2D( 384, 216, TextureFormat.RGB24, false );
    //    texture.wrapMode = TextureWrapMode.Clamp;

    //    for( int i = 0; i < texture.height; i++ )//压缩图片
    //    {
    //        for( int j = 0; j < texture.width; j++ ) {
    //            Color color = orginalTexture.GetPixel( j * 5, i * 5 );
    //            texture.SetPixel( j, i, color );

    //        }
    //    }
    //    texture.Apply();

    //    return texture;
    //}


    //public class StringReplace {
    //    public const string comma = "(comma)";
    //    public const string str1 = "%1";
    //    public const string str2 = "%2";
    //    public const string str3 = "%3";
    //}
}
