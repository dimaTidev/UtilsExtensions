using UnityEngine;
using System.Collections;

public static class Extensions_Quaternion
{
    ///Code source - https://pastebin.com/GtFaXdSy
    public static Quaternion ClampRotationXY(this Quaternion faceToTarget, Quaternion originRotation, float xMin, float xMax, float yMin, float yMax)
    {
        Vector3 dirToTarget = faceToTarget * Vector3.forward;
        // Vector3 dirToTarget = (lookTarget.position - transform.position);

        Vector3 originalForward = originRotation * Vector3.forward;

        Vector3 yAxis = Vector3.up; // world y axis
        Vector3 dirXZ = Vector3.ProjectOnPlane(dirToTarget, yAxis);
        Vector3 forwardXZ = Vector3.ProjectOnPlane(originalForward, yAxis);
        float yAngle = Vector3.Angle(dirXZ, forwardXZ) * Mathf.Sign(Vector3.Dot(yAxis, Vector3.Cross(forwardXZ, dirXZ)));
        float yClamped = Mathf.Clamp(yAngle, xMin, xMax);
        Quaternion yRotation = Quaternion.AngleAxis(yClamped, Vector3.up);

        // Debug.Log(string.Format("Desired Y rotation: {0}, clamped Y rotation: {1}", yAngle, yClamped), this);

        originalForward = yRotation * originRotation * Vector3.forward;
        Vector3 xAxis = yRotation * originRotation * Vector3.right; // our local x axis
        Vector3 dirYZ = Vector3.ProjectOnPlane(dirToTarget, xAxis);
        Vector3 forwardYZ = Vector3.ProjectOnPlane(originalForward, xAxis);
        float xAngle = Vector3.Angle(dirYZ, forwardYZ) * Mathf.Sign(Vector3.Dot(xAxis, Vector3.Cross(forwardYZ, dirYZ)));
        float xClamped = Mathf.Clamp(xAngle, -yMax, -yMin);
        Quaternion xRotation = Quaternion.AngleAxis(xClamped, Vector3.right);

        // Debug.Log(string.Format("Desired X rotation: {0}, clamped X rotation: {1}", xAngle, xClamped), this);

        return yRotation * originRotation * xRotation;

        //For Debug Limites <<---------

        // this.dirXZ = dirXZ; 
        // this.forwardXZ = forwardXZ;
        // this.dirYZ = dirYZ;
        // this.forwardYZ = forwardYZ;
    }

    public static Quaternion Delta(this Quaternion myQuat, Quaternion target) => myQuat * Quaternion.Inverse(target);
    // void OnDrawGizmos() //For Debug Limites <<---------
    // {
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawLine(transform.position, transform.position + dirXZ);
    //     Gizmos.DrawLine(transform.position, transform.position + forwardXZ);
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawLine(transform.position, transform.position + dirYZ);
    //     Gizmos.DrawLine(transform.position, transform.position + forwardYZ);
    // }
}