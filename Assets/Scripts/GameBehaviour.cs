using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class GameBehaviour : MonoBehaviour {
    private float canvasWidth = 850f;
    private float canvasHeight = 700f;
    public float scale = 0.75f;

    public Sprite blueCirclePrefab;
    public Sprite greenCirclePrefab;
    public Sprite pinkCirclePrefab;
    public Sprite purpleCirclePrefab;
    public Sprite redCirclePrefab;
    public Sprite yellowCirclePrefab;

    public List<Sprite> circles;
    public bool goodCircleTagged = false;
    int amountOfCircles;

    public static bool gameStarted = false;

    bool roundIinitialized = false;
    void Update() {
        // Debug.Log(gameStarted);
        if (gameStarted && !roundIinitialized) { 
            InitializeRoundDelay();
            roundIinitialized = true;
        }
    }
    
    public void InitializeRoundDelay() {
        Invoke("InitializeRound", 1f);
    }
    
    public void InitializeRound() {
        RandomizeColor.RndColor();
        InitializePossibilitiesList();
        StartNextRound();   
    }

    public void InitializePossibilitiesList() {
        circles = new List<Sprite> {
            blueCirclePrefab,
            greenCirclePrefab,
            pinkCirclePrefab,
            purpleCirclePrefab,
            redCirclePrefab,
            yellowCirclePrefab
        };

        amountOfCircles = circles.Count;
    }

    public void StartNextRound() {
        for (int i = 0; i < amountOfCircles; i++) {
            SpawnSprite();
        }
    }

    void SpawnSprite() {
        // Spawning Circle
        GameObject spriteGO = new GameObject("Sprite");
        spriteGO.transform.SetParent(transform);

        Image spriteImage = spriteGO.AddComponent<Image>();

        if (!goodCircleTagged) {
            // Tag good Circle
            spriteImage.sprite = circles[RandomizeColor.GetCorrectColorIndex()];
            circles.RemoveAt(RandomizeColor.correctColorIndex);

            spriteGO.tag = "Good";
            goodCircleTagged = true;

            // Puting good candy on front
            SpriteRenderer spriteRenderer = spriteGO.AddComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 100;
        } else {
            // Tag wrong Circle
            int randomIndex = Random.Range(0, circles.Count);
            spriteImage.sprite = circles[randomIndex];
            circles.RemoveAt(randomIndex);

            spriteGO.tag = "Wrong";
        }

        RectTransform rt = spriteGO.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Random.Range(-canvasWidth / 2f, canvasWidth / 2f),
                                          Random.Range(-canvasHeight / 2f, canvasHeight / 2f));
        rt.localScale = new Vector2(scale, scale);
        rt.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));

        // Interacting with spawned Circle
        EventTrigger trigger = spriteGO.AddComponent<EventTrigger>();
        EventTrigger.Entry clickEntry = new EventTrigger.Entry();
        clickEntry.eventID = EventTriggerType.PointerClick;
        clickEntry.callback.AddListener((data) => { OnSpriteClicked(spriteGO); });
        trigger.triggers.Add(clickEntry);
    }

    string spritesParentName;

    void OnSpriteClicked(GameObject spriteGO) {
        spritesParentName = spriteGO.transform.parent.gameObject.name;
        ResponseToCircleClick.ResponseToClick(spritesParentName, spriteGO.tag);

        Destroy(spriteGO);
    }
}