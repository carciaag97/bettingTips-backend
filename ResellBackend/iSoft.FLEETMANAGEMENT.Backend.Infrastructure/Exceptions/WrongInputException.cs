﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Exceptions
{
    public class WrongInputException : Exception
    {
        public WrongInputException(string message) : base(message)
        {

        }
    }
}
