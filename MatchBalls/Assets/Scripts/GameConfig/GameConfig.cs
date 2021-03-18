using System.Collections.Generic;

namespace Game.Configs
{
    public class GameConfig
    {
        public static Dictionary<BallType, BallConfig> ballConfigs;

        public static void Init()
        {
            LoadBalls();
        }

        private static void LoadBalls()
        {
            ballConfigs = new Dictionary<BallType, BallConfig>();
            //Loading from json or xml or somewhere else
            //...
        }
    }
}