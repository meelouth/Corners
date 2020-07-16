using Core;
using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(Collider))]
    public class Cell : MonoBehaviour
    {
        public Figure figure;
        
        private Transform _transform;
        public Vector2Int Position => new Vector2Int((int) _transform.position.x, (int) _transform.position.z);

        private Color32 _color;

        private void Awake()
        {
            _transform = transform;
        }
        
        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        public bool IsBusy => figure != null;

        public Color32 Color
        {
            get => GetComponent<MeshRenderer>().material.color;
            set => GetComponent<MeshRenderer>().material.color = value;
        }

        public void Highlight(Color32 highlightColor)
        {
            _color = Color;
            Color = highlightColor;
        }

        public void Unhighlight()
        {
            Color = _color;
        }
    }
}
