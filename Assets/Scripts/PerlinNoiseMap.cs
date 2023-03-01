using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseMap : MonoBehaviour
{
    [SerializeField]
    private int gridCount;

    [SerializeField]
    private float magnitude;

    [SerializeField]
    private float maxSample;

    private Material standardMaterial;
    private GameObject currentMap;

    public void Generate()
    {
        if(this.currentMap != null)
        {
            Destroy(this.currentMap);
        }
        this.currentMap = MapGenerator.Generate(
            this.gridCount,
            this.magnitude,
            this.maxSample,
            this.standardMaterial
        );
    }

    void Awake()
    {
        this.standardMaterial = new Material(Shader.Find("Standard"));
    }

    void Start()
    {
        this.Generate();
    }
}
