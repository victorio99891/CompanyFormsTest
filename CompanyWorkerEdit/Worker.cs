using System.IO;

namespace CompanyWorkerEdit {
    public class Worker {
        private string name;
        private string surname;
        private string PESEL;
        private string street;
        private string city;
        private string position;
        private int salary;

        public Worker() {
        }

        public Worker(string name, string surname, string PESEL, string street, string city, string position,
            int salary) {
            this.name = name;
            this.surname = surname;
            this.PESEL = PESEL;
            this.street = street;
            this.city = city;
            this.position = position;
            this.salary = salary;
        }

        public void save() {
            string directoryPath = @".\WORKERS";
            string fileName = @".\WORKERS\" + PESEL + ".txt";

            if (!Directory.Exists(directoryPath)) {
                DirectoryInfo newDirectory = Directory.CreateDirectory(directoryPath);
            }
            using (StreamWriter writer = new StreamWriter(fileName)) {
                writer.WriteLine(this.Name);
                writer.WriteLine(this.Surname);
                writer.WriteLine(this.Pesel);
                writer.WriteLine(this.Street);
                writer.WriteLine(this.City);
                writer.WriteLine(this.Position);
                writer.WriteLine(this.Salary);
            };

        }

        public static Worker open(string pesel) {

            string fileName = @".\WORKERS\" + pesel + ".txt";
            StreamReader reader = new StreamReader(fileName);

            Worker tmpWorker = new Worker();

            tmpWorker.Name = reader.ReadLine();
            tmpWorker.Surname = reader.ReadLine();
            tmpWorker.Pesel = reader.ReadLine();
            tmpWorker.Street = reader.ReadLine();
            tmpWorker.City = reader.ReadLine();
            tmpWorker.Position = reader.ReadLine();
            tmpWorker.salary = int.Parse(reader.ReadLine());

            reader.Close();
            return tmpWorker;
        }

        public override string ToString() {
            return Name + " " + Surname;
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public string Surname {
            get => surname;
            set => surname = value;
        }

        public string Pesel {
            get => PESEL;
            set => PESEL = value;
        }

        public string Street {
            get => street;
            set => street = value;
        }

        public string City {
            get => city;
            set => city = value;
        }

        public string Position {
            get => position;
            set => position = value;
        }

        public int Salary {
            get => salary;
            set => salary = value;
        }
    }
}