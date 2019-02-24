using System;
using System.IO;
using System.Windows.Forms;

namespace CompanyWorkerEdit {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
        }

        string[] fileList = Directory.GetFiles(@".\WORKERS\", "*.txt");

        private void loadThreeWorkers(object sender, EventArgs e) {
            try {
                foreach (string worker in this.fileList) {
                    Console.WriteLine(Path.GetFileName(worker));
                    workerListBox.Items.Add(Worker.open(Path.GetFileName(worker).Substring(0, 11)));
                }
            } catch (Exception) {
                throw;
            }
        }


        private void editButtonClick(object sender, EventArgs e) {
            EditEmployeeWindow editWindow = new EditEmployeeWindow(this);

            if (workerListBox.SelectedItem != null) {
                editWindow.Edit(workerListBox.SelectedItem as Worker);
                editWindow.ShowDialog();
            }
        }
    }
}
