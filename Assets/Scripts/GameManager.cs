using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    //private GameState state; (remove comment when GameState is implemented)
    private int currentNight;
    private int threatLevel;

    public void startNewGame(string mapID)
    {
        //TODO: implement start of a new game
    }

    public void beginNight()
    {
        //TODO: implement beginning of nights
    }

    public void endNight()
    {
        //TODO: implement end of nights
    }

    public void raiseThreat(int points)
    {
        //TODO: implement point system of threats
    }

    public void save(int slot)
    {
        //TODO: implement save slot
    }

    public void load(int slot)
    {
        //TODO: implement load slot
    }
}
