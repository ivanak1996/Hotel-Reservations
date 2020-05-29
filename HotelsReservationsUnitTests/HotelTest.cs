using HotelsReservations.Hotels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelsReservationsUnitTests
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void TestCase1()
        {
            Hotel hotel = new Hotel(1, 5);
            bool outcome1 = hotel.Reserve(-4, 2);
            bool outcome2 = hotel.Reserve(200, 400);
            Assert.IsFalse(outcome1);
            Assert.IsFalse(outcome2);
        }

        [TestMethod]
        public void TestCase2()
        {
            Hotel hotel = new Hotel(3, 20);
            Assert.AreEqual(true, hotel.Reserve(0, 5));
            Assert.AreEqual(true, hotel.Reserve(7, 13));
            Assert.AreEqual(true, hotel.Reserve(3, 9));
            Assert.AreEqual(true, hotel.Reserve(5, 7));
            Assert.AreEqual(true, hotel.Reserve(6, 6));
            Assert.AreEqual(true, hotel.Reserve(0, 4));
        }

        [TestMethod]
        public void TestCase3()
        {
            Hotel hotel = new Hotel(3, 20);
            Assert.AreEqual(true, hotel.Reserve(1, 3));
            Assert.AreEqual(true, hotel.Reserve(2, 5));
            Assert.AreEqual(true, hotel.Reserve(1, 9));
            Assert.AreEqual(false, hotel.Reserve(0, 15));
        }

        [TestMethod]
        public void TestCase4()
        {
            Hotel hotel = new Hotel(3, 20);
            Assert.AreEqual(true, hotel.Reserve(1, 3));
            Assert.AreEqual(true, hotel.Reserve(0, 15));
            Assert.AreEqual(true, hotel.Reserve(1, 9));
            Assert.AreEqual(false, hotel.Reserve(2, 5));
            Assert.AreEqual(true, hotel.Reserve(4, 9));
        }

        [TestMethod]
        public void TestCase5()
        {
            Hotel hotel = new Hotel(2, 20);
            Assert.AreEqual(true, hotel.Reserve(1, 3));
            Assert.AreEqual(true, hotel.Reserve(0, 4));
            Assert.AreEqual(false, hotel.Reserve(2, 3));
            Assert.AreEqual(true, hotel.Reserve(5, 5));
            Assert.AreEqual(true, hotel.Reserve(4, 10));
            Assert.AreEqual(true, hotel.Reserve(10, 10));
            Assert.AreEqual(true, hotel.Reserve(6, 7));
            Assert.AreEqual(false, hotel.Reserve(8, 10));
            Assert.AreEqual(true, hotel.Reserve(8, 9));
        }
    }
}
