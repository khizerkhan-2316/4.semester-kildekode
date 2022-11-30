using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lektion_13___MVC.Models
{
    public class ParkingTicketMachine
    {
        private int minutesPerDkk;
        private int[] coinsToInsert;
        private int amountInserted;
        private DateTime timeNow;

        public List<int> CoinsToInsert { get; }
        public  DateTime TimeNow { get; }

        public DateTime PaidUntil { get; }

        public int AmountInserted { get; }

        public string Info { get; set; }

        public ParkingTicketMachine()
        {
            this.amountInserted = 0;
            this.timeNow = DateTime.Now;
            this.CoinsToInsert = new List<int>();
        }

        public void InsertCoin(int dkk)
        {
            this.amountInserted = dkk;
        }



    }
}