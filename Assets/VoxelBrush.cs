using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelBrush {

    private bool fillType;

    public void Initialize(bool fillType){
        this.fillType = fillType;
    }

    public bool Apply(int x, int y){
        return fillType;
    }
}