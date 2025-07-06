using System;
using System.Linq;

namespace Pokemon_Utility.Controllers;

public class SortingButtonController
{
    
    // Method to sort the 2D array by name
    public static string[,] SortingByName(string[,] pokemonList)
    {
        return SortArray(pokemonList, 1); // Sort by name (index 1)
    }

    // Method to sort the 2D array by ID
    public static string[,] SortingById(string[,] pokemonList)
    {
        return SortArray(pokemonList, 0); // Sort by ID (index 0)
    }

    // Helper method to sort the array by a specified column index
    private static string[,] SortArray(string[,] pokemonList, int columnIndex)
    {
        // Get the length of the second dimension 
        int numColumns = pokemonList.GetLength(1);

        // Sort the array by the values 
        var sortedList = Enumerable.Range(0, pokemonList.GetLength(0))
            .Select(i => new
            {
                Id = pokemonList[i, 0],
                Name = pokemonList[i, 1],
                Type1 = pokemonList[i, 2],
                Type2 = pokemonList[i, 3]
            })
            .OrderBy(item => columnIndex == 0 ? item.Id : item.Name, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        // Update the original array with the sorted values
        for (int i = 0; i < sortedList.Length; i++)
        {
            pokemonList[i, 0] = sortedList[i].Id;
            pokemonList[i, 1] = sortedList[i].Name;
            pokemonList[i, 2] = sortedList[i].Type1;
            pokemonList[i, 3] = sortedList[i].Type2;
        }

        return pokemonList;
    }
}