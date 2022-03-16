using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] float xDegrees = 0f;
  [SerializeField] float yDegrees = 0f;
  [SerializeField] float zDegrees = 0.5f;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(xDegrees, yDegrees, zDegrees);
  }
}
