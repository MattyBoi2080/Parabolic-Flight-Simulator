using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalGravityChanger3D : MonoBehaviour
{
  
  private float nextLogTime;
  static float t = 0f;
  public float TransitionDuration;
  public float ComponentDuration;
  float TransitionTime = 0f;
  public float regularGravity;
  public float hyperGravity;
  public float microGravity;
  public float restPeriod;
  public TextMeshPro Indicator;
  private float CurrentAngle;
  private float CurrentMagnitude;
  Vector3 newGravity;

  // Start is called before the first frame update
  void Start()
  {
    
    StartCoroutine(GravityLoop());
    nextLogTime = Time.time + 1.0f;
    newGravity = new Vector3(0, regularGravity, 0);

  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time >= nextLogTime)
    {
      Debug.Log(newGravity.magnitude.ToString());
      nextLogTime = Time.time + 1.0f;
      
    }

    Indicator.text = newGravity.magnitude.ToString("F2");
    Physics.gravity = newGravity;
  }

  IEnumerator GravityLoop()
  {
    while (true)
    {
      CurrentMagnitude = regularGravity;
      CurrentAngle = 0f;
      yield return new WaitForSeconds(ComponentDuration);
      TransitionTime = 0f;
      while (newGravity.magnitude * -1f > hyperGravity)
      {
        TransitionTime += Time.deltaTime;
        t = TransitionTime / TransitionDuration;
        CurrentMagnitude = Mathf.Lerp(regularGravity, hyperGravity, t);
        CurrentAngle = Mathf.Lerp(0f, -0.524f, t);
        newGravity[1] = Mathf.Cos(CurrentAngle) * CurrentMagnitude;
        newGravity[2] = Mathf.Sin(CurrentAngle) * CurrentMagnitude;
        yield return null;
      }
      yield return new WaitForSeconds(ComponentDuration);
      TransitionTime = 0f;
      while (newGravity.magnitude * -1f < microGravity)
      {
        TransitionTime += Time.deltaTime;
        t = TransitionTime / TransitionDuration;
        CurrentMagnitude = Mathf.Lerp(hyperGravity, microGravity, t);
        CurrentAngle = Mathf.Lerp(-0.524f, 0f, t);
        newGravity[1] = Mathf.Cos(CurrentAngle) * CurrentMagnitude;
        newGravity[2] = Mathf.Sin(CurrentAngle) * CurrentMagnitude;
        yield return null;
      }
      yield return new WaitForSeconds(ComponentDuration);
      TransitionTime = 0f;
      while (newGravity.magnitude * -1f > hyperGravity)
      {
        TransitionTime += Time.deltaTime;
        t = TransitionTime / TransitionDuration;
        CurrentMagnitude = Mathf.Lerp(microGravity, hyperGravity, t);
        CurrentAngle = Mathf.Lerp(0f, 0.524f, t);
        newGravity[1] = Mathf.Cos(CurrentAngle) * CurrentMagnitude;
        newGravity[2] = Mathf.Sin(CurrentAngle) * CurrentMagnitude;
        yield return null;
      }
      yield return new WaitForSeconds(ComponentDuration);
      TransitionTime = 0f;
      while (newGravity.magnitude * -1f < regularGravity)
      {
        TransitionTime += Time.deltaTime;
        t = TransitionTime / TransitionDuration;
        CurrentMagnitude = Mathf.Lerp(hyperGravity, regularGravity, t);
        CurrentAngle = Mathf.Lerp(0.524f, 0f, t);
        newGravity[1] = Mathf.Cos(CurrentAngle) * CurrentMagnitude;
        newGravity[2] = Mathf.Sin(CurrentAngle) * CurrentMagnitude;
        yield return null;
      }
      yield return new WaitForSeconds(restPeriod - ComponentDuration);
    }
  }

}
