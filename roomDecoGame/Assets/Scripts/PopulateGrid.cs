using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using UI;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class PopulateGrid : MonoBehaviour
{
    public GameObject characterCard;
    public GameObject gridLayout;


    //private HttpClient client = new HttpClient();
    private List<Character> characters;

    private void Start()
    {
        // 캐릭터 리스트 가져오기 (서버 없이 더미데이터를 넣음)
        //characters = client.FetchCharacters();
        // 리스트 UI에 뿌리기
        Populate(characters);
    }

    // UI에 리스트 뿌리는 기능
    private void Populate(List<Character> list)
    {
        // 화면 갱신시 리스트가 계속 쌓이지 않도록 기존 객체들 없애기
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }
        // GridLayoutGroup 안에 캐릭터 카드 프리팹 넣고 데이터 바인딩
        for(int i = 0; i < 20; i++)
        {
            //GameObject go = Instantiate(ItemControl.control.itemList[i].iObject, gridLayout.transform);
            //GameObject go = Instantiate(characterCard, gridLayout.transform);
            //go.GetComponent<CharacterCard>().Bind(item);
        }
    }
}
