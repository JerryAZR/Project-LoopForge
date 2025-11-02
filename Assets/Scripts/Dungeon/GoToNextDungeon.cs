using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Unity.VisualScripting;

public class GoToNextDungeon : FinishLevel
{
    [MMInspectorGroup("Next Dungeon Level", true, 30)]

    [SerializeField]
    private bool _autoIndex;
    [SerializeField]
    private bool _registerEntryPoint;

    [SerializeField][MMCondition("_autoIndex", true, true)]
    private DungeonLevelID _nextLevel;
    public override void GoToNextLevel()
    {
        // Set the next level
        DungeonMetadata.Level = _autoIndex ?
            DungeonMetadata.GetFor(this).Current.NextLevel : _nextLevel;
        base.GoToNextLevel();
    }

    protected void Start()
    {
        // Register as an entry point with the LevelManager
        if (_registerEntryPoint && LevelManager.HasInstance)
        {
            LevelManager.Instance.PointsOfEntry.Insert(0,
                new PointOfEntry
                {
                    Name = "DungeonExit",
                    Position = transform,
                    EntryFeedback = null
                });
            Debug.Log($"[Frame:{Time.frameCount}] " +
                $"Registered {transform.position} as Point #0 of Entry.");
        }
    }

}
