using UnityEngine;
using System.Collections;

// Vector3.MoveTowards example.

// A cube can be moved around the world. It is kept inside a 1 unit by 1 unit
// xz space. A small, long cylinder is created and positioned away from the center of
// the 1x1 unit. The cylinder is moved between two locations. Each time the cylinder is
// positioned the cube moves towards it. When the cube reaches the cylinder the cylinder
// is re-positioned to the other location. The cube then changes direction and moves
// towards the cylinder again.
//
// A floor object is created for you.
//
// To view this example, create a new 3d Project and create a Cube placed at
// the origin. Create Example.cs and change the script code to that shown below.
// Save the script and add to the Cube.
//
// Now run the example.

using UnityEngine;

public class RotateAroundExample : MonoBehaviour
{
    public GameObject objectA; // 球 A
    public GameObject objectB; // 空对象 B
    public float speed = 2f; // 旋转速度
    public Vector3 axis = Vector3.up; // 旋转轴

    void Update()
    {
        Quaternion rotation = Quaternion.AngleAxis(speed * Time.deltaTime, axis);
        Vector3 direction = objectA.transform.position - objectB.transform.position;
        Vector3 rotatedDirection = rotation * direction;

        objectA.transform.position = objectB.transform.position + rotatedDirection;
    }
}