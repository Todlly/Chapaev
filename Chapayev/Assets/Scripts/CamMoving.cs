using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    public GameObject pos1, pos2;

    bool isMoving, isAtPos1;
    private void Start()
    {
        isAtPos1 = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isMoving = true;
        }
        ChangePosition();
    }
    public void ChangePosition()
    {
        GameObject position;
        if (isAtPos1)
        {
            position = pos2;
        }
        else
        {
            position = pos1;
        }

        if (isMoving)
        {
            if ((position.transform.position - this.transform.position).magnitude >= 0.01f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, position.transform.position, 14f * Time.deltaTime);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, position.transform.rotation, 4f * Time.deltaTime);
            }
            else
            {
                this.transform.position = position.transform.position;
                this.transform.rotation = position.transform.rotation;
                isAtPos1 = !isAtPos1;
                isMoving = false;
            }
        }
    }
}
