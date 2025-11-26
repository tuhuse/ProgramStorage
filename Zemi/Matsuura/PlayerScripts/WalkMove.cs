using UnityEngine;
/// <summary>
/// —¤’n‚Ìê‡‚ÌˆÚ“®
/// </summary>
public class WalkMove : IMoveStrategy
{
    public void Move(float input, Rigidbody2D rb)
    {
        float direction = input;
        rb.velocity = new Vector2(input, rb.velocity.y);
    }
}
