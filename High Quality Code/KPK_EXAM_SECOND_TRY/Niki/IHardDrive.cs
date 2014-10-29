namespace Computers
{
    public interface IHardDrive
    {
        void SaveData(int addr, string newData);

        string LoadData(int address);
        void Draw(string a); 
    }
}
