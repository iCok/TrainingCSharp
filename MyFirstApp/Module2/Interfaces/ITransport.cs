﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module2.Interfaces
{
    interface ITransport
    {

        bool LoadSomeThing(int weight, out int resultWeight);
       

    }
}
