using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace UI
{
    public class UICellSampleData
    {
        public int index;
        public GoodsData[] goodsData;
        public int num;
    }

    public class GoodsData
    {
        public int index;
        public string name;
        public GameObject goodsObject;
    }


    public class UIRecycleViewCellSample : UIRecycleViewCell<UICellSampleData>
    {
        [SerializeField]
        private GameObject[] items;
        public override void UpdateContent(UICellSampleData itemData)
        {
            if (itemData.num == 4)
            {
                for (int i = 0; i < itemData.goodsData.Length; i++)
                {
                    items[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = itemData.goodsData[i].goodsObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                    items[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = itemData.goodsData[i].goodsObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                    items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = itemData.goodsData[i].goodsObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                    items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().color = itemData.goodsData[i].goodsObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color;
                    items[i].transform.GetChild(2).GetComponent<SpriteMask>().sprite = itemData.goodsData[i].goodsObject.transform.GetChild(2).GetComponent<SpriteMask>().sprite;
                    items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                }
            }
            else
            {
                for (int i = 0; i < itemData.goodsData.Length; i++)
                {
                    if (i < itemData.num)
                    {
                        items[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = itemData.goodsData[i].goodsObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                        items[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = itemData.goodsData[i].goodsObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                        items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = itemData.goodsData[i].goodsObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
                        items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().color = itemData.goodsData[i].goodsObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color;
                        items[i].transform.GetChild(2).GetComponent<SpriteMask>().sprite = itemData.goodsData[i].goodsObject.transform.GetChild(2).GetComponent<SpriteMask>().sprite;
                        items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    }
                    else
                    {
                        items[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                        items[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0,0);
                        items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = null;
                        items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
                        items[i].transform.GetChild(2).GetComponent<SpriteMask>().sprite = null;
                        items[i].transform.GetChild(1).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    }
                }
            }

            


                //GameObject temp = Instantiate(goodsData.goodsObject, this.transform);
                // temp.AddComponent<RectTransform>();
                //    temp.transform.SetParent(this.transform);


                //temp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                //temp.SetActive(true);

            


        }

        public void onClickedButton()
        {
            
        }
    }
}
