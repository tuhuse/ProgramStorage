using UnityEngine;
/// <summary>
/// ‹ó‚Ìê‡‚ÌˆÚ“®
/// </summary>
public class HoverMove : IMoveStrategy
{
    public void Move(float input, Rigidbody2D rb)
    {
        float direction = input;
        rb.velocity=new Vector2(input,rb.velocity.y);
    }
    

    
}
