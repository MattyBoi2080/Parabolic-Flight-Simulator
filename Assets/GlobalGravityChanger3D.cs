using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravityChanger3D : MonoBehaviour
{
    Vector3 newGravity = new Vector3(0, -1f, 0);
    private float nextLogTime;
    static float t = 0f;
    public float TransitionDuration;
    public float ComponentDuration;
    float TransitionTime = 0f;
    public float regularGravity;
    public float hyperGravity;
    public float microGravity;
    public float restPeriod;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = newGravity;
        StartCoroutine(GravityLoop());
        nextLogTime = Time.time + 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time >= nextLogTime)
      {
        Debug.Log(newGravity[1].ToString());
        nextLogTime = Time.time + 1.0f;
      }
    
      
    }

    IEnumerator GravityLoop()
    {
    while (true)
      {
        newGravity[1] = regularGravity;
        yield return new WaitForSeconds(ComponentDuration);
        TransitionTime = 0f;
        while (newGravity[1] > hyperGravity)
        {
          TransitionTime += Time.deltaTime;
          t = TransitionTime / TransitionDuration;
          newGravity[1] = Mathf.Lerp(regularGravity, hyperGravity, t);
          yield return null;
        }
        yield return new WaitForSeconds(ComponentDuration);
        TransitionTime = 0f;
        while (newGravity[1] < microGravity)
        {
          TransitionTime += Time.deltaTime;
          t = TransitionTime / TransitionDuration;
          newGravity[1] = Mathf.Lerp(hyperGravity, microGravity, t);
          yield return null;
        }
        yield return new WaitForSeconds(ComponentDuration);
        TransitionTime = 0f;
        while (newGravity[1] > hyperGravity)
        {
          TransitionTime += Time.deltaTime;
          t = TransitionTime / TransitionDuration;
          newGravity[1] = Mathf.Lerp(microGravity, hyperGravity, t);
          yield return null;
        }
        yield return new WaitForSeconds(ComponentDuration);
        TransitionTime = 0f;
        while (newGravity[1] < regularGravity)
        {
          TransitionTime += Time.deltaTime;
          t = TransitionTime / TransitionDuration;
          newGravity[1] = Mathf.Lerp(hyperGravity, regularGravity, t);
          yield return null;
        }
        yield return new WaitForSeconds(restPeriod - ComponentDuration);
      }
    }
    
}
