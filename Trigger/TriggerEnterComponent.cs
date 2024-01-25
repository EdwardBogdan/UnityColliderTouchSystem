using UnityEngine;
using ColliderTouchSystem.Abstract;

namespace ColliderTouchSystem.Trigger
{
    public class TriggerEnterComponent : ColiderFilter
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Filter(other.gameObject);
        }
    }
}
