// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("4dXraN7MCDNw97ZPCRdO5wvteWvP8qRtbNnIXHrPn0sQsWuzcsmYQUvtBltRXIXgTWcLnmyDwnj2n46gveTP8mzT4UChx/CQUKtUavgy7Tl7eqN/Du48x02Pcg143WNnMS/BA066W5drBYOauvh2vNpJphqJ/XURxQwI6NQrdT5OKBNVOk1ME0yLIw9k5+nm1mTn7ORk5+fmcEg9qfDaDy4T1s5+v8wh6pCX7oro/WfuA+SV1mTnxNbr4O/MYK5gEevn5+fj5uWVtQMiVMQeybnKqYpz4Y1UXVKWzlgEBz4/7v2xDdS8iXlKwF8ikl4NKw7dd2kxfNX1hM/95GmRoYneJkZnkIrTNdpyL1/8SiYHWkaXx8xyfVIn3UNKujY2weTl5+bn");
        private static int[] order = new int[] { 7,10,11,3,5,9,12,10,13,10,13,12,12,13,14 };
        private static int key = 230;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
