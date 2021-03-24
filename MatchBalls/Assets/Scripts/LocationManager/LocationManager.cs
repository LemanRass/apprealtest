using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Configs;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public Transform ballsSpawnPoint;

    private List<BallView> ballViews;

    #region Balance settings
    //Between 0 and 100
    public int resourceChance = 50;

    //How many types of balls will be taken from config
    public int ballsTypeLimit = 5;

    //How many balls will exists on game field
    public int ballsCountLimit = 50;

    //How many additional balls will be spawned (excluded ballsCountLimit)
    public int ballsSpawnCountLimit = 20;



    #endregion


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        ballViews = new List<BallView>();
        SpawnBalls(ballsCountLimit);
    }

    private BallConfig CalculateNextBall()
    {
        return GameConfig.ballsConfigs[Random.Range(0, ballsTypeLimit)];
    }

    private async Task SpawnBalls(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var ball = CalculateNextBall();
            SpawnBall(ball);
            await Task.Delay(100);
        }
    }

    private ResourceConfig CalculateNextResource()
    {
        //Chance for resource
        int chance = Random.Range(0, 100);

        //If chance met
        if (chance > resourceChance)
            return null;

        //Calculate random resource
        return GameConfig.resourcesConfig[Random.Range(0, GameConfig.resourcesConfig.Count)];
    }

    private void SpawnBall(BallConfig ballConfig)
    {
        var prefab = Resources.Load<GameObject>(ballConfig.prefab);

        if (prefab != null)
        {
            var ball = GameObject.Instantiate(prefab, transform);
            ball.transform.position = ballsSpawnPoint.position;

            var ballView = ball.GetComponent<BallView>();

            if (ballView != null)
            {
                var resource = CalculateNextResource();
                ballView.Init(ballConfig, resource);
                ballViews.Add(ballView);
                ballView.rigidbody.AddRelativeForce(ballsSpawnPoint.transform.up * 20.0f, ForceMode2D.Impulse);
                ballView.onMouseDown += OnBallClicked;
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
        var matchBalls = allNearbyBalls.FindAll(n => n.ballConfig.id == ballView.ballConfig.id);

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
