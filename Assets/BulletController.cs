using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnBecameInvisible() //カメラのレンダリングの範囲から消えたら
    {
        Destroy(gameObject); //スクリプトがアタッチされているオブジェクトを削除する
    }
}
