﻿namespace VacationMachine
{
    public class SlackerEmployee : Employee
    {
        private readonly IEmailSender _emailSender;

        public SlackerEmployee(
            IEmailSender emailSender
        )
        {
            _emailSender = emailSender;
        }

        public override IRequestResult RequestPaidDaysOff(int days)
        {
            return new DeniedRequestResult(_emailSender);
        }
    }
}
