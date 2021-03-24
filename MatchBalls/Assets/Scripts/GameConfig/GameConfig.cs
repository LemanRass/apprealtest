using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Configs
{
    public class GameConfig
    {
        public static List<ResourceConfig> resourcesConfig;
        public static List<BallConfig> ballsConfigs;

        public static async Task Init()
        {
            await LoadResources();
            await LoadBalls();

        }

        private static async Task LoadResources()
        {
            resourcesConfig = new List<ResourceConfig>();
            //Loading from json or xml or somewhere else
            //...

            //TODO: Remove hardcode and load from file
            resourcesConfig.Add(new ResourceConfig()
            {
                id = 0,
                name = "Wood",
                icon = "Images/Resources/0",
            });

            resourcesConfig.Add(new ResourceConfig()
            {
                id = 1,
                name = "Stone",
                icon = "Images/Resources/1",
            });

            resourcesConfig.Add(new ResourceConfig()
            {
                id = 2,
                name = "Water",
                icon = "Images/Resources/2",
            });
        }

        private static async Task LoadBalls()
        {
            ballsConfigs = new List<BallConfig>();
            //Loading from json or xml or somewhere else
            //...

            //TODO: Remove hardcode and load from file
            ballsConfigs.Add(new BallConfig()
            {
                id = 0,
                icon = "Images/Balls/0",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 1,
                icon = "Images/Balls/1",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 2,
                icon = "Images/Balls/2",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 3,
                icon = "Images/Balls/3",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 4,
                icon = "Images/Balls/4",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 5,
                icon = "Images/Balls/5",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 6,
                icon = "Images/Balls/6",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 7,
                icon = "Images/Balls/7",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 8,
                icon = "Images/Balls/8",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 9,
                icon = "Images/Balls/9",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 10,
                icon = "Images/Balls/10",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 11,
                icon = "Images/Balls/11",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 12,
                icon = "Images/Balls/12",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 13,
                icon = "Images/Balls/13",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            ballsConfigs.Add(new BallConfig()
            {
                id = 14,
                icon = "Images/Balls/14",
                prefab = "Prefabs/Balls/BallPrefab"
            });

            Debug.Log($"[GameConfig]Loaded {ballsConfigs.Count} balls.");
        }
    }
}