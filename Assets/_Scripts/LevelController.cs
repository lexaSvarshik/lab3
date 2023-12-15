using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    public static readonly int LevelCount = 10;
    private static int levelNumber;

    public static int GetLevelNumber()
    {
        return levelNumber;
    }

    public static void ChangeLevelNum(int levelNum)
    {
        LevelController.levelNumber = levelNum;
    }
}
