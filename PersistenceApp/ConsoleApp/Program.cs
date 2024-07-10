using Application.Algorithms.Trees;
using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Dispatcher;
using ConsoleApp.CustomMediatr.Entities;
using ConsoleApp.CustomMediatr.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.CustomMediatr.EventStore;
using ConsoleApp.CustomMediatr.Repositories;
using ConsoleApp.CustomMediatr.StateRebuilder;

namespace ConsoleApp;


internal class Program
{
    static async Task Main(string[] args)
    {
        //var dict = new Dictionary<int, string>
        //{
        //    { 5, "asd" }
        //};

        //var list = new List<int> { 1, 2, 3, 4, 5 };
        //var array = new[] { 1, 2, 3, 4, 5 };
        //var que = new Queue<int>([1, 2, 3, 4, 5]);
        //var firstQueue = que.Dequeue();
        //var stack = new Stack<int>([1, 2, 3, 4, 5]);
        //var hashSet = new HashSet<int>([1, 2, 3, 4, 5]);

        //await TaskFun.MainAsync();
        //int[] array2 = [1, 2, 4, 5];
        //TryReturn();


        await EventSourcingMain();
    }

    private static async Task EventSourcingMain()
    {
        var serviceProvider = DependencyInjection.InitializeContainer();
        var dispatcher = serviceProvider.GetService<ICommandDispatcher>() ?? new CommandDispatcher(serviceProvider);
        var eventStore = serviceProvider.GetService<IEventStore>() ?? new InMemoryEventStore();
        var bankAccountRepository = serviceProvider.GetService<IBankAccountRepository>() ?? new InMemoryBankAccountRepository();

        var command = new MessageCommand(1, "Hello, World!");
        await dispatcher.DispatchAsync(command);

        var accountId = Guid.NewGuid();
        var targetAccountId = Guid.NewGuid();
        var bankAccount1 = new BankAccount(accountId);
        var bankAccount2 = new BankAccount(targetAccountId);
        bankAccountRepository.Add(bankAccount1);
        bankAccountRepository.Add(bankAccount2);

        //await dispatcher.DispatchAsync(new DepositCommand(accountId, 100m));
        //await dispatcher.DispatchAsync(new WithdrawCommand(accountId, 10m));
        await dispatcher.DispatchAsync(new TransferCommand(accountId, targetAccountId, 20m));

        var lastEvent = (await eventStore.GetEventsAsync(accountId)).Last();
        //await dispatcher.DispatchAsync(new UndoCommand(lastEvent.EventId));

        var stateRebuilder = new StateRebuilder(eventStore, bankAccountRepository);
        var bankAccount = await stateRebuilder.RebuildStateAsync(accountId);
        var targetBankAccount = await stateRebuilder.RebuildStateAsync(targetAccountId);

        Console.WriteLine($"BankAccount State: Id={bankAccount.Id}, Balance={bankAccount.Balance}");
        Console.WriteLine(
            $"TargetBankAccount State: Id={targetBankAccount.Id}, Balance={targetBankAccount.Balance}");
    }

    private static int SumOfWindow(int[]? input, int k)
    {
        if (input is null || input.Length == 0 || k < 1) return -1;

        var sum = input[0];
        var result = sum;
        var right = 0;

        for (right = 0; right < k; right++)
        {
            sum += input[right];

            if (sum > result)
                result = sum;
        }

        for (right = k; right < input.Length; right++)
        {
            sum += input[right] - input[right - k];

            if (sum > result)
                result = sum;
        }

        Console.WriteLine($"Highest sum: {sum}");
        return sum;
    }

    private static int SumLeftToRight(int[] input, int left, int right)
    {
        int sum = 0;
        for (var i = left; i <= right; i++)
        {
            sum += input[i];
        }

        return sum;
    }

    static int TryReturn()
    {
        try
        {
            Console.WriteLine("W bloku try");
            return 1;
        }
        finally
        {
            Console.WriteLine("W bloku finally");
        }
    }

    private static async Task OldMain()
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

        Task.Run(async () => await MethodAsync().ConfigureAwait(false)).Wait();
        await MethodAsync();
        await Task.Run(() => MethodAsync());

        //var output = SpanFun.SpanPlayground();

        //var person = new Person();
        //person.Work();

        //var lawyer = new Lawyer();
        //lawyer.Work();

        //var softwareDev = new SoftwareDeveloper();
        //softwareDev.Work();

        //RangeOperatorPlayground.ChangeOrderOfElementsInCollection();

        BinaryTree.CreateAndInvertBinaryTree();
    }

    private static async Task MethodAsync()
    {
        await Task.Delay(5);
        Console.WriteLine("Method ASync run");
    }
}