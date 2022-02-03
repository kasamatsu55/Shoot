using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //通常クリック
        {
            //引数一つでInstantiate
            GameObject obj = Instantiate(prefab);

            //親要素を設定（今回はカメラ）
            obj.transform.parent = transform;

            //親要素からオフセットは0
            obj.transform.localPosition = Vector3.zero; //=(0,0,0)

            //メインカメラからマウスクリックした地点にrayを飛ばす
            //MainCameraというタグがついているので
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //rayの方向を長さ1にしてdirに代入（画面の端をクリックしても挙動が変わらないように）
            Vector3 dir = ray.direction.normalized;

            //生成したobjのrigidbodyを取得し、速度をdir方向に与える
            //obj.GetComponent<Rigidbody>().velocity = dir * 100.0f; //秒速100メートルくらいで飛んでいく
            obj.GetComponent<Rigidbody>().AddForce(dir * 100.0f,ForceMode.Impulse); //メソッドを用いて力を加える方法
        }
    }
}
