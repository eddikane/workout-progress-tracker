
// Creates a workout object to hold all added exercises
Workout workout = new Workout(); 

// Stores the user's menu selection in varaibale "choice" 
// Starting at 0 allows the while loop to begin.
int choice = 0;

// Keep displaying the menu until the user chooses option 6.
while (choice != 6)
{
    Console.WriteLine("--------------------------");
    Console.WriteLine("WORKOUT PROGRESS TRACKER");
    Console.WriteLine("--------------------------");
    Console.WriteLine("1. Add Exercise");
    Console.WriteLine("2. View Workout");
    Console.WriteLine("3. View Workout Volume");
    Console.WriteLine("4. Save Workout");
    Console.WriteLine("5. Load Workout");
    Console.WriteLine("6. Exit");
    Console.WriteLine("--------------------------");

    // Checks to make sure input is a number.
    // Keeps prompting the user to enter a valid number if not.    
    Console.WriteLine();
    Console.WriteLine("Choose an option: ");
    Console.WriteLine();
    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid input. Please enter a valid number for choice: ");
    }
    
    

    switch (choice)
    {
        case 1:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Add Exercise selected!");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            // Get the exercise name from the user.
            Console.WriteLine("Enter Exercise Name: ");
            string exerciseName = Console.ReadLine()!;
            Console.WriteLine();

            // TryParse prevents the program from crashing if
            // the user enters something that is not an integer.
            int weight;
            Console.WriteLine("Enter Weight: ");
            while (!int.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for weight: ");
            }
            Console.WriteLine();

            // Prompts user to inputer number of sets
            Console.WriteLine("Enter Sets: ");
            int sets;
            while (!int.TryParse(Console.ReadLine(), out sets))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for sets: ");
            }
            Console.WriteLine();

            // Prompts user to input number of reps
            Console.WriteLine("Enter Reps: ");
            int reps;
            while (!int.TryParse(Console.ReadLine(), out reps))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for reps: ");
            }
            Console.WriteLine();

            // Creates a new Exercise object using the information entered.
            Exercise exercise = new Exercise(exerciseName, weight, sets, reps);

            // Stores the new exercise inside the current workout.
            workout.Exercises.Add(exercise);

            // Prints the exercise 
            Console.WriteLine("Exercise Added - ");
            Console.WriteLine($"{exerciseName}: {weight}lbs - {sets} sets x {reps} reps.");
            break;
    
        case 2:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("View Workout Selected!");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            // Checks if any exercises have been added.
            if (workout.Exercises.Count == 0)
            {
                Console.WriteLine("No exercises have been added yet.");
            }
            else
            {
                // Displays every Exercise object stored in the workout.
                foreach (Exercise i in workout.Exercises)
                {
                    Console.WriteLine($"{i.Name}: {i.Weight}lbs - {i.Sets} sets x {i.Reps} reps");
                }
            }
            break;

        case 3:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("View Workout Volume Selected");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            if (workout.Exercises.Count == 0)
            {
                Console.WriteLine("No exercises have been added yet.");
            }
            else
            {
                // Each Exercise calculates its own volume.
                foreach (Exercise i in workout.Exercises)
                {
                    int volume = i.GetVolume();
                    Console.WriteLine($"{i.Name}: {volume} lbs");
                }

                // The Workout object calculates the combined volume of all Exercise objects.
                int totalVolume = workout.GetTotalVolume();

                Console.WriteLine();
                Console.WriteLine($"Total Workout Volume: {totalVolume} lbs");
            }
            break;

        case 4:
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            if (workout.Exercises.Count == 0)
            {
                Console.WriteLine("No exercises to save.");
            }
            else
            {
                // StreamWriter creates workout.txt and writes each exercise to its own line. 
                using (StreamWriter writer = new StreamWriter("workout.txt"))
                {
                    foreach (Exercise i in workout.Exercises)
                    {
                        writer.WriteLine($"{i.Name},{i.Weight},{i.Sets},{i.Reps}");
                    } 
                }
                Console.WriteLine("Workout saved successfully!");
                Console.WriteLine("--------------------------");
            }
            break;
            

        case 5:
            Console.WriteLine();
            Console.WriteLine("--------------------------");

            // Make sure a saved workout exists before trying to read it.
            if (!File.Exists("workout.txt"))
            {
                Console.WriteLine("No saved workout file found.");
            }
            else
            {
                // Read every line from the saved workout file.
                string[] lines = File.ReadAllLines("workout.txt");

                // Remove the current exercises so loading the same
                // file does not create duplicates.
                workout.Exercises.Clear();

                foreach (string line in lines)
                {
                    // Separate the saved values using commas.
                    string[] parts = line.Split(',');
                    
                    // A valid saved exercise should contain four variables.
                    if (parts.Length == 4)
                    {
                        string name = parts[0];

                        // Converts the saved numeric strings back into ints.
                        if (int.TryParse(parts[1], out int loadedWeight) && int.TryParse(parts[2], out int loadedSets) && int.TryParse(parts[3], out int loadedReps))
                        {
                            // Recreate the exercise object from the file.
                            Exercise loadedExercise = new Exercise(name, loadedWeight, loadedSets, loadedReps);
                            workout.Exercises.Add(loadedExercise);
                        }
                    }
                }

            Console.WriteLine("Workout loaded successfully.");
            Console.WriteLine("--------------------------");
            }

            break;


        case 6:
            Console.WriteLine();
            Console.WriteLine("Exit Selected!");
            break;

        default:
            Console.WriteLine("Invalid Input. Please choose from options 1-6.");
            break;
    }

    // Pause before returning to the menu.
    // Does not display this message when the user chooses Exit.
    if (choice != 6)
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();

        // Clears the previous output before displaying the menu again.
        Console.Clear();
    }
}



