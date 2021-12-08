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

    // Morning Drink
    public GameObject morningdrinkPrefab;
    public Sprite[] morningdrinkSprites;
    public Transform morningdrinkPosition;

    // Season
    public GameObject seasonPrefab;
    public Sprite[] seasonSprites;
    public Transform seasonPosition;

    // Weather
    public GameObject weatherPrefab;
    public Sprite[] weatherSprites;
    public Transform weatherPosition;

    // Name
    public GameObject namePrefab;
    public Sprite[] nameSprites;
    public Transform namePosition;

    // Petname
    public GameObject petnamePrefab;
    public Sprite[] petnameSprites;
    public Transform petnamePosition;

    // Snack
    public GameObject snackPrefab;
    public Sprite[] snackSprites;
    public Transform snackPosition;

    // Memory
    public GameObject memoryPrefab;
    public Sprite[] memorySprites;
    public Transform memoryPosition;

    // End
    public GameObject endPrefab;

    // Filler
    // Filler images will need to be handled differently because it's not one prefab with one transform like choice-based sprites. 
    // I think this should be linked to flavor choices such as the way you respond to your grandchild when they ask if you know their fav snack. 
    // Can I make an array of prefabs and then instantiate elements from that array? public GameObject[] fillerPrefabs;

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
                case "morningdrink":
                    Instantiate(morningdrinkPrefab);
                    morningdrinkPrefab.GetComponent<SpriteRenderer>().sprite = morningdrinkSprites[int.Parse(param)];
                    Vector2 morningdrinkPosition = morningdrinkPrefab.transform.position;
                    break;

                case "season":
                    Instantiate(seasonPrefab);
                    seasonPrefab.GetComponent<SpriteRenderer>().sprite = seasonSprites[int.Parse(param)];
                    Vector2 seasonPosition = seasonPrefab.transform.position;
                    break;

                case "weather":
                    Instantiate(weatherPrefab);
                    weatherPrefab.GetComponent<SpriteRenderer>().sprite = weatherSprites[int.Parse(param)];
                    Vector2 weatherPosition = weatherPrefab.transform.position;
                    break;

                case "name":
                    Instantiate(namePrefab);
                    namePrefab.GetComponent<SpriteRenderer>().sprite = nameSprites[int.Parse(param)];
                    Vector2 namePosition = namePrefab.transform.position;
                    break;

                case "petname":
                    Instantiate(petnamePrefab);
                    petnamePrefab.GetComponent<SpriteRenderer>().sprite = petnameSprites[int.Parse(param)];
                    Vector2 petnamePosition = petnamePrefab.transform.position;
                    break;

                case "snack":
                    Instantiate(snackPrefab);
                    snackPrefab.GetComponent<SpriteRenderer>().sprite = snackSprites[int.Parse(param)];
                    Vector2 snackPosition = snackPrefab.transform.position;
                    break;

                case "memory":
                    Instantiate(memoryPrefab);
                    memoryPrefab.GetComponent<SpriteRenderer>().sprite = memorySprites[int.Parse(param)];
                    Vector2 memoryPosition = snackPrefab.transform.position;
                    break;

                case "end":
                    Instantiate(endPrefab);
                    break;
            }
        }
    }
}
