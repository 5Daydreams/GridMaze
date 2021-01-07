using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
   private Vector3 startPos;

   private void Awake()
   {
      startPos = transform.localPosition;
   }

   public IEnumerator Shake3D(float duration, float intensity)
   {
      float elapsedTime = 0.0f;

      while (elapsedTime < duration)
      {
         float x = Random.Range(-1.0f, 1.0f) * intensity;
         float y = Random.Range(-1.0f, 1.0f) * intensity;
         float z = Random.Range(-1.0f, 1.0f) * intensity;
         
         transform.localPosition = new Vector3(startPos.x+x,startPos.y+y,startPos.z+z);

         elapsedTime += Time.deltaTime;
         
         yield return null;
      }
      transform.localPosition = startPos;
   }

   public IEnumerator ShakeZ(float duration, float intensity)
   {
      float elapsedTime = 0.0f;

      while (elapsedTime < duration)
      {
         float z = Random.Range(-1.0f, 1.0f) * intensity;
         
         transform.localPosition = new Vector3(startPos.x,startPos.y,startPos.z+z);

         elapsedTime += Time.deltaTime;
         
         yield return null;
      }
      transform.localPosition = startPos;
   }
}
