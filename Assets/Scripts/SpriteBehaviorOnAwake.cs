using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviorOnAwake : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Awake()
    {
        print("awake");
       
        // set the color's alpha component to 0 --> fully transparent
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.color;
        c.a = 0f;
        rend.color = c;

        // start fading sprite in
        StartCoroutine("FadeIn");
    }

    //Fade In coroutine | based on this tutorial https://www.youtube.com/watch?v=oNz4I0RfsEg
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f+= 0.05f)
        {
            Color c = rend.color;
            c.a = f;
            rend.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
