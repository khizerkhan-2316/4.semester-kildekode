using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lektion_13___MVC.Infrastructure
{
    public class Utilities
    {


        public static void SortSelectList(List<SelectListItem> selectList, SelectListItem selectedCode)
        {
            ArrayList textList = new ArrayList();
            ArrayList valueList = new ArrayList();
            foreach (SelectListItem li in selectList)
            {
                textList.Add(li.Text);
            }
            textList.Sort();
            foreach (object item in textList)
            {
                SelectListItem li = selectList.Find(x => x.Text.Contains(item.ToString()));
                valueList.Add(li.Value);
            }
            selectList.Clear();
            for (int i = 0; i < textList.Count; i++)
            {
                if (valueList[i].ToString() == selectedCode.ToString())
                {
                    selectList.Add(new SelectListItem
                    {
                        Text = textList[i].ToString(),
                        Value = valueList[i].ToString(),
                        Selected = true
                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Text = textList[i].ToString(),
                        Value = valueList[i].ToString()
                    });
                }
            }
        }


    }
}