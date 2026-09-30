// Represents one workout containing multiple exercises.
public class Workout
{
    // Stores all Exercise objects belonging to this workout.
    public List<Exercise> Exercises { get; set; }

    // Create an empty exercise list whenever a new Workout is created.
    public Workout()
    {
        Exercises = new List<Exercise>();
    }

    // Calculates the combined volume of every exercise in the workout.
    public int GetTotalVolume()
    {
        int totalVolume = 0;

        foreach (Exercise i in Exercises)
        {
            // Ask each Exercise object to calculate its own volume.
            totalVolume += i.GetVolume();
        }

        return totalVolume;
    }
}
