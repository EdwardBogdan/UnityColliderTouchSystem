using UnityEngine;
using ColliderTouchSystem.Abstract;

namespace ColliderTouchSystem.Collision
{
    public class ColisionStayComponent : ColiderFilter
    {
        void OnCollisionStay2D(Collision2D collision)
        {
            Filter(collision.gameObject);
        }
    }
}
