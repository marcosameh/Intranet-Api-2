﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ItalianName { get; set; }

    public string GermanName { get; set; }

    public string FrenchName { get; set; }

    public string PolishName { get; set; }

    public string RussianName { get; set; }

    public string Iso2 { get; set; }

    public string Iso3 { get; set; }

    public int? CountryCode { get; set; }

    public string ArabicName { get; set; }
}