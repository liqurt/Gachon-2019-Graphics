using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    
    public GameObject target;
    private GameObject pirateHead;
    public float theta;
    Vector3 vPosition;
    Vector3 vRotation;
    private bool boong;

	// Use this for initialization
	void Start () {
        theta = 0;
        pirateHead = GameObject.Find("pirateHead"); // pirateHead에 pirateHead할당.
        boong = false; // 붕은 헤적머리가 한번이라도 떳으면 true로 할꺼임. 고로 처음엔 false
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)){
            theta -=0.05f; // ← 키를 누르면 세타값이 작아짐.
            modifyPosition(theta); // 세타값에 따라 카메라의 위치도 바뀜.
            modifyRotation(); // 위치가 바뀌면 카메라가 보는곳도 바뀜.
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            theta +=0.05f; // → 키를 누르면 세타값이 작아짐.
            modifyPosition(theta);
            modifyRotation();
        }
        if (pirateHead.transform.position.y > 15 && boong == false) // 머리가 붕 뜨고, y축 기준 15이상으로 떳으면!
        {
            boong = true; // 붕을 true로
        }
        if (boong == true) // 붕이 true면
        {
            closeUpPirateHead(); // 해적 머리를 클로즈업 해야지
        }
    }

    void modifyPosition(float theta) { //표적을 잡고 원형으로 둥굴레
        vPosition = transform.position; // transform.position은 현재 카메라의 위치를 의미함.
        vPosition.x = Mathf.Cos(theta) * 10; // 카메라의 원 운동으로 카메라의 위치를 재구성.
        vPosition.y = transform.position.y; // y축은 변화 없음.
        vPosition.z = Mathf.Sin(theta) * 10;
        transform.position = vPosition; // 재구성한 위치를 카메라의 위치로 할당함.
    }

    void modifyRotation()// 룩앳을 고정하자
    {
        Quaternion lookAt = Quaternion.identity; // 자료형 Quaternion은 그래픽스 시간에 교수님이 말씀하신, [x,y,z,w]임
        Vector3 lookAtVec = (target.transform.position - transform.position).normalized; // 룩앳 벡터는 카메라에서 타겟을 바라보는 벡터.
        lookAt.SetLookRotation(lookAtVec); //룩앳벡터를 Quaternion화 해서
        transform.rotation = lookAt; // 카메라가 룩앳을 보도록 함.
    }

    void closeUpPirateHead() //날아간 해적의 머리.
    {
        boong = true; // 혹시 몰라서 붕을 또 true로 바꿈.
        Quaternion lookAt = Quaternion.identity;
        Vector3 lookAtVec = (pirateHead.transform.position - transform.position).normalized; // 룩앳벡터는 카메라에서 해적머리를 바라보는 벡터
        lookAt.SetLookRotation(lookAtVec);
        transform.rotation = lookAt;
    }
    
}
