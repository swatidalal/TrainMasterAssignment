using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainMaster.Data.Models;

namespace TrainsClassLibraryFile
{
    public class CRUDForTrainMaster
    {
        TrainMasterContext trainMasterContext;
        public CRUDForTrainMaster()
        {
            trainMasterContext = new TrainMasterContext();

        }
        public void AddTrains(Train train)
        {
            trainMasterContext.Trains.Add(train);
            trainMasterContext.SaveChanges();
            Console.WriteLine("Train Added Successfully");

        }
        public void UpdateTrain(int TrainNumber, Train train)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == TrainNumber).FirstOrDefault();
            if (trn != null)
            {
                trn.TrainName = train.TrainName;
                trn.TrainNo = train.TrainNo;
                trn.FromStation = train.FromStation;
                trn.ToStation = train.ToStation;
                trn.JourneyStartTime = train.JourneyStartTime;
                trn.JourneyEndTime = train.JourneyEndTime;
                trainMasterContext.Trains.Update(trn);
                trainMasterContext.SaveChanges();
                Console.WriteLine("Update Successfully...");

            }
            else
            {
                Console.WriteLine(" Train Not Found With Train Number " + TrainNumber);
            }
        }
        public void DeleteTrain(int TrainNumber)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == TrainNumber).FirstOrDefault();

            if (trn != null)
            {
                trainMasterContext.Trains.Remove(trn);
                trainMasterContext.SaveChanges();

                Console.WriteLine("Train Deleted With Number :" + TrainNumber);
            }
            else
            {
                Console.WriteLine(" Train Not Found With Train Number " + TrainNumber);
            }



        }
        public void TrainSearchByTrainNumber(int Trainnumber)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == Trainnumber).FirstOrDefault();
            if (trn != null)
            {
                Console.WriteLine("Train Number             :" + trn.TrainNo);
                Console.WriteLine("Train Name               :" + trn.TrainName);
                Console.WriteLine("Train  From Station      :" + trn.FromStation);
                Console.WriteLine("Train To Station         :" + trn.ToStation);
                Console.WriteLine("Train Journey Start Time :" + trn.JourneyStartTime);
                Console.WriteLine("Train Journey End Time   :" + trn.JourneyEndTime);


            }
            else
            {
                Console.WriteLine(" Train Not Found With Train Number " + Trainnumber);


            }

        }
        public void SearchTrainFrom_to_station(string from, string to)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.FromStation == from && tr.ToStation == to).ToList();
            if (trn != null)
            {
                foreach (var tr in trn)
                {
                    Console.WriteLine("Train Number             :" + tr.TrainNo);
                    Console.WriteLine("Train Name               :" + tr.TrainName);
                    Console.WriteLine("Train  From Station      :" + tr.FromStation);
                    Console.WriteLine("Train To Station         :" + tr.ToStation);
                    Console.WriteLine("Train Journey Start Time :" + tr.JourneyStartTime);
                    Console.WriteLine("Train Journey End Time   :" + tr.JourneyEndTime);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No trains Available... from " + from + " station to " + to + " station");
            }
        }

        public void TrainSearchByTrainNumberWithDay(int Trainnumber)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == Trainnumber).Include(d => d.DaysOnWhichEveryTrainRuns).FirstOrDefault();
            if (trn != null)
            {
                Console.WriteLine("Train Number             :" + trn.TrainNo);
                Console.WriteLine("Train Name               :" + trn.TrainName);
                Console.WriteLine("Train  From Station      :" + trn.FromStation);
                Console.WriteLine("Train To Station         :" + trn.ToStation);
                Console.WriteLine("Train Journey Start Time :" + trn.JourneyStartTime);
                Console.WriteLine("Train Journey End Time   :" + trn.JourneyEndTime);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("train Available Days");
                foreach (var tr in trn.DaysOnWhichEveryTrainRuns)
                {
                    Console.WriteLine("Train Available for day :" + tr.TrainRunDays);

                }


            }
            else
            {
                Console.WriteLine(" Train Not Found With Train Number " + Trainnumber);


            }

        }
        public void AllTrainList()
        {
            var alltrn = trainMasterContext.Trains.Include(d => d.DaysOnWhichEveryTrainRuns).ToList();
            if (alltrn.Count > 0)
            {
                foreach (var tr in alltrn)
                {
                    Console.WriteLine("Train Number             :" + tr.TrainNo);
                    Console.WriteLine("Train Name               :" + tr.TrainName);
                    Console.WriteLine("Train  From Station      :" + tr.FromStation);
                    Console.WriteLine("Train To Station         :" + tr.ToStation);
                    Console.WriteLine("Train Journey Start Time :" + tr.JourneyStartTime);
                    Console.WriteLine("Train Journey End Time   :" + tr.JourneyEndTime);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Train Available for days");
                    foreach (var day in tr.DaysOnWhichEveryTrainRuns)
                    {
                        Console.WriteLine("Train Available for day :" + day.TrainRunDays);
                    }
                    Console.WriteLine();
                    Console.WriteLine();


                }

            }
        }
    }
}
