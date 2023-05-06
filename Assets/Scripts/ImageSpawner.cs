using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSpawner : MonoBehaviour {
    public Sprite spritePrefab;
    private float canvasWidth = 850f;
    private float canvasHeight = 700f;
    public float scale = 0.75f;

    void Start() {
        InvokeRepeating("SpawnSprite", 0f, 1f);
    }

    void SpawnSprite() {
        GameObject spriteGO = new GameObject("Sprite");
        spriteGO.transform.SetParent(transform);

        Image spriteImage = spriteGO.AddComponent<Image>();
        spriteImage.sprite = spritePrefab;

        RectTransform rt = spriteGO.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Random.Range(-canvasWidth / 2f, canvasWidth / 2f),
                                          Random.Range(-canvasHeight / 2f, canvasHeight / 2f));
        rt.localScale = new Vector2(scale, scale);
    }
}