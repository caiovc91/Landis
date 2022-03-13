using Landis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Landis.Models;
using Landis.Interface;
using Landis.Controller;


namespace LandisTest
{
    [TestClass]
    public class LandisTests
    {
        //Create
        [TestMethod]
        public void CanInsertEndpoint()
        {
            //Arrange
            var endpoint = new Endpoint() { firmware_version = "banana",
                                            MeterModel = new MeterModel(32),
                                            meter_number = 2224444,
                                            serial_number = "1",
                                            switch_state = 0
                                           };
            //Act
            BaseController b = new BaseController();
            b.Insert(endpoint);

                
            //Assert
            Assert.IsTrue(int.Parse(endpoint.serial_number) > 4);
        }

        //Retrieve
        [TestMethod]
        public void CanFindEndpoint()
        {
            //Arrange
            var endpoint_find_serial = "3";

            //Act
            try
            {
                BaseController b = new BaseController();
                b.Find(endpoint_find_serial);
                return;
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Fail(ex.Message);
            }
        }

        //Update
        [TestMethod]
        public void CanUpdateEndpointSwitchState()
        {
            //Arrange
            var switch_state = 2;
            var serial_number = "3";

            //Act
            BaseController b = new BaseController();
            var found = b.Find(serial_number);
            found.switch_state = switch_state;
            var found_again = b.Find(serial_number);


            //Assert
            Assert.IsNotNull(found);
            Assert.AreEqual(found_again.switch_state, found);
        }

        //Delete
        [TestMethod]
        public void CanDeleteEndpoint()
        {
            //Arrange
            var endpoint_serial = "3";

            //Act
            BaseController bc = new BaseController();
            var endpoint = bc.Find(endpoint_serial);
            bc.Delete(endpoint.serial_number);
            var missing_endpoint = bc.Find(endpoint.serial_number);
            //Assert
            Assert.IsNull(missing_endpoint);
        }

    }
}
