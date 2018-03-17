using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlaneTriggerEnter : MonoBehaviour {

    /// <summary>
    /// 调整变换后的位置
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) {
        //if (other.tag.CompareTo("Cube") == 0) {
        //    Move move = other.GetComponent<Move>();
        //    move.StopMove();
        //    float x = Math.Abs(other.transform.position.x - move.i) > Math.Abs(other.transform.position.x - move.j) ?move. j : move.i;
        //    other.transform.position = new Vector3(x, other.transform.position.y, 0);
        //}
    }
}
