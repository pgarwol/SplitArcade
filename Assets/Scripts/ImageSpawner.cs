using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class ImageSpawner : MonoBehaviour {
    public Sprite spritePrefab;
    private float canvasWidth = 850f;
    private float canvasHeight = 700f;
    public float scale = 0.75f;

    void Start() {
        InvokeRepeating("SpawnSprite", 0f, 1f);
    }

    void SpawnSprite() {
        // Spawning Circle
        GameObject spriteGO = new GameObject("Sprite");
        spriteGO.transform.SetParent(transform);

        Image spriteImage = spriteGO.AddComponent<Image>();
        spriteImage.sprite = spritePrefab;

        RectTransform rt = spriteGO.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Random.Range(-canvasWidth / 2f, canvasWidth / 2f),
                                          Random.Range(-canvasHeight / 2f, canvasHeight / 2f));
        rt.localScale = new Vector2(scale, scale);

        // Interacting with spawned Circle
        EventTrigger trigger = spriteGO.AddComponent<EventTrigger>();
        EventTrigger.Entry clickEntry = new EventTrigger.Entry();
        clickEntry.eventID = EventTriggerType.PointerClick;
        clickEntry.callback.AddListener((data) => { OnSpriteClicked(spriteGO); });
        trigger.triggers.Add(clickEntry);
    }

    void OnSpriteClicked(GameObject spriteGO) {
        Destroy(spriteGO);
    }
}