using UnityEngine;
using ColliderTouchSystem.Abstract;

namespace ColliderTouchSystem.Collision
{
    public class ColisionExitComponent : ColiderFilter
    {
        void OnCollisionExit2D(Collision2D collision)
        {
            Filter(collision.gameObject);
        }
    }
}
