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
                    ballView.onMouseDown += OnBallClicked;
                }
            }
        }
    }

    private async Task DestroyBall(BallView ballView)
    {
        await ballView.Explode();
        ballView.onMouseDown -= OnBallClicked;
        ballViews.Remove(ballView);
        ballView.Dispose();
    }

    private void OnBallClicked(BallView ballView)
    {
        var linkedBalls = new List<BallView>();
        GetLinkedBalls(ballView, ref linkedBalls);
        if (linkedBalls.Count >= 3)
        {
            linkedBalls.ForEach(n => DestroyBall(n));
        }
        else
        {
            ballView.Decoy();
        }
    }

    private void GetLinkedBalls(BallView ballView, ref List<BallView> linkedBalls)
    {
        var allNearbyBalls = ballView.GetCollideWith();
        var matchBalls = allNearbyBalls.FindAll(n => n.ballType == ballView.ballType);

        if(matchBalls.Count > 0)
        {
            //Remove already listed balls
            for(int i = 0; i < linkedBalls.Count; i++)
            {
                if(matchBalls.Contains(linkedBalls[i]))
                {
                    matchBalls.Remove(linkedBalls[i]);
                }
            }

            //Add new matched balls
            linkedBalls.AddRange(matchBalls);

            //Run recursive search of others balls
            for(int i = 0; i < matchBalls.Count; i++)
            {
                GetLinkedBalls(matchBalls[i], ref linkedBalls);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
