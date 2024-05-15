using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ViewerTypeController : MonoBehaviour
    {
        public static ViewerTypeController control;

        public int gridItemNum = 4;

        // Update is called once per frame
        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (control == null)
            {
                control = this;
            }
            else if (control != this)
            {
                Destroy(gameObject);
            }
        }
        

        public void setOnMiniType()
        {
            gridItemNum = 8;
        }

        public void setOnLargeType()
        {
            gridItemNum = 4;
        }
    }
}
