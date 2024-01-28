using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace ColliderTouchSystem.Touch
{
    public class ColliderTouchKeeper : MonoBehaviour
    {
        [SerializeField] UnityEvent<GameObject> _OnEnter;
        [SerializeField] UnityEvent<GameObject> _OnExit;

        public bool IsTouched { get; private set; } = false;
        public float LastTouchTime { get; private set; }

        private readonly HashSet<GameObject> CheckList = new();

        public void OnAddTouch(GameObject _object)
        {
            if (CheckList.Count <= 0)
            {
                IsTouched = enabled = true;
                _OnEnter.Invoke(_object);
            }

            CheckList.Add(_object);
        }
        public void OnRemoveTouch(GameObject _object)
        {
            CheckList.Remove(_object);

            if (CheckList.Count <= 0)
            {
                IsTouched = enabled = false;
                _OnExit.Invoke(_object);
            }
        }

        private void Awake()
        {
            if (CheckList.Count <= 0) enabled = false;
        }
        private void FixedUpdate()
        {
            LastTouchTime = Time.time;
        }
    }
}
