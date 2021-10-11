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
        [Test]
        public void PerseveranceSolTest()
        {
            DateTime testdate = new DateTime(2021, 10, 11);
            int expectedSol = 228;

            var result = DateConverter.PerseveranceSol(testdate);

            Assert.AreEqual(result, expectedSol);
        }
        [Test]
        public void OpportunitySolTest()
        {
            DateTime testdate = new DateTime(2021, 10, 11);
            int expectedSol = 6296;

            var result = DateConverter.OpportunitySol(testdate);

            Assert.AreEqual(result, expectedSol);
        }
        [Test]
        public void SpiritSolTest()
        {
            DateTime testdate = new DateTime(2021, 10, 11);
            int expectedSol = 6316;

            var result = DateConverter.SpiritSol(testdate);

            Assert.AreEqual(result, expectedSol);
        }
        [Test]
        public void SojournerSolTest()
        {
            DateTime testdate = new DateTime(2021, 10, 11);
            int expectedSol = 8628;

            var result = DateConverter.SojournerSol(testdate);

            Assert.AreEqual(result, expectedSol);
        }
    }
}