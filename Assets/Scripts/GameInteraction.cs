using UnityEngine;

public class GameInteraction : MonoBehaviour
{
    private InputService input;
    private PlayerModel player;
    private AnomalyModel anomaly;
    private new CameraModel camera;
    private GUIModel gui;
    private UIModel ui;

    public void initialize()
    {
        //TODO: implement game initialization
    }

    public void update(float dt)
    {
        //TODO: implement game interaction update
    }

    public void handlePrompt(AnomalyType type)
    {
        //TODO: implement prompt handler
    }

    public void switchCamera(string id)
    {
        //TODO: implement camera switching
    }
}
