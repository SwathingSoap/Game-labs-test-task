using UnityEngine;

namespace Metro.View
{
    public class MetroLineView : MonoBehaviour
    {
        [SerializeField] private Color col;
        private void OnValidate()
        {
            LineRenderer r = GetComponent<LineRenderer>();
       

            r.positionCount = transform.childCount;
            r.startColor = col;
            r.endColor = col;
            r.startWidth = 0.2f;
            r.endWidth = 0.2f;

            for (int i = 0; i < transform.childCount; i++)
            {
                r.SetPosition(i,transform.GetChild(i).transform.position);
            }
        
        }
    }
}
