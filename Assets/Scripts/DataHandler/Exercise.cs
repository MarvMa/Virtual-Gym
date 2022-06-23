using System;

namespace DataHandler
{
    [Serializable]
    public class Exercise
    {
        public String name { get; set; }

        public String identifier { get; set; }
        public String[] muscleGroups { get; set; }
        public Difficulty difficulty { get; set; }

        public String background_infos { get; set; }

        public String execution_infos { get; set; }
    }

    [Serializable]
    public class JsonWrapper
    {
        public Exercise[] Exe { get; set; }
    }
}