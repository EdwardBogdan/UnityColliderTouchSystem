using UnityEngine;
using ColliderTouchSystem.Abstract;

namespace ColliderTouchSystem.Collision
{
    public class ColisionEnterComponent : ColiderFilter
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            Filter(collision.gameObject);
        }
    }
}
