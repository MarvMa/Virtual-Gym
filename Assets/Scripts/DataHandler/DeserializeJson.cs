using System.Collections.Generic;

namespace DataHandler
{
    /// <summary>
    /// Interface which hold methods for the Deserialization of JSON files
    /// </summary>
    public interface DeserializeJson
    {
        Exercise _exercise(string path);
        List<Exercise> _exercises(string path);

        TrainingPlan _trainingPlan(string path);
        List<TrainingPlan> _trainingPlans(string path);
    }
}