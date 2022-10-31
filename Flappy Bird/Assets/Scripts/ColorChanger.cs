using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color endColor;
    [SerializeField] private float fadeDuration = 1;
    private float fadeTimer;
    private List<ColorChangeable> colorChangeables = new List<ColorChangeable>();
    private bool shouldFade = false;

    public void StartColorFade()
    {
        shouldFade = true;
    }

    public void AddColorChangeable(MeshRenderer meshRenderer)
    {
        ColorChangeable colorChangeable = new ColorChangeable();
        colorChangeable.material = meshRenderer.material;
        colorChangeable.startColor = meshRenderer.material.GetColor("_EmissionColor");

        colorChangeables.Add(colorChangeable);
    }
 
    private void FindChangeablesInChildren()
    {
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            AddColorChangeable(meshRenderer);
        }
    }

    private void SetEmissionColor(Material material, Color color)
    {
        material.SetColor("_EmissionColor", color);
    }

    private void ResetAll()
    {
        foreach (ColorChangeable colorChangeable in colorChangeables)
        {
            SetEmissionColor(colorChangeable.material, colorChangeable.startColor);
        }
    }

    private void LerpAllColors()
    {
        fadeTimer += Time.deltaTime;
        foreach (ColorChangeable colorChangeable in colorChangeables)
        {
            SetEmissionColor(colorChangeable.material, Color.Lerp(colorChangeable.startColor, endColor, fadeTimer / fadeDuration));
        }
    }

    private void Awake()
    {
        FindChangeablesInChildren();
        ResetAll();
    }

    // Update is called once per frame
    private void Update()
    {
        if(shouldFade) LerpAllColors();
    }
}

public struct ColorChangeable
{
    public Material material;
    public Color startColor;
}
