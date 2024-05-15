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
        // ĳ���� ����Ʈ �������� (���� ���� ���̵����͸� ����)
        //characters = client.FetchCharacters();
        // ����Ʈ UI�� �Ѹ���
        Populate(characters);
    }

    // UI�� ����Ʈ �Ѹ��� ���
    private void Populate(List<Character> list)
    {
        // ȭ�� ���Ž� ����Ʈ�� ��� ������ �ʵ��� ���� ��ü�� ���ֱ�
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }
        // GridLayoutGroup �ȿ� ĳ���� ī�� ������ �ְ� ������ ���ε�
        for(int i = 0; i < 20; i++)
        {
            //GameObject go = Instantiate(ItemControl.control.itemList[i].iObject, gridLayout.transform);
            //GameObject go = Instantiate(characterCard, gridLayout.transform);
            //go.GetComponent<CharacterCard>().Bind(item);
        }
    }
}
