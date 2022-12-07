using System;
using System.Collections.Generic;

namespace Metro.Control
{
    public class MetroPathfinder
    {
        public static Path Dijkstra(Station start, Station goal)
        {
            Dictionary<Station, Station> NextStationToGoal = new Dictionary<Station, Station>();
            Dictionary<Station, int> costToReachStation = new Dictionary<Station, int>();

            PriorityQueue<Station> frontier = new PriorityQueue<Station>();
            frontier.Enqueue(goal, 0);
            costToReachStation[goal] = 0;
            
        
            while (frontier.Count > 0)
            {
                Station curStation = frontier.Dequeue();
                if (curStation == start)
                    break;

                foreach (Station neighbor in curStation.neighbours)
                {
                    int newCost = costToReachStation[curStation] + neighbor.Cost(curStation);
                    if (costToReachStation.ContainsKey(neighbor) == false || newCost < costToReachStation[neighbor])
                    {
                        costToReachStation[neighbor] = newCost;
                        int priority = newCost;
                        frontier.Enqueue(neighbor, priority);
                        NextStationToGoal[neighbor] = curStation;
                    }
                }
            }
            
            if (NextStationToGoal.ContainsKey(start) == false) return null;

            Path path = new Path();
            Station pathStation = start;
            path.stations.Add(start);
            while (goal != pathStation)
            {
                if (NextStationToGoal[pathStation].line != pathStation.line) path.connections++;
                
                pathStation = NextStationToGoal[pathStation];
                path.stations.Add(pathStation);
            }
            return path;
        }
    }

    public class Path
    {
        public List<Station> stations = new List<Station>();
        public int connections;
    }
    public class PriorityQueue<T>
    {
        private List<Tuple<T, int>> elements = new List<Tuple<T, int>>();
        public int Count => elements.Count;
        public void Enqueue(T item, int priority)
        {
            elements.Add(Tuple.Create(item, priority));
        }
        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Item2 < elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }
    }
}