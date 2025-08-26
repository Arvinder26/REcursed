using UnityEngine;

public class PlayerModel
{
    private PlayerData data;

    /*
    public void applyInput(PlayerCommand cmd)
    {
        //TODO: implement apply player inputs
    }
    remove comment block when player command is implemented
    */

    public void update(float dt)
    {
        //TODO: implement player update
    }

    public void onAnomalyResolved(bool ok)
    {
        //TODO: implement anomaly resolution
    }

    public PlayerData getData()
    {
        return data;
    }
}
