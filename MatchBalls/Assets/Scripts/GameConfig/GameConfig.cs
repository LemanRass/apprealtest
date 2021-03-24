using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Configs
{
    public class GameConfig
    {
        public static Dictionary<BallType, BallConfig> ballConfigs;

        public static async Task Init()
        {
            LoadBalls();
        }

        private static void LoadBalls()
        {
            ballConfigs = new Dictionary<BallType, BallConfig>();
            //Loading from json or xml or somewhere else
            //...

            //TODO: Remove hardcode and load from file
            ballConfigs.Add(BallType.AQUA, new BallConfig()
            {
                ballType = BallType.AQUA,
                prefab = "Prefabs/Balls/AQUA"
            });

            ballConfigs.Add(BallType.GREEN, new BallConfig()
            {
                ballType = BallType.GREEN,
                prefab = "Prefabs/Balls/GREEN"
            });

            ballConfigs.Add(BallType.PURPLE, new BallConfig()
            {
                ballType = BallType.PURPLE,
                prefab = "Prefabs/Balls/PURPLE"
            });

            ballConfigs.Add(BallType.RED, new BallConfig()
            {
                ballType = BallType.RED,
                prefab = "Prefabs/Balls/RED"
            });

            ballConfigs.Add(BallType.YELLOW, new BallConfig()
            {
                ballType = BallType.YELLOW,
                prefab = "Prefabs/Balls/YELLOW"
            });

            Debug.Log($"[GameConfig]Loaded {ballConfigs.Count} balls.");
        }
    }
}