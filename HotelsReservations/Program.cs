using HotelsReservations.Hotels;
using System;

namespace HotelsReservations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Insert number of rooms and days for hotel: ");
                string[] tokens = Console.ReadLine().Split();
                if (tokens.Length < 2 || !int.TryParse(tokens[0], out int size) || !int.TryParse(tokens[1], out int days)) break;

                if (size < 1 || days < 1 || size > Hotel.MAX_ROOMS || days > Hotel.MAX_DAYS)
                {
                    Console.WriteLine("Numbers of rooms and days must be positive integers, number of rooms being " +
                        $"{Hotel.MAX_ROOMS} max, and number of days being " +
                        $"{Hotel.MAX_DAYS} max\n");
                    continue;
                }

                Hotel hotel = new Hotel(size, days);
                HandleRoomReservationsForHotel(hotel);
            }
        }
        private static void HandleRoomReservationsForHotel(Hotel hotel)
        {
            while (true)
            {
                hotel.Print();
                Console.Write("Insert start and end day for booking: ");
                string[] bookingDays = Console.ReadLine().Split();
                if (bookingDays.Length < 2 || !int.TryParse(bookingDays[0], out int start) || !int.TryParse(bookingDays[1], out int end)) break;
                bool success = hotel.Reserve(start, end);
                Console.WriteLine(success ? "\nAccepted\n" : "\nDeclined\n");
            }
        }
    }
}
