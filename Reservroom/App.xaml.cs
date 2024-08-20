﻿using Reservroom.Exceptions;
using Reservroom.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Reservroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("SingletonSean Suites");
            try
            {
                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 3),
                    "SingletonSean",
                    new DateTime(2000, 1, 1),
                    new DateTime(2000, 1, 2)));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 2),
                    "SingletonSean",
                    new DateTime(2000, 1, 3),
                    new DateTime(2000, 1, 4)));
            }
            catch (ReservationConflictException ex) 
            {
                
            }
            IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("SingletonSean");

            base.OnStartup(e);
        }
    }

}
