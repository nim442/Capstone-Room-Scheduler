﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class DirectoryOfReservations
    {
        private static List<Reservation> reservations { get; set; }

        public DirectoryOfReservations()
        {
            reservations = new List<Reservation>();
            reservations.Add(new Reservation(1, 1, 1, "Reservation 1", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0 ,0)));
            reservations.Add(new Reservation(2, 2, 2, "Reservation 2", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 4, 0, 0)));
            reservations.Add(new Reservation(2, 2, 2, "Reservation 3", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0)));
        }
       

        /* public DirectoryOfReservations(List<Reservation> reslist)
         {
             this.reservations = reslist;
         } */

        public int getReservationSize()
        {
            return reservations.Count;
        }

        public Reservation getReservation(int resid)
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].getReservationID() == resid)
                {
                    return reservations[i];
                }
            }
            return null;
        }

        //public void displayReservations()
        //{
        //    //this function should return a string in the future so Nim can use it
        //    string message = "The current reservations made in the system are: ";
           
        //    for (int i = 0; i < reservations.Count; i++)
        //    {

        //        Console.Write(reservations[i].getReservationUser().getFirstName() + " "); //finish this later
        //        Console.Write(reservations[i].getReservationUser().getLastName() + " reserved at: "); //finish this later
        //        Console.WriteLine(reservations[i].getReservationTimeSlot().getTimeSlotID() + ":00 "); //finish this later
                
        //        //also need the room... how to access based on our current class diagram?
        //    }
        //}

        public string makeReservation(int uid, int roomid, int timeslotid, string desc, DateTime dt)
        {
            Reservation res = new Reservation(roomid, uid, timeslotid, desc, dt);
            string s = "Reservation has been created at " + timeslotid + ":00 in room " + roomid;
            return s;
        }

        public void modifyReservation(int resid, int roomid, int timeslotid, DateTime dt, string des)
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].getReservationID() == resid)
                {
                    reservations[i].setReservationRoomID(roomid);
                    reservations[i].setReservationTimeSlotID(timeslotid);
                    reservations[i].setReservationDateTime(dt.Year, dt.Month, dt.Day, dt.Hour);
                    reservations[i].setReservationDescription(des);
                }
            }
        }
            
        public void cancelReservation(int resid)
        {
            for (int i=0; i < reservations.Count; i++)
            {
                if (reservations[i].getReservationID() == resid)
                {
                    reservations.Remove(reservations[i]); //remove reservation from list of reservations
                }
            }
        }

    }
}