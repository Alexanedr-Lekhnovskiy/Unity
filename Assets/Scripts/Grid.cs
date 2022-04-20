using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public readonly float OffestX = 3f;
    public readonly float PositionY = 2f;
    public readonly float OffsetY = 4f;

    [SerializeField]
    private LevelData _levelData;

    public int GetColumsCount()
    {
        return _levelData.MaxPlayCards;
    }

    public float GetPositionX()
    {
        float x = 1f;
        x -= GetColumsCount() % 2;
        x -= OffestX * (GetColumsCount() / 2);
        return x;
    }
}
