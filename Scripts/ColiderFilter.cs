using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ColliderTouchSystem.Abstract
{
    public abstract class ColiderFilter : MonoBehaviour
    {
        [SerializeField] protected bool _checkByTag;
        [SerializeField] protected bool _ignoreByTag;
        [SerializeField] protected string[] _tags;
        [SerializeField] protected string[] _ignoreTags;
        [SerializeField] protected bool _checkByLayer;
        [SerializeField] protected LayerMask _layerMask;

        [SerializeField] protected UnityEvent<GameObject> _action;

        private readonly List<Func<GameObject, bool>> _filters = new List<Func<GameObject, bool>>();

        private void Awake()
        {
            if (_checkByTag)
            {
                var tagsSet = new HashSet<string>(_tags);
                _filters.Add(obj => tagsSet.Contains(obj.tag));
#if !UNITY_EDITOR
                _tags = null;
#endif
            }
            if (_ignoreByTag)
            {
                var ignoreTagsSet = new HashSet<string>(_ignoreTags);
                _filters.Add(obj => !ignoreTagsSet.Contains(obj.tag));
#if !UNITY_EDITOR
                _ignoreTags = null;
#endif
            }
            if (_checkByLayer)
            {
                _filters.Add(obj => (_layerMask.value & (1 << obj.layer)) != 0);
            }
        }

        protected void Filter(GameObject _object)
        {
            foreach (var filter in _filters)
            {
                if (!filter(_object)) return;
            }

            _action?.Invoke(_object);
        }
    }
}
