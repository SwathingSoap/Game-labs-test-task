using UnityEngine;

namespace Metro.View
{
    public class StationView: MonoBehaviour
    {
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private TextMesh text;
        
        private void Awake()
        {
            renderer = GetComponent<MeshRenderer>();
            text = GetComponentInChildren<TextMesh>();
        }

        public void SetColor(Color col)
        {
            if(renderer != null)
                renderer.material.color = col;
            if (text != null)
                text.color = col;
        }

        public void SetName(string name)
        {
            if(text != null)
                text.text = name;
        }
    }
}