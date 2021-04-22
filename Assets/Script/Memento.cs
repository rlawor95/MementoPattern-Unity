using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace JK
{
    public class Memento
    {
        //버퍼에 저장시킬 데이터 타입을 정의한다.

        Vector3 location; // 테스트 오브젝트의 위치 저장

        public Vector3 Location
        {
            get { return location; }
            set { location = value; }
        }
        

        string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public Memento(Transform tr)
        {
            location = new Vector3(tr.position.x, tr.position.y, tr.position.z);
        }
    }
}

