using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase<T> : MonoBehaviour where T : Component {

    private static T self;
    public static T Self {

        get {
            if( self == null ) Debug.LogError( string.Format( "did't create this {0} prefab!", typeof( T ).Name ) );
            return self;
        }
    }

    public static bool IsSelf { get { return self != null; } }


    //if prefab already existed, override this.
    protected virtual void Awake() {
        if( self != null ) DestroyImmediate( self.gameObject );
            
        self = this.GetComponent<T>();
    }

    //if prefab not existed and you want to create it on Hierarchy, call this.
    public static T Create( Transform parentTransform, string pPath, Vector3? localPos = null, Vector3? localScale = null ) {

        if( self != null ) return self;
        GameObject target = Instantiate( Resources.Load<GameObject>( pPath + typeof( T ).Name ) );
        if( target == null ) return null;

        T wnd = target.GetComponent<T>();
        if( wnd == null ) {
            DestroyImmediate( target );
            Debug.LogError( string.Format( "{0} prefab no script on this!", typeof( T ).Name ) );
            return null;
        }


        if (parentTransform != null) target.transform.SetParent(parentTransform);
        target.transform.localPosition = localPos ?? Vector3.zero;
        target.transform.localScale = localScale ?? Vector3.one;
        self = wnd;

        return self;
    }
}
