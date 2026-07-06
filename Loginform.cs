namespace attendence;

public partial class Loginform : Form
{
    public Loginform()
    {
        InitializeComponent();
    }
    private void Login_Click(object? sender, EventArgs e)
    {
    //    string id = empId.Text;
    //    string password = pwd.Text;
    //    if (id == "" || password == "")
    // {
    //     MessageBox.Show("Please enter Employee ID and Password.");
    //     return;
    // }
      
    Excel file = new Excel();

  bool loginSuccess = file.openFile(empId.Text, pwd.Text);

if (loginSuccess)
{
    Dashboard dashboard = new Dashboard(empId.Text);

    dashboard.Show();

    this.Hide();
}
else
{
    MessageBox.Show("Invalid Employee ID or Password");
}
}
}
