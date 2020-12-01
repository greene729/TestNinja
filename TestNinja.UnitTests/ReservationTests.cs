﻿using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_MadeByIsCancellingUserNotAdmin_ReturnsTrue()
        {
            //Arrange
            var user = new User {IsAdmin = false};
            var reservation = new Reservation {MadeBy = user};

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_MadeByIsNotCancellingUserNotAdmin_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation {MadeBy = new User()};

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
