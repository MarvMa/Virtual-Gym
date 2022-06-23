namespace DataHandler
{
    public interface DeserializeJson
    {
        Exercise _exercise(string path);
        Exercise[] _exercises(string path);

        TrainingPlan _trainingPlan(string path);
        TrainingPlan[] _trainingPlans(string path);
    }
}