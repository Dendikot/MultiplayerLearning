using Colyseus;

public class MultiplayerManager : ColyseusManager<MultiplayerManager>
{
    void Start()
    {
        Instance.InitializeClient();
        Instance.client.JoinOrCreate<State>("state_handler");
    }

}
