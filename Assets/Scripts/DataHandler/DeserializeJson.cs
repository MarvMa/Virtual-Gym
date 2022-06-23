using System.Collections.Generic;

namespace DataHandler
{
    public interface DeserializeJson
    {
        Exercise _exercise(string path);
        List<Exercise> _exercises(string path);

        TrainingPlan _trainingPlan(string path);
        List<TrainingPlan> _trainingPlans(string path);
    }
}