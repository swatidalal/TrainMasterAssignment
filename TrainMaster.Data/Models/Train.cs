using System;
using System.Collections.Generic;

namespace TrainMaster.Data.Models
{
    public partial class Train
    {
        public Train()
        {
            DaysOnWhichEveryTrainRuns = new HashSet<DaysOnWhichEveryTrainRun>();
        }

        public int Id { get; set; }
        public int TrainNo { get; set; }
        public string TrainName { get; set; } = null!;
        public string FromStation { get; set; } = null!;
        public string ToStation { get; set; } = null!;
        public TimeSpan JourneyStartTime { get; set; }
        public TimeSpan JourneyEndTime { get; set; }

        public virtual ICollection<DaysOnWhichEveryTrainRun> DaysOnWhichEveryTrainRuns { get; set; }
    }
}
