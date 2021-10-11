using NUnit.Framework;
using System;
using MarsRoverBestGroup3._0.Models;
using FluentAssertions;


namespace MarsRoversTests
{
    public class DateConverterTest
    {
       
        [Test]
        public void CuriositySolTest()
        {
            DateTime testdate = new DateTime(2021, 10, 11);
            int expectedSol = 3264;

            var result = DateConverter.CuriositySol(testdate);

            Assert.AreEqual(result, expectedSol);
        }
    }
}