using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject prefab; //最初からいるのでpublicにできる
    public GameManager gm; //最初からいるのでpublicにできる

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    //コルーチンで生成を行う
    IEnumerator Create()
    {
        //生成間隔の初期値
        float delta = 1.5f;
        while (true)
        {
            GameObject obj = Instantiate(
                prefab, //なにを
                new Vector3( //どこに
                    Random.Range(-10.0f, 10.0f),
                    Random.Range(8.0f, 12.0f),
                    Random.Range(-2.0f, 3.0f)),
                Quaternion.identity //どの向きに
            );

            //GameManagerをリセットする
            obj.GetComponent<CubeController>().SetGameManager(gm); //objはインスタンシエイトされたcube。

            //生成間隔時間停止
            yield return new WaitForSeconds(delta);

            //徐々に生成間隔を早める
            if(delta > 0.5f) //最小は0.5f
            {
                delta -= 0.05f; //0.05fずつ早くなる
            }
        }
    }
}
