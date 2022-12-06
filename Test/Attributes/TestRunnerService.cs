using System.Reflection;

namespace Test.Attributes;
internal static class TestRunnerService
{
    public static void StartTests()
    {
        Console.WriteLine("Test started");

        //Class nomida Test qatnashganlarini listga oladi
        var testClassTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes().Where(t => t.IsClass && t.GetCustomAttribute<TestClassAttribute>() != null))
            .ToList();

        foreach (var testClassType in testClassTypes)
        {
            // Listdagi Classlarni o'zgaruvchiga olish
            var testObj = Activator.CreateInstance(testClassType);

            // Olingan classni metodlari listi
            var logicServiceTestTestMethods = testClassType.GetMethods();

            // Metodlarni ishga tushiramiz
            logicServiceTestTestMethods
                .Where(m => m.GetCustomAttribute<Func>() != null)
                .ToList().ForEach(testMethod => Run(testMethod, testObj));
        }

        void Run(MethodInfo methodInfo, object? testObj)
        {
            Console.WriteLine($"{methodInfo.ReturnType?.Name}.{methodInfo.Name}");

            // Test qiluvchi metodlarni ishga tushiradi
            var attributes = methodInfo.GetCustomAttributes<TestMethodParameters>();
            if(attributes?.Count() > 0)
            {
                int i = 1;
                foreach(var methodData in attributes)
                {
                    Console.Write($"Test{i}: ");
                    i++;
                    methodInfo.Invoke(testObj, parameters: methodData?.Parameters);
                }
            }
            else
            {
                Console.Write("Test: ");
                methodInfo.Invoke(testObj, parameters: null);
            }

            Console.WriteLine();
        }
        Console.ReadKey();
    }
}
