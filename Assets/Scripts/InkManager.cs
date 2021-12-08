using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Ink.Runtime;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkManager : MonoBehaviour
{
	public static event Action<Story> OnCreateStory;
	public List<string> tags;
	public Transform playerChoices;
	private SpawnSprites spriteSpawner;

	void Awake()
	{
		// Remove the default message
		RemoveChildren();
		RemoveSprites();
		StartStory();
		spriteSpawner = GetComponent<SpawnSprites>();
	}

	// Creates a new Story object with the compiled story which we can then play!
	void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		RemoveSprites();
		RefreshView();
	}

	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	public void RefreshView()
	{
		// Remove all the UI on screen
		RemoveChildren();

		// Read all the content until we can't continue any more
		while (story.canContinue)
		{
			// Continue gets the next line of the story
			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
			
			// Check for tags
			if (story.currentTags.Count > 0)
			{
				spriteSpawner.ParseTags(story, playerChoices);
			}
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = CreateChoiceView(choice.text.Trim());
				// Tell the button what to do when we press it
				button.onClick.AddListener(delegate
				{
					OnClickChoiceButton(choice);
				});
			}
		}

		

		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			Button choice = CreateChoiceView("Make another?");
			choice.onClick.AddListener(delegate
			{
				StartStory();
            });
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView(string text)
	{
		Text storyText = Instantiate(textPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent(textpanel.transform, false);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView(string text)
	{
		// Creates the button from a prefab
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(optionspanel.transform, false);

		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text>();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren()
	{
		int textchildCount = textpanel.transform.childCount;
		for (int i = textchildCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(textpanel.transform.GetChild(i).gameObject); ;
		}

		int optionschildCount = optionspanel.transform.childCount;
		for (int i = optionschildCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(optionspanel.transform.GetChild(i).gameObject); ;
		}
	}

	// Destroy the children of the PlayerChoices game object (all sprites) 
	void RemoveSprites()
	{
		int childCount = playerChoices.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(playerChoices.transform.GetChild(i).gameObject);
		}
	}


	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;
	public GameObject textpanel;
	public GameObject optionspanel;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab = null;
	[SerializeField]
	private Button buttonPrefab = null;

	//// * * * SPAWN SPRITES * * *
	//// Name
	//public GameObject namePrefab;
	//public Sprite[] nameSprites; 
	//public Transform namePosition;

	//// Snack
	//public GameObject snackPrefab;
	//public Sprite[] snackSprites;
	//public Transform snackPosition;

	//// Memory
	//public GameObject memoryPrefab;
	//public Sprite[] memorySprites;
	//public Transform memoryPosition;


	//public void ParseTags()
	//{
	//	tags = story.currentTags;
	//	foreach (string t in tags)
	//	{
	//		string prefix = t.Split(' ')[0];
	//		string param = t.Split(' ')[1];

	//		switch (prefix.ToLower())
	//		{
	//			case "name":
	//				namePrefab.GetComponent<SpriteRenderer>().sprite = nameSprites[int.Parse(param)];
	//				Instantiate(namePrefab, playerChoices);
	//				Vector2 namePosition = namePrefab.transform.position;
	//				print("my name is");
	//				print(namePrefab.GetComponent<SpriteRenderer>().sprite);
	//				break;

	//			case "snack":
	//				snackPrefab.GetComponent<SpriteRenderer>().sprite = snackSprites[int.Parse(param)];
	//				Instantiate(snackPrefab, playerChoices);
	//				Vector2 snackPosition = snackPrefab.transform.position;
	//				break;

	//			case "memory":
	//				memoryPrefab.GetComponent<SpriteRenderer>().sprite = memorySprites[int.Parse(param)];
	//				Instantiate(memoryPrefab, playerChoices);
	//				Vector2 memoryPosition = memoryPrefab.transform.position;
	//				break;
	//		}
	//	}
	//}
}
