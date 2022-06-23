using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DeserializeJson
{
    Exercise _exercise(string path);

    TrainingPlan _trainingPlan(string path);
}

