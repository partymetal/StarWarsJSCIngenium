using System.Collections.ObjectModel;
using StarWars.Interfaces;

namespace StarWars.InterfacesImpl
{
    public class CannonLoader : ICannonLoader
    {
        /// <summary>
        /// Calculates the number of cannons to be deployed to a collection of heights. 
        /// </summary>
        /// <param name="heights">A collection of heights.</param>
        /// <returns>The number of cannons.</returns>
        public int GetCannonCount(IReadOnlyList<uint> heights)
        {
            int cannons = 0;
            try
            {
                if (heights == null)
                {
                    throw new ArgumentNullException("Heights cannot be null");
                }
                if (heights.Count == 0)
                {
                    return cannons;
                }
                if (heights.Count == 1)
                {
                    return cannons;
                }
                if (isPlateau(heights))
                {
                    return cannons;
                }
                var peaks = GetPeaks(heights);
                cannons = DeployCannons(peaks);

            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return cannons;
        }

        /// <summary>
        /// A plateau is a colection of equal numbers 
        /// </summary>
        /// <param name="heights">A collection of heights.</param>
        /// <returns>True/false if it´s a plateau</returns>
        private bool isPlateau(IEnumerable<uint> heights)
        {
            bool plateau = false;
            uint value = heights.First();
            foreach (uint height in heights)
            {
                if (height == value)
                {
                    plateau = true;
                }
                else
                {
                    plateau = false;
                    break;
                }
            }
            return plateau;
        }

        /// <summary>
        /// Find the peaks in a collection
        /// </summary>
        /// <param name="heights">A collection of heights.</param>
        /// <returns>A collection of peaks with value of the index of the input collection</returns>
        private IEnumerable<uint> GetPeaks(IReadOnlyList<uint> heights)
        {
            Collection<uint> peaks = new Collection<uint>();
            for (int i = 1; i < heights.Count() - 1; i++)
            {
                if (isPeak(heights[i - 1], heights[i], heights[i + 1]))
                {
                    peaks.Add((uint)i);
                }
            }
            return peaks;
        }

        public bool isPeak(uint left, uint current, uint right)
        {
            return current > left && current > right;
        }

        /// <summary>
        /// Deploy cannons in the peaks
        /// </summary>
        /// <param name="peaks">A colecction of peaks</param>
        /// <returns>The number of cannons deployed</returns>
        private int DeployCannons(IEnumerable<uint> peaks)
        {
            int numberCannonDeployed = 0;
            int totalNumberCannons = peaks.Count();
            bool end = false;
            while (!end)
            {
                int numberCannonsLoaded = 1;
                int lastPositionCanon = (int)peaks.First();
                for (int i = 1; i < peaks.Count(); i++)
                {
                    if (DistanceCannon(lastPositionCanon, (int)peaks.ElementAt(i), totalNumberCannons) && numberCannonsLoaded < totalNumberCannons)
                    {
                        numberCannonsLoaded++;
                        lastPositionCanon = (int)peaks.ElementAt(i);
                    }
                }
                if (numberCannonsLoaded == totalNumberCannons)
                {
                    numberCannonDeployed = numberCannonsLoaded;
                    end = true;
                }
                totalNumberCannons--;
            }
            return numberCannonDeployed;
        }

        private bool DistanceCannon(int indexP, int indexQ, int cannonsToLoad)
        {
            return Math.Abs(indexP - indexQ) >= cannonsToLoad;
        }


    }
}
