﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public enum CoffeeMachineType
    {
        None = 0,
        Drip = 1,
        PourOver = 2,
        SingleServeCapsule = 3,
        AeroPress = 4,
        ColdBrew = 5,
        GrindAndBrew = 6,
        Siphon = 7,
        Percolator = 8
    }
}