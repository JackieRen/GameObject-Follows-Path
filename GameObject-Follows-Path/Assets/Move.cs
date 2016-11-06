using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Path path;
    public float speed = 1f;
    public bool isLoop = false;
    public bool isReversed = false;

    private int m_currentSegment;
    private float m_transition;

    void Start() {
        if (isReversed) {
            m_currentSegment = path.pointList.Length - 1;
        } else {
            m_currentSegment = 0;
        }
    }
	
	void Update () {
        Play();
    }

    private void Play() {
        m_transition += Time.deltaTime * speed;
        if (m_transition > 1) {
            m_transition = 0;
            m_currentSegment = (isReversed) ? m_currentSegment - 1 : m_currentSegment + 1;
        }
        if (isReversed) {
            if (m_currentSegment > 0) {
                transform.position = path.LinearPosition(m_currentSegment, m_transition, false);
                transform.rotation = path.Orientation(m_currentSegment, m_transition, false);
            }
            if (isLoop) {
                m_currentSegment = path.pointList.Length - 1;
            }
        } else {
            if (m_currentSegment < path.pointList.Length - 1) {
                transform.position = path.LinearPosition(m_currentSegment, m_transition);
                transform.rotation = path.Orientation(m_currentSegment, m_transition);
            }
            if (isLoop) {
                m_currentSegment = 0;
            }
        }
    }

}
