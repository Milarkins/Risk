 using UnityEngine;
 
 public class CameraFollow : MonoBehaviour
 {
     public Transform playerTransform;
     public float smoothSpeed;
     public float depth = -20, height = 2.5f;
 
     // Update is called once per frame
     void FixedUpdate()
     {
         if(playerTransform != null)
         {
             Vector3 dP = playerTransform.position + new Vector3(0,height,depth);
             Vector3 sP = Vector3.Lerp(transform.position, dP, smoothSpeed);
             transform.position = sP;
         }
     }
 
     public void setTarget(Transform target)
     {
         playerTransform = target;
     }
 }
