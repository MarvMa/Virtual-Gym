using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataHandler
{
    /**
     * entity for ORM
     */
    public class TrainingPlan
    {
        public string name { get; set; }
        public InnerExercise[] exercises { get; set; }
        public Difficulty difficulty { get; set; }
        public int duration { get; set; }
    }

    public class InnerExercise
    {
        public string exerciseName { get; set; }
        public int exerciseDifficulty { get; set; }
    }

}