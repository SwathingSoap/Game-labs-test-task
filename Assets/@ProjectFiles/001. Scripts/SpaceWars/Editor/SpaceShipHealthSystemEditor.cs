using SpaceWars.Ship;
using UnityEditor;
using UnityEngine;

namespace SpaceWars.Editor
{
    [CustomEditor(typeof(SpaceShipHealthSystem))]
    public class SpaceShipHealthSystemEditor: UnityEditor.Editor
    {
        private int hdmg = 0;
        public override void OnInspectorGUI()
        {
            
            base.DrawDefaultInspector();

            EditorGUILayout.BeginHorizontal();
            hdmg = EditorGUILayout.IntField(hdmg);
            if (GUILayout.Button("Remove HP")) 
                (target as SpaceShipHealthSystem).RemoveHP(hdmg);
            EditorGUILayout.EndHorizontal();
            
        }
    }
    
}