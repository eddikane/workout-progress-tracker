using System.Reflection.Metadata.Ecma335;

public class Exercise
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public Exercise(string name, int weight, int sets, int reps)
    {
        Name = name;
        Weight = weight;
        Sets = sets;
        Reps = reps;
    }

    public int GetVolume()
    {
        int volume = Weight * Sets * Reps;
        return volume;
    }

}



             




