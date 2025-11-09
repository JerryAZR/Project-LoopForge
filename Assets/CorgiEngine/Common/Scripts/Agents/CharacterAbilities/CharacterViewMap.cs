using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class CharacterViewMap : CharacterPause
{
    public override string HelpBoxText()
    {
        return "Allows this character to view the map when the map button is pressed.";
    }

    /// <summary>
    /// Every frame, we check the input to see if we need to view/unview the map
    /// </summary>
    protected override void HandleInput()
    {
        if (_character.CharacterType != Character.CharacterTypes.Player)
        {
            return;
        }
        if (_inputManager.MapButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
        {
            TriggerPause();
        }
    }
}
