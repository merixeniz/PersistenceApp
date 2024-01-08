using System.Runtime.InteropServices;
using Application.Algorithms;
using Application.Algorithms.OOP;
using Application.Algorithms.TakeYouForward;
using Application.Algorithms.Trees;
using Application.Extensions;
using Application.Other;
using Entities.Dto;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var strs = new[] { "abc", "anno" };
            //TakeUForward.Arrays.LongestCommonPrefix(strs);

            //var s = "leetcode";
            //var wordDict = new[] { "leet", "code" };
            //TakeUForward.Arrays.WordBreak(s, wordDict);

            //var reversed = TakeUForward.Arrays.ReverseArray(new[] { 1, 2, 3, 4 });

            //string str = "abcdefg";
            //var result = str[2..4];

            //var zerosToEndInput = new[] { 1, 0, 2, 3, 0, 4, 0, 1 };
            //TakeUForward.Arrays.ZerosToEnd(zerosToEndInput);


            //var getSingleElementInput = new[] { 4, 1, 2, 1, 2 };
            //TakeUForward.Arrays.GetSingleElement(getSingleElementInput);

            //var array = new[] { 2, 3, 5, 1, 9 };
            //TakeUForward.Arrays.LongestSubarrayWithGivenSumPositives(array, 10);

            //var maxSubArray = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //TakeUForward.Arrays.MaxSubArraySum(maxSubArray);

            //var stocks = new[] { 7, 1, 5, 3, 6, 4 };
            //TakeUForward.Arrays.StockBuyAndSell(stocks);

            //var reversedNumber = TakeUForward.Integers.ReverseNumber(472);

            //var vdDto = new CreateVirtualDeviceDto() { Name = "Siemens PLC", PortId = 9999 };
            //var success = Result<CreateVirtualDeviceDto>.Success(vdDto, "All gone well");
            //var failure = Result<CreateVirtualDeviceDto>.Failure(vdDto, "Something went wrong");

            //var serializedSuccess = JsonSerializer.Serialize(success);
            //var seralizedFailure = JsonConvert.SerializeObject(failure);

            //var allowedOptions = FlagEnum.Option1 | FlagEnum.Option2 | FlagEnum.Option3;

            //ExampleUsage.FuncExampleMethod();
            //ExampleUsage.PredicateTExampleMethod();

            //Task.Run(async () => await MethodAsync().ConfigureAwait(false)).Wait();
            //await MethodAsync();
            ////await Task.Run(() => MethodAsync());

            //var output = SpanFun.SpanPlayground();

            //var person = new Person();
            //person.Work();

            //var lawyer = new Lawyer();
            //lawyer.Work();

            //var softwareDev = new SoftwareDeveloper();
            //softwareDev.Work();

            //RangeOperatorPlayground.ChangeOrderOfElementsInCollection();

            BinaryTree.CreateAndInvertBinaryTree();

            Console.WriteLine("Hello, World!");
        }

        private static async Task MethodAsync()
        {
            await Task.Delay(5);
            Console.WriteLine("Method ASync run");
        }
    }
}