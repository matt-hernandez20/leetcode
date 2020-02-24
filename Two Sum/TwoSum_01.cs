//Runtime: 492 ms, faster than 17.78% of C# online submissions for Two Sum.
//Memory Usage: 30.7 MB
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] result = new int[2];
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (EqualToTarget(nums[i], nums[j], target))
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }
        return result;
    }

    public bool EqualToTarget(int numOne, int numTwo, int target)
    {
        return numOne + numTwo == target;
    }
}
