using System.IO;
using System.Windows.Forms;

namespace CompanyWorkerEdit {
    public partial class EditEmployeeWindow : Form {
        public EditEmployeeWindow(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        Worker currentWorker;
        string previousPesel;
        MainWindow mainWindow;


        public void Edit(Worker worker) {
            this.editNameBox.Text = worker.Name;
            this.editSurnameBox.Text = worker.Surname;
            this.editStreetBox.Text = worker.Street;
            this.editCityBox.Text = worker.City;
            this.editPeselBox.Text = worker.Pesel;
            this.editPositionBox.Text = worker.Position;
            this.editSalaryBox.Text = worker.Salary.ToString();

            this.currentWorker = worker;
        }

        private void saveWorkerInfo(object sender, System.EventArgs e) {

            this.previousPesel = currentWorker.Pesel;

            this.currentWorker.Name = this.editNameBox.Text;
            this.currentWorker.Surname = this.editSurnameBox.Text;
            this.currentWorker.Street = this.editStreetBox.Text;
            this.currentWorker.City = this.editCityBox.Text;
            this.currentWorker.Pesel = this.editPeselBox.Text;
            this.currentWorker.Position = this.editPositionBox.Text;
            this.currentWorker.Salary = int.Parse(this.editSalaryBox.Text);
            this.currentWorker.save();

            mainWindow.workerListBox.Items[mainWindow.workerListBox.SelectedIndex] = currentWorker;

            this.updateFileList(this.currentWorker.Pesel);

            this.Close();

        }

        public void updateFileList(string currentPesel) {
            if (!this.previousPesel.Equals(currentPesel)) {
                File.Delete(@".\WORKERS\" + this.previousPesel + ".txt");
            }
        }

        private void validateIsNumber(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
