using System;

  //Definition for singly-linked list.
public class ListNode
{
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
}


public class Solution
{

    private ListNode _resultList;

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        if (l1 == null || l2 == null)
            return null;

        int carryOne = 0;

        ListNode resultNode;

        int sum = l1.val + l2.val;
        if (sum <= 9)
        {
            resultNode = new ListNode(sum);
        }
        else
        {
            resultNode = new ListNode(sum - 10);
            carryOne = 1;
        }

        if (_resultList == null)
            _resultList = resultNode;



        if (l1.next != null && l2.next != null)
        {
            l1.next.val += carryOne;
            _resultList.next = AddTwoNumbers(l1.next, l2.next);
            return _resultList;
        }

        if(l1.next == null)
        {
            ListNode listNodeItem = l2.next;
            listNodeItem.val += carryOne;
            while(listNodeItem != null)
            {

                _resultList.next
            }
        }



    }
}