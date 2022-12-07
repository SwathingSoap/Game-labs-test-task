using System.Collections.Generic;
using UnityEngine;

namespace Metro.Data
{
    public static class MetroData
    {
        public static Dictionary<Line, Color> LineColors = new Dictionary<Line, Color>()
        {
            {Line.Red,Color.red},
            {Line.Green,Color.green},
            {Line.Blue,Color.blue},
            {Line.Black,Color.black},
        };

        public enum Line
        {
            Red,
            Green,
            Blue,
            Black,
        }
    }
}