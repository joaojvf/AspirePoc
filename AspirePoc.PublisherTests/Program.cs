﻿using AspirePoc.Core.Entities;
using EasyNetQ;

using (var bus = RabbitHutch.CreateBus("amqp://guest:guest@localhost:5672/"))
{
    var id = 4;
    var input = string.Empty;
    Console.WriteLine("Enter a CategoryName. 'Quit' to quit.");
    while ((input = Console.ReadLine()) != "Quit")
    {
        bus.PubSub.Publish<Category>(new() { Id = id++, Name = input! });

        Console.WriteLine("Message published!");
    }
}