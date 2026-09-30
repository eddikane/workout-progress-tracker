// Represents one exercise performed during a workout.
public class Exercise
{
    // Information stored for each exercise.
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }

    // Constructor used when creating a new Exercise object.
    public Exercise(
        string name,
        int weight,
        int sets,
        int reps
    )
    {
        Name = name;
        Weight = weight;
        Sets = sets;
        Reps = reps;
    }

    // Calculates the training volume for this exercise.
    public int GetVolume()
    {
        int volume = Weight * Sets * Reps;

        return volume;
    }
}



             




