﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace SuperBowlWeb.Models.DateConversion
{
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
            timeOnly=>timeOnly.ToTimeSpan(),
            timeSpan=> TimeOnly.FromTimeSpan(timeSpan)
            )
        {
        }
    }
}
