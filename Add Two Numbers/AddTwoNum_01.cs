//Runtime: 112 ms, faster than 51.48% of C# online submissions for Add Two Numbers.
//Memory Usage: 27.8 MB, less than 9.09% of C# online submissions for Add Two Numbers.

//NOTES: Need to review recursion
//       Review datatypes that are either passed by reference or value
//       https://jonskeet.uk/csharp/parameters.html

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //dictionary to hold value of each node value in list #1, key = index
        Dictionary<int, int> l1Dict = new Dictionary<int, int>();
        l1Dict.Add(0, l1.val);
        if (l1.next != null)
            BuildValueList(l1.next, 0,  l1Dict);

        //dictionary to hold value of each node value in list #1, key = index
        Dictionary<int, int> l2Dict = new Dictionary<int, int>();
        l2Dict.Add(0, l2.val);
        if (l1.next != null)
            BuildValueList(l2.next, 0,  l2Dict);


        int l1DictSize = l1Dict.Count;
        int l2DictSize = l2Dict.Count;

        int sizeDiff = l1DictSize - l2DictSize;

        Dictionary<int, int> resultDict = new Dictionary<int, int>();

        int remainder = 0;

        //for when the input ListNodes are unequal and equal in length
        if (sizeDiff < 0)
        {
            //l2 size bigger
            remainder = GetSum(l1Dict, l2Dict, l1DictSize,  resultDict);
            GetSingleListSum(l2Dict, l1DictSize, l2DictSize, remainder,  resultDict);
        }
        else if (sizeDiff > 0)
        {
            remainder = GetSum(l1Dict, l2Dict, l2DictSize,  resultDict);
            GetSingleListSum(l1Dict, l2DictSize, l1DictSize, remainder,  resultDict);
        }
        else
        {
            remainder = GetSum(l1Dict, l2Dict, l2DictSize,  resultDict);
            resultDict.Add(l2DictSize, remainder);
        }

        //ListNode resultListNode = new ListNode(resultDict[0]);

        ListNode resultListNode = CreateListNodeLinkedList(null, 0, resultDict.Count,  resultDict);

        return resultListNode;
    }

    //Use recursion to create new ListNode for output, 
    //index is for traverse until max (count of dictionary of result values)
    public static ListNode CreateListNodeLinkedList(ListNode listNode, int index, int max,  Dictionary<int, int> resultDict)
    {
        if (index == max - 1)
            return listNode;

        listNode = new ListNode(resultDict[index]);

        listNode.next = CreateListNodeLinkedList(listNode.next, index += 1, max,  resultDict);

        return listNode;
    }

    //for use case when one node list is greater in length than the other
    public void GetSingleListSum(Dictionary<int, int> listDictionary, int startIndex, int endIndex, int remainder,  Dictionary<int, int> resultDict)
    {
        //start index is after 'shorter' node list ended, 
        //iterator ends at count of 'longer' node list
        for (int i = startIndex; i < endIndex; i++)
        {

            int sum = listDictionary[i] += remainder;

            if (listDictionary[i] > 9)
            {
                resultDict.Add(i, sum - 10);
                remainder = 1;
            }
            else
            {
                resultDict.Add(i, sum);
                remainder = 0;
            }

        }
        if (remainder > 0)
            resultDict.Add(endIndex, remainder);

    }

    //sum of two node values at same key index among the two dictionaries. 
    public int GetSum(Dictionary<int, int> l1Dict, Dictionary<int, int> l2Dict, int maxSize,  Dictionary<int, int> resultDict)
    {
        //flag for if sum results in need to 'carry the one' to next node value
        bool carryTheOne = false;

        for (int i = 0; i < maxSize; i++)
        {

            int sum = l1Dict[i] + l2Dict[i];

            if (carryTheOne)
                sum += 1;

            if (sum > 9)
            {
                resultDict.Add(i, sum - 10);
                carryTheOne = true;
            }
            else
            {
                resultDict.Add(i, sum);
                carryTheOne = false;
            }
        }
        if (carryTheOne)
            return 1;
        return 0;
    }

    //Use recursion to traverse linked list, incrementing an index to add as key to dict  
    public void BuildValueList(ListNode node, int index, Dictionary<int, int> dict)
    {
        if (node == null)
            return;
        index += 1;
        dict.Add(index, node.val);
        if (node.next == null)
            return;
        BuildValueList(node.next, index,  dict);
    }
}