using MoreMountains.CorgiEngine;

public class GoToPrevDungeon : GoToLevelEntryPoint
{
    public override void GoToNextLevel()
    {
        // Set the next level
        DungeonMetadata.Level = DungeonMetadata.GetFor(this).Current.PrevLevel;
        base.GoToNextLevel();
    }

}
