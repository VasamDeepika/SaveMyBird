using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Movement speed
    public float speed = 5;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed;//flies towards left always
        
    }
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}