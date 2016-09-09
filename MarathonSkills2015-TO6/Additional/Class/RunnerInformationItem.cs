using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills2015_TO6.Additional.Class
{
    class RunnerInformationItem
    {
        public int RunnerId { get; set; }
        public string RunnerName { get; set; }
        public int RaceTime { get; set; }
    }

    class ReportData
    {
        public string EventName { set; get; }
        public string RunnerRank { set; get; }
        public int RaceTime { get; set; }

        public ReportData(string EventName, string RunnerRank, int RaceTime)
        {
            this.EventName = EventName;
            this.RaceTime = RaceTime;
            this.RunnerRank = RunnerRank;
        }
    }

    class Combo
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
