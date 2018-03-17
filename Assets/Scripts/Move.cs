using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float RotateAroundSpeed,i = 0, j = 0;
    private GameObject thisCube;
    float PosM = 0;
    Boolean flag = false;
    public GameObject MCam;
    Sort sort;

    public void SetPos(float posm, float x, float y) {
        PosM = posm;
        i = x;
        j = y;
    }

    public void StartMove() {
        RotateAroundSpeed = 20 * Time.deltaTime;
        //flag = !flag;
    }

    public void StopMove() {
        RotateAroundSpeed = 0;
    }

    // Use this for initialization
    void Start() {
        thisCube = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        //if ((Math.Abs(this.transform.rotation.y - 180)<10 && flag == false) || (Math.Abs(this.transform.rotation.y)<1 && flag == true)) {
        //    RotateAroundSpeed = 0;
        //    float x = Math.Abs(this.transform.position.x - i) > Math.Abs(this.transform.position.x - j) ? j : i;
        //    this.transform.position = new Vector3(x, this.transform.position.y, 0);
        //    flag = !flag;
        //}
         thisCube.transform.RotateAround(new Vector3(PosM, 0, 0), Vector3.up, RotateAroundSpeed);
        if ((Math.Abs(this.transform.position.x - j) < RotateAroundSpeed*(Math.Sin(180-this.transform.rotation.y)))) {
            RotateAroundSpeed = 0;
            //float x = Math.Abs(this.transform.position.x - i) > Math.Abs(this.transform.position.x - j) ? j : i;
            this.transform.position = new Vector3(j, this.transform.position.y, 0);
            this.transform.rotation = new Quaternion(0,0,0,0);
            flag = !flag;
        }

    }
}
