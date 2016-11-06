using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

    public Transform[] pointList;

    private List<Vector3> m_pointPositionList = new List<Vector3>();
    private List<Quaternion> m_pointRotationList = new List<Quaternion>();

	void Start () {
        m_pointPositionList.Clear();
        m_pointRotationList.Clear();
        for (int i = 0; i < pointList.Length; ++i) {
            m_pointPositionList.Add(pointList[i].position);
            m_pointRotationList.Add(pointList[i].rotation);
        }
	}
	
	void Update () {
        DrawLine();
    }

    public Vector3 LinearPosition(int index, float ratio, bool isForward = true) {
        Vector3 pos1 = m_pointPositionList[index];
        Vector3 pos2 = (isForward) ? m_pointPositionList[index + 1] : m_pointPositionList[index - 1];
        return Vector3.Lerp(pos1, pos2, ratio);
    }

    public Quaternion Orientation(int index, float ratio, bool isForward = true) {
        Quaternion rot1 = m_pointRotationList[index];
        Quaternion rot2 = (isForward) ? m_pointRotationList[index + 1] : m_pointRotationList[index - 1];
        return Quaternion.Lerp(rot1, rot2, ratio);
    }

    private void DrawLine() {
        for (int i = 0; i < pointList.Length - 1; ++i) {
            Debug.DrawLine(pointList[i].position, pointList[i + 1].position, Color.blue);
        }
    }

}
