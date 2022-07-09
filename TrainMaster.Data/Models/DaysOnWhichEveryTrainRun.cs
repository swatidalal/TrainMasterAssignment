using System;
using System.Collections.Generic;

namespace TrainMaster.Data.Models
{
    public partial class DaysOnWhichEveryTrainRun
    {
        public int Id { get; set; }
        public string TrainRunDays { get; set; } = null!;
        public int TrainNo { get; set; }

        public virtual Train TrainNoNavigation { get; set; } = null!;
    }
}
