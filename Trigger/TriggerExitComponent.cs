using UnityEngine;
using ColliderTouchSystem.Abstract;

namespace ColliderTouchSystem.Trigger
{
    public class TriggerExitComponent : ColiderFilter
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            Filter(other.gameObject);
        }
    }
}
