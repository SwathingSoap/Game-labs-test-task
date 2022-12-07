using System;
using Metro.Data;
using Metro.View;
using UnityEngine;

namespace Metro.Control
{
    /// <summary>
    /// Заранее поняв, что я буду использовать алгоритм Дийкстры, решил хранить связи между станциями
    ///     сразу в классе станции. Т.к это не какой-то огромный грид 1000x1000, а лишь несколько станций, каждая
    ///     из которых может иметь максимум 3 соседа. По этому, думаю, хранение соседей прям тут, довольно удобный
    ///     вариант. Хранить их например в словаре по названию станции в условном классе MetroStationsController только
    ///     сильнее бы нагрузило.
    ///
    /// Наследование от MonoBehaviour требуется лишь для удобного выстраивания связей через объекты в редаторе Unity 
    /// 
    /// Если потребовалось бы сохранение этих данных, я бы создал класс, ScriptableObject, хранящий все станции
    ///     который бы помимо связей, запоминал бы еще и их позиции и принадлежность к линии метро. Но принадлежность
    ///     к линии и позиция лишь для отрисовки. Но при задаче исключительно поиска пути, этого, думаю, достаточно.
    /// </summary>
    
    
    [Serializable]
    public class Station: MonoBehaviour
    {
        [SerializeField] public MetroData.Line line;
        [SerializeField] public string name;
        [SerializeField] public Station[] neighbours;

        private StationView view;
        
        private void Start()
        {
            if (view == null)
            {
                view = GetComponentInChildren<StationView>();
            }

            if (view != null)
            {
                view.SetColor(MetroData.LineColors[line]);
                view.SetName(name);
            }
        }

        public int Cost(Station s)
        {
            return s.line == line ? 100 : 0;
        }

        private void OnMouseDown()
        {
            MetroPathController.Instance.SelectStation(this);
        }

        public struct PathData
        {
            public int g,  penalty,F;
            public float h;
        }
    }
}
