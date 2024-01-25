using UnityEngine;
using ColliderTouchSystem.Abstract;

namespace ColliderTouchSystem.Trigger
{
    public class TriggerStayComponent : ColiderFilter
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            Filter(other.gameObject);
        }
    }
}
