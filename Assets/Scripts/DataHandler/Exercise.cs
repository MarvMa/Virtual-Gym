using System;

namespace DataHandler
{
    /// <summary>
    /// Class which stores different informations of a Exercise
    /// </summary>
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

    /// <summary>
    /// Wrapper works as a Helper for the Deserialization
    /// </summary>
    [Serializable]
    public class JsonWrapper
    {
        public Exercise[] Exe { get; set; }
    }
}
