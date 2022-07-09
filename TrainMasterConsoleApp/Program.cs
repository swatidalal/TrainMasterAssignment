using TrainMaster.Data.Models;
using TrainsClassLibraryFile;

namespace TrainMasterConsoleApp
    {
    public class Program
    {
        public static void Main(string[] args)
        {
            CRUDForTrainMaster cRUDForTrainMaster = new CRUDForTrainMaster();
            //List<DaysOnWhichEveryTrainRun> daysOnWhichEveryTrainRun = new List<DaysOnWhichEveryTrainRun>();
            //daysOnWhichEveryTrainRun.Add(new DaysOnWhichEveryTrainRun { TrainRunDays = "saturday" });
            //Train train = new Train
            //{
            //    TrainNo = 87654,
            //    TrainName = "KanyaKumari Express",
            //    FromStation = "Mumbai",
            //    ToStation = "Kasmir",
            //    JourneyStartTime = new TimeSpan(2, 30, 00),
            //    JourneyEndTime = new TimeSpan(6, 00, 00),
            //    DaysOnWhichEveryTrainRuns = daysOnWhichEveryTrainRun
            //};

            //cRUDForTrainMaster.AddTrains(train);

            //List<DaysOnWhichEveryTrainRun> daysOnWhichEveryTrainRun2 = new List<DaysOnWhichEveryTrainRun>();
            //daysOnWhichEveryTrainRun2.Add(new DaysOnWhichEveryTrainRun { TrainRunDays = "Sunday" });
            //daysOnWhichEveryTrainRun2.Add(new DaysOnWhichEveryTrainRun { TrainRunDays = "Friday" });
            //Train traintwo = new Train
            //{
            //    TrainNo = 100098,
            //    TrainName = "Shatabdi Express",
            //    FromStation = "Delhi",
            //    ToStation = "Jaipur",
            //    JourneyStartTime = new TimeSpan(10,00, 00),
            //    JourneyEndTime = new TimeSpan(03, 30, 00),
            //    DaysOnWhichEveryTrainRuns = daysOnWhichEveryTrainRun2
            //};
            //cRUDForTrainMaster.AddTrains(traintwo);

            //cRUDForTrainMaster.SearchTrainFrom_to_station("Delhi", "Jaipur");

            //cRUDForTrainMaster.DeleteTrain(87654);

            //cRUDForTrainMaster.SearchTrainFrom_to_station("Mumbai", "Kasmir");

            //cRUDForTrainMaster.TrainSearchByTrainNumber(102090);

            //cRUDForTrainMaster.UpdateTrain(102030, train);

            cRUDForTrainMaster.TrainSearchByTrainNumberWithDay(100098);


            Console.WriteLine("Done!!!!");
            Console.ReadLine();
        }
    }
}
