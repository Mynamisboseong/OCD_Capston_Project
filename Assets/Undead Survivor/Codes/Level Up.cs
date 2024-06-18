using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }
    
    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.Instance.Resume();
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }

    void Next()
    {
        //foreach (Item item in items)
        //{
        //    item.gameObject.SetActive(false);
        //}

        //int[] ran = new int[3];
        //while (true)
        //{
        //    ran[0] = Random.Range(0, items.Length);
        //    ran[1] = Random.Range(0, items.Length);
        //    ran[2] = Random.Range(0, items.Length);

        //    if (ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2])
        //        break;
        //}

        //for (int index=0; index < ran.Length; index++)
        //{
        //    Item ranItem = items[ran[index]];

        //    if (ranItem.level == ranItem.data.damages.Length)
        //    {
        //        items[Random.Range(4, 7)].gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        ranItem.gameObject.SetActive(true);
        //    }
        //}
        // 1. 모든 아이템 비활성화
        foreach (Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        // 2. 만렙 아이템을 제외한 랜덤 아이템 3 개 활성화

        List<Item> nonMaxLevelItems = new List<Item>();


        foreach (Item item in items)
        {
            if (item.level < item.data.damages.Length)
            {
                nonMaxLevelItems.Add(item);
            }

        }

        int itemCount = nonMaxLevelItems.Count;


        if (itemCount >= 3)
        {
            // 3. 랜덤 아이템 3개 활성화 -> 포션과 아이템 모두 섞음
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = Random.Range(0, itemCount);
                Item randomItem = nonMaxLevelItems[randomIndex];
                randomItem.gameObject.SetActive(true);
                nonMaxLevelItems.RemoveAt(randomIndex);
                itemCount--;
            }
        }
        else if (itemCount > 0)
        {

            // 4. 만렙이 아닌 아이템이 1개 혹은 2개 일 경우 (포션포함)
            //    포션은 레벨이 없으니 항상 나옴 + 나머지 아이템 하나  
            //   혹은 only 포션만 활성화
            foreach (Item item in nonMaxLevelItems)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}
