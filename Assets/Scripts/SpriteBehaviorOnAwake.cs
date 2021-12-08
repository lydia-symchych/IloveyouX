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

    private void Awake() //OnEnable
    {
        print("Awake");
       
        // set the color's alpha component to 0 --> fully transparent
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.color;
        c.a = 0f;
        rend.color = c;

        StartCoroutine("FadeIn");
    }




    //Fade In coroutine | based on this tutorial https://www.youtube.com/watch?v=oNz4I0RfsEg
    public IEnumerator FadeIn()
    {
        print("fade in");
        for (float f = 0.05f; f <= 1; f+= 0.05f)
        {
            Color c = rend.color;
            c.a = f;
            rend.color = c;
            yield return new WaitForSeconds(0.05f); //was 0.05f
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
