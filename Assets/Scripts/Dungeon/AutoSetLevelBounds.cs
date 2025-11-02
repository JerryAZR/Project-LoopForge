using UnityEngine;
using UnityEngine.Tilemaps;
using Edgar.Unity;
using MoreMountains.CorgiEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A post-processing script for platformer generators to automatically set
/// level bounds on a level manager.
/// </summary>
[CreateAssetMenu(menuName = "Edgar/Custom/AutoSetLevelBounds", fileName = "AutoSetLevelBounds")]
public class AutoSetLevelBounds : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        // TEMP: LevelManager probably shouldn't be a global singleton. We will
        // likely have multiple levels loaded when we switch to multiplayer.
        if (LevelManager.Instance == null)
        {
            Debug.LogWarning("AutoSetLevelBounds: LevelManager reference not set.");
            return;
        }

        List<Tilemap> tilemaps = level.GetSharedTilemaps();
        if (tilemaps == null || tilemaps.Count == 0)
        {
            Debug.LogWarning("AutoSetLevelBounds: No tilemaps found in generated level.");
            return;
        }

        // Initialize combined bounds using the first valid tilemap
        IEnumerable<Bounds> boundsList = tilemaps.Select(t => GetCompressedBounds(t));
        Bounds combinedBounds = boundsList.Aggregate((combined, next) => CombineBounds(combined, next));

        LevelManager.Instance.SetNewLevelBounds(combinedBounds);
        Debug.Log($"AutoSetLevelBounds: Level bounds set to {combinedBounds}");
    }

    /// <summary>
    /// Gets the compressed bounds of a tilemap.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <returns>The compressed bounds of the tilemap.</returns>
    private static Bounds GetCompressedBounds(Tilemap tilemap)
    {
        tilemap.CompressBounds();
        var bounds = tilemap.localBounds;
        // localBounds is in local space; to be safe, convert to world space
        // if needed:
        bounds.center = tilemap.transform.TransformPoint(bounds.center);
        bounds.extents = Vector3.Scale(bounds.extents, tilemap.transform.lossyScale);
        return bounds;
    }

    private static Bounds CombineBounds(Bounds a, Bounds b)
    {
        a.Encapsulate(b);
        return a;
    }
}
