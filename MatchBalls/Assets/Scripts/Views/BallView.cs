using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public CircleCollider2D collider;
    public Rigidbody2D rigidbody;

    public BallType ballType { get; private set; }

    public event Action<BallView> onMouseDown = null; 

    public void Init(BallType ballType)
    {
        this.ballType = ballType;
    }

    public List<BallView> GetCollideWith()
    {
        var balls = new List<BallView>();
        var colliders = Physics2D.OverlapCircleAll(transform.position, collider.radius + (collider.radius / 10.0f));

        for(int i = 0; i < colliders.Length; i++)
        {
            var ball = colliders[i].GetComponent<BallView>();
            if (ball == null)
                continue;

            balls.Add(ball);
        }

        return balls;
    }

    public async Task Decoy()
    {
        var tween = transform.DOScale(1.5f, 0.1f);
        await tween.AsyncWaitForCompletion();

        tween = transform.DOScale(0.8f, 0.05f);
        await tween.AsyncWaitForCompletion();

        tween.Kill();
    }

    public async Task Explode()
    {
        var tween = transform.DOScale(2.0f, 0.05f);
        await tween.AsyncWaitForCompletion();
        tween.Kill();
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        onMouseDown?.Invoke(this);
    }
}
