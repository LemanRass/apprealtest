using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public CircleCollider2D collider;
    public Rigidbody2D rigidbody;

    private BallType ballType;

    public void Init(BallType ballType)
    {
        this.ballType = ballType;
    }

    public List<BallView> CollideWith()
    {
        return null;
    }
}
