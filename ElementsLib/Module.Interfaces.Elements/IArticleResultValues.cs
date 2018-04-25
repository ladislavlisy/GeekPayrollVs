﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    public interface IArticleResultValues
    {
        string Description();
        bool IsFullWeeksValue();
        bool IsPartWeeksValue();
        bool IsMonthFromStopValue();
        bool IsFullMonthValue();
        bool IsRealMonthValue();
        bool IsTermMonthValue();
    }
}
