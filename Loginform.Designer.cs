namespace attendence;

partial class Loginform
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private TextBox empId;
    private TextBox pwd;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.WhiteSmoke;
        Label title = new Label();
        title.Text = "Employee Attendance Portal";
        title.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        title.AutoSize = true;
        title.Location = new Point(70, 30); //adding heading
        Controls.Add(title);

        Label EmpId = new Label();
        EmpId.Text = "Employee ID";
        EmpId.Location = new Point(70, 90);
        EmpId.AutoSize = true;
        Controls.Add(EmpId);//adding empid label
        
        empId = new TextBox();
        
        empId.Name = "txtEmpId";
        empId.Location = new Point(180, 85);
        empId.Size = new Size(180, 30);
        Controls.Add(empId);

        Label Pwd = new Label();
        Pwd.Text = "Password";
        Pwd.Location = new Point(70, 140);
        Pwd.AutoSize = true;
        Controls.Add(Pwd);

        pwd = new TextBox();
        pwd.Name = "txtpwd";
        pwd.Location = new Point(180, 135);
        pwd.Size = new Size(180, 30);
        pwd.UseSystemPasswordChar = true;
        Controls.Add(pwd);

        Button login = new Button();
        login.Text = "Login";
        login.Location = new Point(180, 200);
        login.Size = new Size(100, 35);
        login.Click += Login_Click;
        Controls.Add(login);

        Text = "Employee Attendance Portal";
    }

    #endregion
}
