using Moq;
using NUnit.Framework;
using System;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
using BK6RIJ_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Test
{
    [TestFixture]
    public class TestWithMoq
    {
        OrderLogic ol;
        CustomerLogic cl;
        DeliveryLogic dl;
        ProductLogic pl;

        public TestWithMoq()
        {
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            Mock<IDeliveryRepository> mockDeliveryRepository = new Mock<IDeliveryRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            Customer fakeCustumer1 = new Customer()
            {
                FirstName = "Bela",
                LastName = "Kovacs",
                Id=1
            };
            
            Product fakeProduct1 = new Product()
            {
                Name = "Bread",
                Price = 300,
                Id = 1
            };
            

            Delivery fakeDelivery1 = new Delivery()
            {
                Company = "FoxPost",
                DeliveryDays = 6,
                Id = 1
            };
            

            mockOrderRepository.Setup((t) => t.Create(It.IsAny<Order>()));
            mockOrderRepository.Setup((t) => t.ReadAll()).Returns(
               new List<Order>()
               {
                    new Order()
                    {
                        OrderId = 1,
                        OrderDate = new DateTime(2021,10,03),
                        Customer = fakeCustumer1,
                        Product = fakeProduct1,
                        Delivery = fakeDelivery1
                    },
                    new Order()
                    {
                        OrderId = 2,
                        OrderDate = new DateTime(2021,10,04),
                        Customer = fakeCustumer1,
                        Product = fakeProduct1,
                        Delivery = fakeDelivery1
                    },
                    new Order()
                    {
                        OrderId = 3,
                        OrderDate = new DateTime(2020,10,03),
                        Customer = fakeCustumer1,
                        Product = fakeProduct1,
                        Delivery = fakeDelivery1
                    }
               }.AsQueryable());
            mockCustomerRepository.Setup((t) => t.Create(It.IsAny<Customer>()));
            mockDeliveryRepository.Setup((t) => t.Create(It.IsAny<Delivery>()));
            mockProductRepository.Setup((t) => t.Create(It.IsAny<Product>()));

            ol = new OrderLogic(mockOrderRepository.Object);
            cl = new CustomerLogic(mockCustomerRepository.Object);
            dl = new DeliveryLogic(mockDeliveryRepository.Object);
            pl = new ProductLogic(mockProductRepository.Object);
        }

        [Test]
        public void CountOfOrdersByProductsTest()
        {
            //act
            var result = ol.CountOfOrdersByProducts().ToArray();

            //assert
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int> ( "Bread", 3 )));
        }

        [Test]
        public void CountOfProductsByCustumerTest()
        {
            //act
            var result = ol.CountOfProductsByCustomers().ToArray();

            //assert
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<int, int>(1, 3)));
        }

        [TestCase(1)]
        public void OrdersFromASpecificCustumerTest(int id)
        {
            //act
            var result = ol.OrdersFromASpecificCustomer(id).ToArray();

            //assert
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<DateTime, string>(new DateTime(2020, 10, 03), "Bread")));
        }

        [TestCase("2021.10.01")]
        public void OrderInformationsAfterADateTest(string date)
        {
            //act
            var result = ol.OrderInformationsAfterADate(date).ToArray();

            //assert
            Assert.That(result[0].Equals(new KeyValuePair<int, string>( 1,
                $"{new DateTime(2021,10,03).ToShortDateString()} - Bela Kovacs: Bread 300/piece (Delivery: FoxPost-6)"
                )));
        }

        [Test]
        public void CountOfOrdersByCompanies()
        {
            //act
            var result = ol.CountOfOrdersByCompanies().ToArray();

            //assert
            Assert.That(result[0].Equals(new KeyValuePair<string, int>("FoxPost", 3)));
        }



        [TestCase("a", "b",true)]
        [TestCase("a", "",false)]
        [TestCase("", "b",false)]
        [TestCase("", "",false)]
        public void CreateCustomerTest(string firstn, string lastn, bool result)
        {
            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => cl.Create(new Customer()
                {
                    FirstName = firstn,
                    LastName = lastn
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => cl.Create(new Customer()
                {
                    FirstName = firstn,
                    LastName = lastn
                }), Throws.Exception);
            }
        }

        [TestCase("a", 1, true)]
        [TestCase("a", 0, false)]
        [TestCase("a", -1, false)]
        [TestCase("", 1, false)]
        [TestCase("", 0, false)]
        public void CreateDeliveryTest(string comp, int days, bool result)
        {
            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => dl.Create(new Delivery()
                {
                    Company = comp,
                    DeliveryDays = days
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => dl.Create(new Delivery()
                {
                    Company = comp,
                    DeliveryDays = days
                }), Throws.Exception);
            }
        }

        [TestCase("a", 1, true)]
        [TestCase("a", 0, false)]
        [TestCase("a", -1, false)]
        [TestCase("", 1, false)]
        [TestCase("", 0, false)]
        public void CreateProductTest(string name, int cost, bool result)
        {
            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => pl.Create(new Product()
                {
                    Name = name,
                    Price = cost
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => pl.Create(new Product()
                {
                    Name = name,
                    Price = cost
                }), Throws.Exception);
            }
        }

    }
}
