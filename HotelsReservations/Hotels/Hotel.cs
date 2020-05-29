using System;
using System.Collections.Generic;
using System.Text;

namespace HotelsReservations.Hotels
{
    public class Hotel
    {
        public const int MAX_ROOMS = 1000;
        public const int MAX_DAYS = 365;

        const int ROOM_NOT_FOUND = -1;

        public int Size { get; private set; }
        public int NumberOfDays { get; private set; }

        // matrix that represents [rooms x days] reservation state, field value being FALSE if free, and TRUE if reserved
        public bool[,] Schedule { get; private set; }

        public Hotel() : this(MAX_ROOMS, MAX_DAYS) { }

        public Hotel(int size, int days)
        {
            this.Size = size;
            this.NumberOfDays = days;
            Schedule = new bool[Size, NumberOfDays];
        }

        public bool Reserve(int startDay, int endDay)
        {
            // check parameters validity
            if (!IsTimeSpanValid(startDay, endDay)) return false;

            int freeRoom = GetFreeRoomNumberWithMaxUtilization(startDay, endDay);
            if (freeRoom == ROOM_NOT_FOUND) return false;

            // mark schedule slots as reserved
            for (int i = 0; startDay + i <= endDay; i++)
            {
                Schedule[freeRoom, startDay + i] = true;
            }
            return true;
        }

        // helper method for schedule preview in console
        public void Print()
        {
            for(int i=0; i < Size; i++)
            {
                for (int j = 0; j < NumberOfDays; j++)
                {
                    Console.Write(Schedule[i, j] ? "X " : "0 ");
                }
                Console.WriteLine();
            }
        }

        // Test Case 5 expected behaviour made me assume that the algorithm should favour 
        // making adjacent booked slots if possible
        private int GetFreeRoomNumberWithMaxUtilization(int startDay, int endDay)
        {
            int freeRoom = ROOM_NOT_FOUND;
            // best room option is a room time slot that is surrounded by adjacent bookings on both sides
            int bestRoomOption = ROOM_NOT_FOUND;
            // second best option is an alternative best option that has adjacent reservation on at least one side
            int secondBestOption = ROOM_NOT_FOUND;

            for (int i = 0; i < Size; i++)
            {
                bool available = true;
                for (int j = 0; j < endDay - startDay + 1; j++)
                {
                    available &= !Schedule[i, startDay + j];
                    if (!available) break;
                }
                if (available)
                {
                    // available room is found
                    freeRoom = i;
                    // check if we can merge current booking request with existing one
                    bool leftAdjacentExists = startDay > 0 && Schedule[i, startDay - 1];
                    bool rightAdjacentExists = endDay + 1 < NumberOfDays && Schedule[i, endDay + 1];
                    if (leftAdjacentExists || rightAdjacentExists)
                    {
                        secondBestOption = i;
                        if(leftAdjacentExists && rightAdjacentExists)
                        {
                            bestRoomOption = i;
                            break;
                        }
                    }
                }
            }
            if (bestRoomOption != ROOM_NOT_FOUND) return bestRoomOption;
            if (secondBestOption != ROOM_NOT_FOUND) return secondBestOption;
            return freeRoom;
        }

        private int GetFreeRoomNumber(int startDay, int endDay)
        {
            int freeRoom = ROOM_NOT_FOUND;

            for (int i = 0; i < Size; i++)
            {
                bool available = true;
                for (int j = 0; j < endDay - startDay + 1; j++)
                {
                    available &= !Schedule[i, startDay + j];
                    if (!available) break;
                }
                if (available)
                {
                    // available room is found
                    freeRoom = i;
                    break;
                }
            }

            return freeRoom;
        }

        private bool IsTimeSpanValid(int startDay, int endDay)
        {
            return startDay >= 0 && endDay < NumberOfDays && startDay <= endDay;
        }
    }
}
