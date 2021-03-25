using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Game.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallView : MonoBehaviour
{
    public SpriteRenderer ballImage;
    public SpriteRenderer resourceIcon;

    public CircleCollider2D collider;
    public Rigidbody2D rigidbody;

    public BallConfig ballConfig { get; private set; }
    public ResourceConfig resourceConfig { get; private set; }

    public event Action<BallView> onMouseDown = null; 

    public void Init(BallConfig ballConfig, ResourceConfig resourceConfig = null)
    {
        this.ballConfig = ballConfig;
        this.resourceConfig = resourceConfig;

        ballImage.sprite = Resources.Load<Sprite>(ballConfig.icon);

        if(resourceConfig != null)
        {
            resourceIcon.sprite = Resources.Load<Sprite>(resourceConfig.icon);
        }
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
