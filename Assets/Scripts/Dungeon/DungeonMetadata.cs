using System;
using System.Collections.Generic;
using Edgar.Unity;
using MoreMountains.Tools;
using UnityEngine;

public class DungeonMetadata : MMSceneSingleton<DungeonMetadata>
{
    [SerializeField] private PlatformerGeneratorGrid2D _generator;
    public static DungeonLevelID Level = new();
    public DungeonLevelID Current
    {
        get => _currentLevel;
        private set => _currentLevel = value;
    }
    [MMReadOnly][SerializeField] private DungeonLevelID _currentLevel;

    [SerializeField] private List<FixedLevelGraphConfigGrid2D> _levelGraphs;

    // TEMP: Initial seed should probably come from a save file.
    private static int _seed = 0;
    void Start()
    {
        if (_generator)
        {
            // Set the seed for level generation
            _generator.RandomGeneratorSeed = _seed + Level.Index;
            // Set the level graph for generation, if applicable
            if (Level.Index >= 0 && Level.Index < _levelGraphs.Count)
            {
                _generator.FixedLevelGraphConfig = _levelGraphs[Level.Index];
            }
            else
            {
                Debug.LogError($"DungeonMetadata: Level index {Level.Index} is out of range.");
            }
        }
        _currentLevel = Level;


    }

    /// <summary>
    /// Re-generate a seed for level generation
    /// </summary>
    public void ReSeed()
    {
        _seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
    }
}

[Serializable]
public struct DungeonLevelID
{
    public int Index;

    public DungeonLevelID NextLevel => new() { Index = Index + 1 };
    public DungeonLevelID PrevLevel => new() { Index = Index - 1 };
}
