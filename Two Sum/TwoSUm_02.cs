//Runtime: 240 ms, faster than 89.94% of C# online submissions for Two Sum.
//Memory Usage: 31.2 MB, less than 5.08% of C# online submissions for Two Sum.
public class Solution
{

    public int[] TwoSum(int[] nums, int target)
    {
        int[] result = new int[2];

        if (nums == null || nums.Length < 2)
            return result;

        Dictionary<int, int> hash = new Dictionary<int, int>();

        hash.Add(nums[0], 0);

        for (int i = 1; i < nums.Length; i++)
        {

            if (hash.TryGetValue(target - nums[i], out result[0]))
            {
                result[1] = i;
                return result;
            }
            else if (!hash.TryGetValue(nums[i], out int temp))
            {
                hash.Add(nums[i], i);
            }



        }
        return result;
    }

}