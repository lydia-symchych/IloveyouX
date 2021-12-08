using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;

public class SpawnSprites : MonoBehaviour
{
    public List<string> tags;
    public static event Action<Story> OnCreateStory​;
    public Story story;

    // Name
   public GameObject namePrefab;
   public Sprite[] nameSprites;
   public Transform namePosition;
    

   // Snack
   public GameObject snackPrefab;
   public Sprite[] snackSprites;
   public Transform snackPosition;

    private void Start()
    {
        
    }
   
    private void RefreshView()
    {
      
    }

    public void ParseTags(Story story, Transform playerChoices)
    {
        tags = story.currentTags;
        foreach (string t in tags)
        {
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "name":
                    Instantiate(namePrefab);
                    namePrefab.GetComponent<SpriteRenderer>().sprite = nameSprites[int.Parse(param)];
                    Vector2 namePosition = namePrefab.transform.position;
                    print("my name is");
                    break;

                case "snack":
                    Instantiate(snackPrefab);
                    snackPrefab.GetComponent<SpriteRenderer>().sprite = snackSprites[int.Parse(param)];
                    Vector2 snackPosition = snackPrefab.transform.position;
                    break;
            }
        }
    }
}
