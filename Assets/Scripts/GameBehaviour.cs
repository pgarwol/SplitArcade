using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class GameBehaviour : MonoBehaviour {

    private float canvasWidth = 850f;
    private float canvasHeight = 800f;
    [SerializeField] private float scale = 0.05f;

    [SerializeField] private Sprite blueCirclePrefab;
    [SerializeField] private Sprite greenCirclePrefab;
    [SerializeField] private Sprite pinkCirclePrefab;
    [SerializeField] private Sprite purpleCirclePrefab;
    [SerializeField] private Sprite redCirclePrefab;
    [SerializeField] private Sprite yellowCirclePrefab;

    private bool goodCandyTagged;
    private List<Sprite> candies;
    private int amountOfCandies;

    [SerializeField] private AudioClip gameMusic;
    private static bool gameStarted = false;

    bool isRoundInitialized = false;

    void Start () {
        SoundSystemSingleton.Instance.PlayMusicSound(gameMusic);
        goodCandyTagged = false;
    }

    void Update() {
        if (gameStarted && !isRoundInitialized) { 
            InitializeRoundDelay();
            isRoundInitialized = true;
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
        candies = new List<Sprite> {
            blueCirclePrefab,
            greenCirclePrefab,
            pinkCirclePrefab,
            purpleCirclePrefab,
            redCirclePrefab,
            yellowCirclePrefab
        };

        amountOfCandies = candies.Count;
    }

    public void StartNextRound() {
        for (int i = 0; i < amountOfCandies; i++)
            SpawnSprite();
    }

    void SpawnSprite() {
        // Spawning Circle
        GameObject spriteGO = new GameObject("Sprite");
        spriteGO.transform.SetParent(transform);
        Image spriteImage = spriteGO.AddComponent<Image>();

        // Adding layer sorting possibility
        SpriteRenderer spriteRenderer = spriteGO.AddComponent<SpriteRenderer>();
        SortingGroup sortingGroup = spriteGO.AddComponent<SortingGroup>();
        spriteRenderer.sortingLayerName = "Candies";

        if (!goodCandyTagged) {
            // Tag good Candy
            spriteImage.sprite = candies[RandomizeColor.GetCorrectColorIndex()];
            candies.RemoveAt(RandomizeColor.correctColorIndex);

            spriteGO.tag = "Good";
            goodCandyTagged = true;

            // Puting good candy on front
            spriteRenderer.sortingOrder = 1;
        } else {
            // Tag wrong Candy
            int randomIndex = Random.Range(0, candies.Count);
            spriteImage.sprite = candies[randomIndex];
            candies.RemoveAt(randomIndex);

            spriteGO.tag = "Wrong";

            // Puting wrong candy on back
            spriteRenderer.sortingOrder = 0;
        }

        // Randomizing Candy position on screen
        RectTransform rt = spriteGO.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Random.Range(-canvasWidth / 2f, canvasWidth / 2f),
                                          Random.Range(-canvasHeight / 2f, canvasHeight / 2f));
        rt.localScale = new Vector2(scale, scale);
        rt.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360f));

        // Interacting with spawned Candy
        EventTrigger trigger = spriteGO.AddComponent<EventTrigger>();
        EventTrigger.Entry clickEntry = new EventTrigger.Entry();
        clickEntry.eventID = EventTriggerType.PointerClick;
        clickEntry.callback.AddListener((data) => { OnSpriteClicked(spriteGO); });
        trigger.triggers.Add(clickEntry);
    }

    private string spritesParentName;

    void OnSpriteClicked(GameObject spriteGO) {
        spritesParentName = spriteGO.transform.parent.gameObject.name;
        ResponseToCircleClick.ResponseToClick(spritesParentName, spriteGO.tag);
        Destroy(spriteGO);
    }

    private static bool gameFinished = false;

    public static void FinishGame(string winner, string loser) {
        ResponseToCircleClick.leftSideCanvas.DestroyCandies();
        ResponseToCircleClick.rightSideCanvas.DestroyCandies();

        InGameCanvasBehaviour.ShowWinner(winner, loser);
        InGameCanvasBehaviour.ShowAGDCanvas();

        gameFinished = true;
    }

    public static bool IsGameFinished() {
        return gameFinished;
    }

    public void SetGoodCandyTaggedFalse() {
        goodCandyTagged = false;
    }

    public static bool IsGameStarted() {
        return gameStarted;
    }

    public static void SetIsGameStartedTrue() {
        gameStarted = true;
    }

    public static void SetIsGameStartedFalse() {
        gameStarted = false;
    }
}