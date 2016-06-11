using aspnet_mvc5_sample.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspnet_mvc5_sample.Models;
using System.Globalization;

namespace aspnet_mvc5_sample.Services.People
{
    public class PeopleService : IPeopleService
    {
        private static readonly CultureInfo ci = new CultureInfo("en-US");

        public IEnumerable<Person> GetPeopleByName(string name)
        {
            var data = GetData();

            var result = data.Where(c => c.Name.StartsWith(name, ignoreCase: true, culture: ci));

            return result;
        }

        private static IEnumerable<Person> GetData()
        {
            var data = new List<Person>() {
                new Person() {Id = 0,Name="Alice",Email="Alice@example.com",Birthday=new DateTime(1990,1,1).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 1,Name="Amanda",Email="Amanda@example.com",Birthday=new DateTime(1991,2,2).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 2,Name="Avril",Email="Avril@example.com",Birthday=new DateTime(1992,3,3) .ToString("MM/dd/yyyy",ci)},
                new Person() {Id = 3,Name="Betty",Email="Betty@example.com",Birthday=new DateTime(1993,4,4) .ToString("MM/dd/yyyy",ci)},
                new Person() {Id = 4,Name="Cherie",Email="Cherie@example.com",Birthday=new DateTime(1994,5,5).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 5,Name="Diana",Email="Diana@example.com",Birthday=new DateTime(1995,6,6).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 6,Name="Dorothy",Email="Dorothy@example.com",Birthday=new DateTime(1996,7,7).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 7,Name="Ellen",Email="Ellen@example.com",Birthday=new DateTime(1997,8,8) .ToString("MM/dd/yyyy",ci)},
                new Person() {Id = 8,Name="Hanna",Email="Hanna@example.com",Birthday=new DateTime(1998,9,9).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 9,Name="Juliette",Email="Juliette@example.com",Birthday=new DateTime(1999,10,12) .ToString("MM/dd/yyyy",ci)},

                new Person() {Id = 10,Name="Alicia",Email="Alicia@example.com",Birthday=new DateTime(1995,3,4).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 11,Name="Alison",Email="Alison@example.com",Birthday=new DateTime(1992,6,7).ToString("MM/dd/yyyy",ci) },
                new Person() {Id = 12,Name="Allyn",Email="Allyn@example.com",Birthday=new DateTime(1998,12,21).ToString("MM/dd/yyyy",ci) },

            };
            return data;
        }
    }
}