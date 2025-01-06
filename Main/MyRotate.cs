using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AllHallownestEnhanced
{
    public class MyRotate : MonoBehaviour
    {
        public float rotateSpeed = 10f;
        public void Update()
        {
            transform.Rotate(rotateSpeed * new Vector3(0, 0, 1) * Time.deltaTime);
        }
    }
}
