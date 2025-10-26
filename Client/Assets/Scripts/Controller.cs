using UnityEngine;
using Input = UnityEngine.Input;

public class Controller : MonoBehaviour
{
    [SerializeField]
    public PlayerCharacter Player;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Player.SetInput(h, v);
    }
}
