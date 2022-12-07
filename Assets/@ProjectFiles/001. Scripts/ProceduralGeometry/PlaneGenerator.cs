using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProceduralGeometry
{

    
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class PlaneGenerator : MonoBehaviour
    {
        public event Action<Vector3> OnNewPlaneGenerated = delegate {  };
        [HideInInspector] public bool CpuWave = false;
        
        [SerializeField] private int x;
        [SerializeField] private int y;
        [SerializeField] private int resolution;
        [SerializeField] private bool regenerateOnChange = false;
        [Space] 
        [SerializeField] private Material shaderMaterial;
        [Space] 
        private float cpuWaveSpeed = 5f;
        private float cpuWaveIntensity = 0.1f;
        private float cpuTextureMoveIntensity = 1f;

        private Mesh _mesh;
        private MeshFilter _filter;
        private MeshRenderer _renderer;

        private List<Vector3> vertices;
        private List<int> triangles;
        private List<Vector2> uv;

        private float time;
        
        private readonly int shaderWaveParameter = Shader.PropertyToID("_ShaderWave");


        private void OnValidate()
        {
            if (resolution <= 0) resolution = 1;
            if (x <= 0) x = 1;
            if (y <= 0) y = 1;
            
            if (regenerateOnChange)
            {
                _filter = GetComponent<MeshFilter>();
                if (_filter == null) _filter = gameObject.AddComponent<MeshFilter>();
                
                _renderer = GetComponent<MeshRenderer>();
                if (_renderer == null) _renderer = gameObject.AddComponent<MeshRenderer>();
                GeneratePlane();
            }
        }

        private void Start()
        {
            _filter = GetComponent<MeshFilter>();
            _renderer = GetComponent<MeshRenderer>();
            if (_filter == null) _filter = gameObject.AddComponent<MeshFilter>();
            if (_renderer == null) _renderer = gameObject.AddComponent<MeshRenderer>();
            
            GeneratePlane();
        }

        private void Update()
        {
            if(!CpuWave) return;
            
            Vector3[] newVertices = new Vector3[vertices.Count];
            vertices.CopyTo(newVertices);
            
            for (var i = 0; i < newVertices.Length; i++)
            {
                newVertices[i].z = vertices[i].z + Mathf.Sin(time + vertices[i].x) * cpuWaveIntensity;
            }

            Vector2[] newUVs = new Vector2[uv.Count];
            uv.CopyTo(newUVs);
            
            for (var i = 0; i < newUVs.Length; i++)
            {
                newUVs[i].x += Time.deltaTime * cpuTextureMoveIntensity;
            }

            uv = newUVs.ToList();
            

            _mesh.vertices = newVertices;
            _mesh.uv = newUVs;
            _mesh.RecalculateNormals();

            time += Time.deltaTime * cpuWaveSpeed;
        }

        public void GeneratePlane()
        {

            vertices = new List<Vector3>();
            uv = new List<Vector2>();
            float xStep = x / resolution;
            float yStep = y / resolution;

            for (int y = 0; y < resolution+1; y++)
            for (int x = 0; x < resolution + 1; x++)
            {
                vertices.Add(new Vector3(x * xStep, 0, y * yStep));
                uv.Add(new Vector2(x, y));
            }

            triangles = new List<int>();
            for (int row = 0; row < resolution; row++)
            {
                for (int collumn = 0; collumn < resolution; collumn++)
                {
                    int i = (row*resolution) + row + collumn;
                    triangles.Add(i);
                    triangles.Add(i + (resolution) + 1);
                    triangles.Add(i + (resolution) + 2);
                    
                    triangles.Add(i);
                    triangles.Add(i + resolution + 2);
                    triangles.Add(i + 1);
                }
            }
            
          
            
            _mesh = new Mesh
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray(),
                uv = uv.ToArray()
            };
            
            _mesh.name = "Generated Plane";
            _mesh.RecalculateNormals();
            _filter.mesh = _mesh;

            _renderer.materials = new[] {shaderMaterial};
            OnNewPlaneGenerated?.Invoke(_mesh.bounds.size);
        }

        public void SetCPU(bool value = true)
        {
            CpuWave = value;
            shaderMaterial.SetFloat(shaderWaveParameter,value? 0:1);
            
        }

    

        private void OnDrawGizmos()
        {
            if (vertices != null)
            {
                foreach (var ver in vertices)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawSphere(ver,0.3f);
                }
            }
        }
    }
}
    

