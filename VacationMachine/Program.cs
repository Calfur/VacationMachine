﻿using System;

namespace VacationMachine
{
    public class Program
    {
        private static void Main()
        {
            var vacationService = new VacationService(
                new VacationDatabase(
                    new EmailSender()
                )
            );

            var result = vacationService.RequestPaidDaysOff(3, 1);

            Console.WriteLine($"Vacation is: {result}");
            Console.ReadKey();
        }
    }
}
