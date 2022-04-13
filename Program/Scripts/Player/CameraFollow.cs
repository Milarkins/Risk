 using UnityEngine;
 
 public class CameraFollow : MonoBehaviour
 {
     public Transform playerTransform;
     public float smoothSpeed;
     public int depth = -20;
 
     // Update is called once per frame
     void FixedUpdate()
     {
         if(playerTransform != null)
         {
             Vector3 dP = playerTransform.position + new Vector3(0,0,depth);
             Vector3 sP = Vector3.Lerp(transform.position, dP, smoothSpeed);
             transform.position = sP;
         }
     }
 
     public void setTarget(Transform target)
     {
         playerTransform = target;
     }
 }
