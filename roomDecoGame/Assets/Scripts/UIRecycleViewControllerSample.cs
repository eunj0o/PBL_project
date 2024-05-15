using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIRecycleViewControllerSample : UIRecycleViewController<UICellSampleData>
    {
        // 리스트 항목의 데이터를 읽어 들이는 메서드
        private void LoadData()
        {
            // 일반적인 데이터는 데이터 소스로부터 가져오는데 여기서는 하드 코드를 사용해하여 정의한다
            tableData = new List<UICellSampleData>();
            //    {
            //    new UICellSampleData { index=1, name="One"},
            //    new UICellSampleData { index=2, name="Two" },
            //    new UICellSampleData { index=3, name="Three" },
            //    new UICellSampleData { index=4, name="Four" },
            //    new UICellSampleData { index=5, name="Five" },
            //    new UICellSampleData { index=6, name="Six" },
            //    new UICellSampleData { index=7, name="Seven" },
            //    new UICellSampleData { index=8, name="Eight" },
            //    new UICellSampleData { index=9, name="Nine" },
            //    new UICellSampleData { index=10,name="Ten" }
            //};
            int count = 0;
            int gridItemNum = ViewerTypeController.control.gridItemNum;
            GoodsData[] goodsDatas = new GoodsData[gridItemNum];
            
            for (int i = 0; i < ItemControl.control.itemList.Count; i++)
            {
                goodsDatas[i % gridItemNum] = new GoodsData { index = i % gridItemNum, name = "", goodsObject = ItemControl.control.itemList[i].iObject };


                if (i % gridItemNum == gridItemNum - 1)
                {
                    tableData.Add(new UICellSampleData { index = count, goodsData = goodsDatas, num = gridItemNum });
                    count++;
                    goodsDatas = new GoodsData[gridItemNum];
                    Debug.Log("goodsData: " + count);
                }
            }
            if(ItemControl.control.itemList.Count % gridItemNum != 0)
                tableData.Add(new UICellSampleData { index = count, goodsData = goodsDatas, num = ItemControl.control.itemList.Count % gridItemNum });
            Debug.Log("테이블 개수: " + tableData.Count);
         //   new GoodsData { index = i % gridItemNum, name = "", goodsObject = ItemControl.control.itemList[i].iObject }

            //for(int i = 0; i < ItemControl.control.itemList.Count; i++)
            //{
            //    tableData.Add(new UICellSampleData { index = i, goodsObject = ItemControl.control.itemList[i].iObject, name = "test" });
            //    Debug.Log("테스트 + " + i);
            //}
            // 스크롤시킬 내용의 크기를 갱신한다
            InitializeTableView();
        }

        // 인스턴스를 로드할 때 Awake 메서드가 처리된 다음에 호출된다
        protected override void Start()
        {
            // 기반 클래스의 Start 메서드를 호출한다
            base.Start();

            // 리스트 항목의 데이터를 읽어 들인다
            LoadData();

        }

        // 셀이 선택됐을 때 호출되는 메서드
        public void OnPressCell(UIRecycleViewCellSample cell)
        {
            Debug.Log("Cell Click");
        }
    }
}
