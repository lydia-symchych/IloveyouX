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
        print(tag.Length);
        foreach (string t in tags)
        {
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "morningdrink": 
                    var morningdrink = Instantiate(morningdrinkPrefab, playerChoices);
                    print("prefab made");
                    morningdrink.GetComponent<SpriteRenderer>().sprite = morningdrinkSprites[int.Parse(param)];
                    print("sprite set");
                    Vector2 morningdrinkPosition = morningdrink.transform.position;
                    break;

                case "season":
                    var season = Instantiate(seasonPrefab, playerChoices);
                    season.GetComponent<SpriteRenderer>().sprite = seasonSprites[int.Parse(param)];
                    Vector2 seasonPosition = season.transform.position;
                    break;

                case "weather":
                    var weather = Instantiate(weatherPrefab, playerChoices);
                    weather.GetComponent<SpriteRenderer>().sprite = weatherSprites[int.Parse(param)];
                    Vector2 weatherPosition = weather.transform.position;
                    break;

                case "name":
                    var name = Instantiate(namePrefab, playerChoices);
                    name.GetComponent<SpriteRenderer>().sprite = nameSprites[int.Parse(param)];
                    Vector2 namePosition = name.transform.position;
                    break;

                case "petname":
                    var petname = Instantiate(petnamePrefab, playerChoices);
                    petname.GetComponent<SpriteRenderer>().sprite = petnameSprites[int.Parse(param)];
                    Vector2 petnamePosition = petname.transform.position;
                    break;

                case "snack":
                    var snack = Instantiate(snackPrefab, playerChoices);
                    snack.GetComponent<SpriteRenderer>().sprite = snackSprites[int.Parse(param)];
                    Vector2 snackPosition = snack.transform.position;
                    break;

                case "memory":
                    var memory = Instantiate(memoryPrefab, playerChoices);
                    memory.GetComponent<SpriteRenderer>().sprite = memorySprites[int.Parse(param)];
                    Vector2 memoryPosition = memory.transform.position;
                    break;

                case "end":
                    var end = Instantiate(endPrefab,playerChoices);
                    break;
            }
        }

    }


}
