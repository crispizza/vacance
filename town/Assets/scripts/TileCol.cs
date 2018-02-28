using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCol : MonoBehaviour {
    
    private Color red = Color.red;
    private Color green = Color.green;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item" || collision.gameObject.tag == "block")
            gameObject.GetComponent<SpriteRenderer>().color = red;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item" || collision.gameObject.tag == "block")
            gameObject.GetComponent<SpriteRenderer>().color = red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item" || collision.gameObject.tag == "block")
            gameObject.GetComponent<SpriteRenderer>().color = green;
    }
}
