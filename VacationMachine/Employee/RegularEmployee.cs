﻿using VacationMachine.Domain;

namespace VacationMachine.Business
{
    public class RegularEmployee : Employee
    {
        public override EmployeeRole Role => EmployeeRole.Regular;

        private readonly IMessageBus _messageBus;
        private readonly IEmailSender _emailSender;

        public RegularEmployee(
            IMessageBus messageBus,
            IEmailSender emailSender
        )
        {
            _messageBus = messageBus;
            _emailSender = emailSender;
        }

        public override IVacationRequest RequestPaidDaysOff(int days)
        {
            if (DaysSoFar + days <= Configuration.MAX_DAYS)
            {
                return new ApprovedVacationRequest(this, _messageBus, days);
            }
            return new DeniedVacationRequest(this, _emailSender);
        }
    }
}
