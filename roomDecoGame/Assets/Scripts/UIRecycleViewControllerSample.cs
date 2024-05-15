using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIRecycleViewControllerSample : UIRecycleViewController<UICellSampleData>
    {
        // ����Ʈ �׸��� �����͸� �о� ���̴� �޼���
        private void LoadData()
        {
            // �Ϲ����� �����ʹ� ������ �ҽ��κ��� �������µ� ���⼭�� �ϵ� �ڵ带 ������Ͽ� �����Ѵ�
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
            Debug.Log("���̺� ����: " + tableData.Count);
         //   new GoodsData { index = i % gridItemNum, name = "", goodsObject = ItemControl.control.itemList[i].iObject }

            //for(int i = 0; i < ItemControl.control.itemList.Count; i++)
            //{
            //    tableData.Add(new UICellSampleData { index = i, goodsObject = ItemControl.control.itemList[i].iObject, name = "test" });
            //    Debug.Log("�׽�Ʈ + " + i);
            //}
            // ��ũ�ѽ�ų ������ ũ�⸦ �����Ѵ�
            InitializeTableView();
        }

        // �ν��Ͻ��� �ε��� �� Awake �޼��尡 ó���� ������ ȣ��ȴ�
        protected override void Start()
        {
            // ��� Ŭ������ Start �޼��带 ȣ���Ѵ�
            base.Start();

            // ����Ʈ �׸��� �����͸� �о� ���δ�
            LoadData();

        }

        // ���� ���õ��� �� ȣ��Ǵ� �޼���
        public void OnPressCell(UIRecycleViewCellSample cell)
        {
            Debug.Log("Cell Click");
        }
    }
}
