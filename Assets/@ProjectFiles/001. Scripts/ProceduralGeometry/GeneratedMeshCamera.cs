using UnityEngine;

namespace ProceduralGeometry
{
   public class GeneratedMeshCamera : MonoBehaviour
   {
      [SerializeField] private PlaneGenerator planeGenerator;
      [SerializeField] private Camera cam;

      private void Awake()
      {
         if (cam == null) cam = GetComponent<Camera>();
         if (planeGenerator != null) planeGenerator.OnNewPlaneGenerated += PlaceCamera;
         
      }

      private void PlaceCamera(Vector3 planeSize)
      {
         float distance = Mathf.Max(planeSize.x,planeSize.y, planeSize.z);
         distance /= (3.0f * Mathf.Tan(0.5f * cam.fieldOfView * Mathf.Deg2Rad));
         transform.position = new Vector3(planeSize.x/2, distance * 2.0f,planeSize.z/2);
       
      }
   }
}
