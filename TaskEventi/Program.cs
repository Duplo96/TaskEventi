using Microsoft.EntityFrameworkCore;
using System;
using TaskEventi.Models;

namespace TaskEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Gestore.getIstanza().Menu();
            
        }
    }
}


