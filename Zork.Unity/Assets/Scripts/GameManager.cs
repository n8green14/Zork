using UnityEngine;
using Zork;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>("Zork");

        Game.Start(gameJsonAsset.text, InputService, OutputService);
        Game.Instance.Commands.PerformCommand(Game.Instance, "LOOK");
    }

    void Start()
    {
        
    }

    
    void Update()
    {

    }

    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private UnityInputService InputService;
}
