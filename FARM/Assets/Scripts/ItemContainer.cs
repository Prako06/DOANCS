using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}
[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject
{
   public List<ItemSlot> slots;

    public void Remove(Item itemToRemove, int count = 1)
    {
        if (itemToRemove.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if(itemSlot == null) { return; }
            itemSlot.count -= count;
            if(itemSlot.count < 0)
            {
                itemSlot.Clear();
            }
        }
        else
        {
            while (count > 0)
            {
                count -= 1;
                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if(itemSlot == null) { return; }
                itemSlot.Clear();
            }
        }
    }

    public void Add(Item itemToAdd, int count = 1)
    {
        if (itemToAdd.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToAdd);
            if(itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = itemToAdd;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = itemToAdd;
            }
        }
    }
}
