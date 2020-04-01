using System;
using Xunit;
using Report_Creator.Logic;

namespace ReportCreatorTests
{
    public class PracticeCreatorTests
    {
        
        [Fact]
        public void TestInitialization()
        {
            var practiceCreator = new PracticeCreator(@"C:\Users\39340\Downloads\QDDT_Dett (19).csv", new string[] { ";" });
            var items = practiceCreator.Items();
        }

        [Fact]
        public void TestGetPractice()
        {
            var practiceCreator = new PracticeCreator(@"C:\Users\39340\Downloads\QDDT_Dett (19).csv", new string[] { ";" });
            var items = practiceCreator.Items();


            var practice = practiceCreator.GetPractice(64906);
            Assert.True(practice.Client == "Siemens IT");
            Assert.True(practice.DDTID == 64906);
            Assert.False(practice.ItemCount() == 1);
        }

        [Fact]
        public void PrintTest()
        {
            var practiceCreator = new PracticeCreator(@"C:\Users\39340\Downloads\QDDT_Dett (19).csv", new string[] { ";" });
            var items = practiceCreator.Items();

            var practice = practiceCreator.GetPractice(52731);

            Console.WriteLine(practice.ToString());
        }
    }
}
