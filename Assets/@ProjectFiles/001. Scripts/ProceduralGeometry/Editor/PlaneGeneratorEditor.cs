using UnityEditor;
using UnityEngine;

namespace ProceduralGeometry.Editor
{
    [CustomEditor(typeof(PlaneGenerator))]
    public class PlaneGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            var plane = target as PlaneGenerator;
            if (plane != null)
            {
                if (GUILayout.Button("Generate Plane With New Parameters"))
                {
                    plane.GeneratePlane();
                }

                if (GUILayout.Button("Cpu Wave + Horizontal Tex Move"))
                {
                    plane.SetCPU();
                }

                if (GUILayout.Button("Gpu Wave + Horizontal Tex Move"))
                {
                    plane.SetCPU(false);
                }
            }
        }
    }
}
