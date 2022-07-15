using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> HighScoreEntryList;
    private List<Transform> HighScoreEntryTransformList; 

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        HighScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{score = 100000, name ="BAD"},
            new HighScoreEntry{score = 50000, name ="SAD"},
            new HighScoreEntry{score = 10000, name ="MAD"},
            new HighScoreEntry{score = 9000, name ="DAD"},
            new HighScoreEntry{score = 8000, name ="PAD"},
            new HighScoreEntry{score = 7000, name ="FAD"},
            new HighScoreEntry{score = 6000, name ="AD"},
            new HighScoreEntry{score = 5000, name ="HEPTAD"},
            new HighScoreEntry{score = 4000, name ="VLAD"},

        };

        



        HighScoreEntryTransformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in HighScoreEntryList)
        {
            CreateHigghScoreEntryTransform(highScoreEntry, entryContainer, HighScoreEntryTransformList);
        }

    }

    private void CreateHigghScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList) 
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        entryTransform.Find("Positiontxt").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;

        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("Nametxt").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);


    }

    private class HighScoreEntry
    {
        public int score;
        public string name; 

    }


}
