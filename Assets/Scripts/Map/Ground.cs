using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed;
    private Renderer rend;

    void Start()
    {
        this.rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.SetTextureOffset("_MainTex", Vector2.down * (Time.time * this.speed));
    }
}