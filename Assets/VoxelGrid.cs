using System;
using UnityEngine;

[SelectionBase]
public class VoxelGrid : MonoBehaviour{
    private int resolution;

    private bool[] voxels;

    public GameObject voxelPrefab;

    private float voxelSize;

    private Material[] materials;

    public void Initialize(int resolution, float size){
        this.resolution = resolution;
        voxelSize = size / resolution;
        voxels = new bool[resolution * resolution];
        materials = new Material[voxels.Length];

        for (int i = 0, y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++, i++)
            {
                CreateVoxel(i, x, y);
            }
        }

        SetVoxelColours();
    }

    private void CreateVoxel(int i, int x, int y) {
        GameObject newObj = Instantiate(voxelPrefab);
        newObj.transform.SetParent(this.transform);
        newObj.transform.position = new Vector3(x * voxelSize, y * voxelSize);

        newObj.transform.localScale = Vector3.one * voxelSize * 0.9f;
        materials[i] = newObj.GetComponent<MeshRenderer>().material;
    }

    public void Apply(int x, int y, VoxelBrush brush) {
        voxels[y * resolution + x] = brush.Apply(x, y);
        SetVoxelColours();
    }

    private void SetVoxelColours() {
        for (int i = 0; i < voxels.Length; i++){
            materials[i].color = voxels[i] ? Color.white : Color.green;
        }
    }
}