﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSalon.Models
{
    public partial class User
    {
        public string FullName
        {
            get
            {
                return $"{Surname} {Name} {Patronymic}";
            }
        }
    }
}
