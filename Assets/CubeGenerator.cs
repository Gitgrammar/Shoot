using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
	public GameObject prefab;
	public GameManager gm;

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
				prefab,
				new Vector3(Random.Range(-11.0f, 12.0f), Random.Range(8.0f, 12.0f), Random.Range(-3.0f, 3.0f)),
				Quaternion.identity

			);
			//GameMangerをセットする。
			obj.GetComponent<CubeController>().SetGameMananger(gm);
			//生成間隔時間停止
			yield return new WaitForSeconds(delta);
			//徐々に生成間隔を早める
			if (delta > 0.5f)
			{
				delta -= 0.05f;
			}
		}
	}
}
