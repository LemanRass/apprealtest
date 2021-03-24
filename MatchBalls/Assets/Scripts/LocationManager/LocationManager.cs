using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Configs;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public Transform ballsSpawnPoint;

    private List<BallView> ballViews;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        ballViews = new List<BallView>();
        SpawnBalls(50);
    }

    private BallType CalculateNextBall()
    {
        int num = Random.Range(0, GameConfig.ballConfigs.Count);
        return (BallType)num;
    }

    private async Task SpawnBalls(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var ballType = CalculateNextBall();
            SpawnBall(ballType);
            await Task.Delay(100);
        }
    }

    private void SpawnBall(BallType ballType)
    {
        if (GameConfig.ballConfigs.ContainsKey(ballType))
        {
            var ballConfig = GameConfig.ballConfigs[ballType];
            var prefab = Resources.Load<GameObject>(ballConfig.prefab);

            if (prefab != null)
            {
                var ball = GameObject.Instantiate(prefab, transform);
                ball.transform.position = ballsSpawnPoint.position;

                var ballView = ball.GetComponent<BallView>();

                if (ballView != null)
                {
                    ballView.Init(ballType);
                    ballViews.Add(ballView);
                    ballView.rigidbody.AddRelativeForce(ballsSpawnPoint.transform.up * 20.0f, ForceMode2D.Impulse);
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            var ballType = CalculateNextBall();
            SpawnBall(ballType);
        }
    }
}
