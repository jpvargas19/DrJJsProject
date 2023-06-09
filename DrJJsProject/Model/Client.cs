﻿using System;
namespace DrJJsProject.Model
{
    public class Client //defining a new class called "Client"
    {
        private static int autoIncrement; //declares a static field
        public int Id { get; set; } //declaring a public property and sets a "setter and getter"
        public string Username { get; set; } //declaring a public property and sets a "setter and getter"
        public string Password { get; set; } //declaring a public property and sets a "setter and getter"
        public string FirstName { get; set; } //declaring a public property and sets a "setter and getter"
        public string LastName { get; set; } //declaring a public property and sets a "setter and getter"

        public Client() //declaring a public constructor for the Client class
        {
            autoIncrement++; //increaments the static field "autoIncreament" by 1
            Id = autoIncrement; //assigns value to autoIncreament 
        }
    }
}

