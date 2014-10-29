namespace Computers
{
    public interface IMotherboard
    {
        /// <summary>
        /// Getting back recorded data from the Ram Memory.
        /// </summary>
        /// <returns>Previously saved data into the Ram Memory</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves data into the Ram Memory, which later can be used with the help of the LoadRamValue() Method, which will extract that
        /// data for further usege.
        /// </summary>
        /// <param name="value">Data to be saved for further usage</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Drawing with the help of the VideoCard component, can easy be done if plugged a User Interface Component.
        /// </summary>
        /// <param name="data">Data to be rendered on the UI Component.</param>
        void DrawOnVideoCard(string data);
    }
}
