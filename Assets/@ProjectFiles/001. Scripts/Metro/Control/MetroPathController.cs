using UnityEngine;

namespace Metro.Control
{
    public class MetroPathController : MonoBehaviour
    {
        [SerializeField] private LineRenderer renderer;
        [SerializeField] private TextMesh infoText;
        [SerializeField] private TextMesh connectionsText;
        
        private static MetroPathController _instance;
        public static MetroPathController Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<MetroPathController>();
                return _instance;
            }
        }
        
        private Station start;
        private Station end;
        private int state;
        
        public void SelectStation(Station station)
        {
            if (state == 0)
                start = station;
            else
            {
                end = station;
                if (start != end)
                    FindPath();
            }
            
            state = (state - 1).Abs();
            string substring = state == 0? "отправления":"назначения";
            ;
            infoText.text = $"Кликом по квадратику выберите станцию {substring}";
        }
        
        void FindPath()
        {
            var path = MetroPathfinder.Dijkstra(start,end);
            if (path != null)
            {
                renderer.positionCount = path.stations.Count;
                for (var i = 0; i < path.stations.Count; i++) renderer.SetPosition(i, path.stations[i].transform.position);
            }

            connectionsText.text = $"Количество пересадок => {path.connections}";

        }
        
        
        

    }
}
