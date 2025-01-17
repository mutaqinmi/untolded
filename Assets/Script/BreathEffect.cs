using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingEffect : MonoBehaviour
{
    [SerializeField] private bool questSign;

    private Vector3 originalScale;
    private float scaleMultiplier; // Besar perubahan skala
    private float speed; // Kecepatan animasi

    void Start()
    {
        if (questSign)
        {
            scaleMultiplier = 1.1f;
            speed = 2.5f;
        }
        else
        {
            scaleMultiplier = 1.25f;
            speed = 5f;
        }

        // Simpan skala awal
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Hitung skala baru dengan fungsi sinus
        float scale = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f; // Rentang 0 ke 1
        float newScale = Mathf.Lerp(1f, scaleMultiplier, scale); // Interpolasi antara skala awal dan skala maks
        transform.localScale = originalScale * newScale; // Terapkan skala baru
    }
}
