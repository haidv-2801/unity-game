using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite aliveGate;
    public Sprite dieGate;

    private SpriteRenderer checkpointSpriteRender;
    public bool checkpointReached;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           /* checkpointSpriteRender.sprite = dieGate;*/
            checkpointReached = true;
        }
    }
}
