using UnityEngine;

public static class MapGenerator
{
    public static GameObject Generate(
        int gridCount,
        float magnitude,
        float maxSample,
        Material material
    )
    {
        GameObject mapInstance = new GameObject();

        MeshRenderer meshRenderer = mapInstance.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = material;

        MeshFilter meshFilter = mapInstance.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[gridCount * gridCount];
        for(int i=0; i<gridCount; i++)
        {
            for(int j=0; j<gridCount; j++)
            {
                vertices[i*gridCount + j] = new Vector3(i, magnitude*Mathf.PerlinNoise((float)i/gridCount/maxSample, (float)j/gridCount/maxSample), j);
            }
        }
        mesh.vertices = vertices;

        int[] tris = new int[(gridCount - 1)*(gridCount - 1)*2*3];
        for(int i=0; i<gridCount-1; i++)
        {
            for(int j=0; j<gridCount-1; j++)
            {
                tris[(i*(gridCount - 1)*6) + j*6] = i*gridCount + j;
                tris[(i*(gridCount - 1)*6) + j*6 + 1] = i*gridCount + j + 1;
                tris[(i*(gridCount - 1)*6) + j*6 + 2] = (i + 1)*gridCount + j;
                tris[(i*(gridCount - 1)*6) + j*6 + 3] = (i + 1)*gridCount + j;
                tris[(i*(gridCount - 1)*6) + j*6 + 4] = i*gridCount + j + 1;
                tris[(i*(gridCount - 1)*6) + j*6 + 5] = (i + 1)*gridCount + j + 1;
            }
        }
        
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        return mapInstance;
    }
}