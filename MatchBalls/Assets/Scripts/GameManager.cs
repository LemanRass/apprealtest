using System.Threading.Tasks;
using Game.Configs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    public async Task Init()
    {
        await GameConfig.Init();
    }
}
