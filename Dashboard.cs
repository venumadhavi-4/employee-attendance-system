namespace attendence;

public class Dashboard : Form
{
    string empId;
    Panel leftPanel = new Panel();
    Panel mainPanel = new Panel();
    DataGridView attendance = new DataGridView();
    Label title = new Label();

    Label duration = new Label();

    ComboBox durationBox = new ComboBox();

    Label from = new Label();

    DateTimePicker fromDate = new DateTimePicker();

    Label to = new Label();

    DateTimePicker toDate = new DateTimePicker();

    Button go = new Button();
    Label swipeTitle = new Label();

    Label swipeMsg = new Label();

    Label manager = new Label();

    TextBox managerName = new TextBox();

    Button apply = new Button();
    Label statusTitle = new Label();
    Label negativeTitle = new Label();

    Label negativeMsg = new Label();

    Label statusMsg = new Label();

    Label statusManager = new Label();

    TextBox statusManagerName = new TextBox();

    Button statusApply = new Button();
    Label avgTitle = new Label();

Button year1 = new Button();
Button year2 = new Button();

Label avgHours = new Label();
Button jan = new Button();

Button feb = new Button();
Button mar = new Button();
Button apr = new Button();
Button may = new Button();
Button jun = new Button();

Button jul = new Button();
Button aug = new Button();
Button sep = new Button();
Button oct = new Button();

Button nov = new Button();
Button dec = new Button();

string selectedYear = "";
    public Dashboard(string id)
    {
        empId = id;

        Text = "Attendance Dashboard";

        WindowState = FormWindowState.Maximized;

        BackColor = Color.White;

        createLeftPanel();

        createMainPanel();
    }
    private void showStatusUnknown()
    {
        // Hide Attendance page
        title.Visible = false;

        duration.Visible = false;
        durationBox.Visible = false;

        from.Visible = false;
        fromDate.Visible = false;

        to.Visible = false;
        toDate.Visible = false;

        go.Visible = false;

        attendance.Visible = false;

        // Hide Single Swipe page
        swipeTitle.Visible = false;
        swipeMsg.Visible = false;
        manager.Visible = false;
        managerName.Visible = false;
        apply.Visible = false;

        // Show Status Unknown page
        statusTitle.Visible = true;
    }

    private void Go_Click(object? sender, EventArgs e)
    {
        attendance.Rows.Clear();

        Excel file = new Excel();

        List<string[]> records = file.getAttendance(empId);

        for (int i = 0; i < records.Count; i++)
        {
            DateTime date = Convert.ToDateTime(records[i][0]);

            string day = date.DayOfWeek.ToString();
            string status = records[i][3];

            if (day == "Saturday" || day == "Sunday")
            {
                status = "Weekend";
            }
            TimeSpan hours = TimeSpan.Zero;

            if (records[i][1] != "" && records[i][2] != "")
            {
                DateTime inTime = Convert.ToDateTime(records[i][1]);
                DateTime outTime = Convert.ToDateTime(records[i][2]);

                hours = outTime - inTime;
            }
            attendance.Rows.Add(
             records[i][0],
             day,
             records[i][1],
             records[i][2],
             hours.ToString(@"hh\:mm"),
             status
         );
        }
    }
    private void Apply_Click(object? sender, EventArgs e)
    {
        if (managerName.Text == "")
        {
            MessageBox.Show("Please enter Manager Name");
            return;
        }

        MessageBox.Show("Single Swipe request submitted successfully.");

        swipeMsg.Text = "No Single Swipe records found.";

        manager.Visible = false;
        managerName.Visible = false;

        apply.Visible = false;
    }

    private void Swipe_Click(object? sender, EventArgs e)
    {
        // Hide Attendance page
        showSingleSwipe();

        Excel file = new Excel();

        string date = file.getSingleSwipe(empId);

        swipeTitle.Visible = true;

        if (date == "")
        {
            swipeMsg.Text = "No Single Swipe records found.";

            swipeMsg.Visible = true;

            apply.Visible = false;
            manager.Visible = false;
            managerName.Visible = false;
        }
        else
        {
            swipeMsg.Text = "Date : " + date;
            manager.Visible = true;
            managerName.Visible = true;

            swipeMsg.Visible = true;

            apply.Visible = true;
        }
    }
    private void Month_Click(object? sender, EventArgs e)
{
    if (selectedYear == "")
    {
        MessageBox.Show("Please select a year.");
        return;
    }

    Button month = (Button)sender!;

    string monthName = month.Text;

    Excel file = new Excel();

    string average = file.getAverageHours(empId, selectedYear, monthName);

    avgHours.Text = "Average Working Hours : " + average;

    avgHours.Visible = true;
}
    private void showAttendance()
    {
        avgTitle.Visible = false;

year1.Visible = false;
year2.Visible = false;

jan.Visible = false;
feb.Visible = false;
mar.Visible = false;
apr.Visible = false;
may.Visible = false;
jun.Visible = false;

jul.Visible = false;
aug.Visible = false;
sep.Visible = false;
oct.Visible = false;
nov.Visible = false;
dec.Visible = false;

avgHours.Visible = false;
        title.Visible = true;

        duration.Visible = true;
        durationBox.Visible = true;

        from.Visible = true;
        fromDate.Visible = true;

        to.Visible = true;
        toDate.Visible = true;

        go.Visible = true;

        attendance.Visible = true;

        swipeTitle.Visible = false;
        swipeMsg.Visible = false;
        manager.Visible = false;
        managerName.Visible = false;
        apply.Visible = false;
    }

    private void showSingleSwipe()
    {
        avgTitle.Visible = false;

year1.Visible = false;
year2.Visible = false;

jan.Visible = false;
feb.Visible = false;
mar.Visible = false;
apr.Visible = false;
may.Visible = false;
jun.Visible = false;

jul.Visible = false;
aug.Visible = false;
sep.Visible = false;
oct.Visible = false;
nov.Visible = false;
dec.Visible = false;

avgHours.Visible = false;
        title.Visible = false;

        duration.Visible = false;
        durationBox.Visible = false;

        from.Visible = false;
        fromDate.Visible = false;

        to.Visible = false;
        toDate.Visible = false;

        go.Visible = false;

        attendance.Visible = false;

        swipeTitle.Visible = true;
    }
    private void showNegativeHours()
    {
        avgTitle.Visible = false;

year1.Visible = false;
year2.Visible = false;

jan.Visible = false;
feb.Visible = false;
mar.Visible = false;
apr.Visible = false;
may.Visible = false;
jun.Visible = false;

jul.Visible = false;
aug.Visible = false;
sep.Visible = false;
oct.Visible = false;
nov.Visible = false;
dec.Visible = false;

avgHours.Visible = false;
        title.Visible = false;
        duration.Visible = false;
        durationBox.Visible = false;
        from.Visible = false;
        fromDate.Visible = false;
        to.Visible = false;
        toDate.Visible = false;
        go.Visible = false;
        attendance.Visible = false;

        swipeTitle.Visible = false;
        swipeMsg.Visible = false;
        manager.Visible = false;
        managerName.Visible = false;
        apply.Visible = false;

        statusTitle.Visible = false;
        statusMsg.Visible = false;
        statusManager.Visible = false;
        statusManagerName.Visible = false;
        statusApply.Visible = false;

        negativeTitle.Visible = true;
    }
    private void showAverageHours()
{
    showStatusUnknown();

    statusTitle.Visible = false;
    statusMsg.Visible = false;
    statusManager.Visible = false;
    statusManagerName.Visible = false;
    statusApply.Visible = false;

    negativeTitle.Visible = false;
    negativeMsg.Visible = false;

    avgTitle.Visible = true;

    year1.Visible = true;
    year2.Visible = true;

    jan.Visible = true;
feb.Visible = true;
mar.Visible = true;
apr.Visible = true;
may.Visible = true;
jun.Visible = true;

jul.Visible = true;
aug.Visible = true;
sep.Visible = true;
oct.Visible = true;
nov.Visible = true;
dec.Visible = true;
avgHours.Visible = true;
avgHours.Text = "Average Working Hours : 00:00";
}
private void Average_Click(object? sender, EventArgs e)
{
    showAverageHours();
}

    private void Negative_Click(object? sender, EventArgs e)
    {
        showNegativeHours();

        negativeMsg.Text = "No Negative Hours found.";

        negativeMsg.Visible = true;
    }
    private void Attendance_Click(object? sender, EventArgs e)
    {
        showAttendance();
    }
    private void Status_Click(object? sender, EventArgs e)
    {
        showStatusUnknown();

        Excel file = new Excel();

        string date = file.getStatusUnknown(empId);

        statusTitle.Visible = true;

        if (date == "")
        {
            statusMsg.Text = "No Status Unknown records found.";

            statusMsg.Visible = true;

            statusApply.Visible = false;
        }
        else
        {
            statusMsg.Text = "Date : " + date;

            statusMsg.Visible = true;

            statusManager.Visible = true;
            statusManagerName.Visible = true;

            statusApply.Visible = true;
        }
    }
    private void StatusApply_Click(object? sender, EventArgs e)
    {
        if (statusManagerName.Text == "")
        {
            MessageBox.Show("Please enter Manager Name");
            return;
        }

        MessageBox.Show("Status Unknown request submitted successfully.");

        statusMsg.Text = "No Status Unknown records found.";

        statusManager.Visible = false;
        statusManagerName.Visible = false;

        statusApply.Visible = false;
    }
    private void Year1_Click(object? sender, EventArgs e)
{
    selectedYear = "2024-2025";
}
private void Year2_Click(object? sender, EventArgs e)
{
    selectedYear = "2025-2026";
}
    private void createLeftPanel()
    {
        leftPanel.Width = 300;
        leftPanel.Dock = DockStyle.Left;
        leftPanel.BackColor = Color.FromArgb(15, 54, 120);

        Controls.Add(leftPanel);
        Label menu = new Label();

        menu.Text = "Attendance Portal";
        menu.ForeColor = Color.White;
        menu.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        menu.Location = new Point(30, 40);
        menu.AutoSize = true;

        leftPanel.Controls.Add(menu);
        Button attendance = new Button();
        attendance.Click += Attendance_Click;
        attendance.Text = "Attendance Records";
        attendance.Location = new Point(0, 120);
        attendance.Size = new Size(300, 55);

        attendance.FlatStyle = FlatStyle.Flat;
        attendance.FlatAppearance.BorderSize = 0;

        attendance.BackColor = Color.FromArgb(15, 54, 120);
        attendance.ForeColor = Color.White;


        attendance.Font = new Font("Segoe UI", 11);

        attendance.TextAlign = ContentAlignment.MiddleLeft;

        attendance.Padding = new Padding(20, 0, 0, 0);

        attendance.Cursor = Cursors.Hand;

        leftPanel.Controls.Add(attendance);

        Button swipe = new Button();
        swipe.Click += Swipe_Click;
        swipe.Text = "Single Swipe";
        swipe.Location = new Point(0, 175);
        swipe.Size = new Size(300, 55);

        swipe.FlatStyle = FlatStyle.Flat;
        swipe.FlatAppearance.BorderSize = 0;

        swipe.BackColor = Color.FromArgb(15, 54, 120);
        swipe.ForeColor = Color.White;

        swipe.Font = new Font("Segoe UI", 11);

        swipe.TextAlign = ContentAlignment.MiddleLeft;
        swipe.Padding = new Padding(20, 0, 0, 0);

        swipe.Cursor = Cursors.Hand;

        leftPanel.Controls.Add(swipe);
        Button status = new Button();
        status.Click += Status_Click;
        status.Text = "Status Unknown";
        status.Location = new Point(0, 230);
        status.Size = new Size(300, 55);

        status.FlatStyle = FlatStyle.Flat;
        status.FlatAppearance.BorderSize = 0;

        status.BackColor = Color.FromArgb(15, 54, 120);
        status.ForeColor = Color.White;

        status.Font = new Font("Segoe UI", 11);

        status.TextAlign = ContentAlignment.MiddleLeft;
        status.Padding = new Padding(20, 0, 0, 0);

        status.Cursor = Cursors.Hand;

        leftPanel.Controls.Add(status);
        Button negative = new Button();
        negative.Click += Negative_Click;
        negative.Text = "Negative Hours";
        negative.Location = new Point(0, 285);
        negative.Size = new Size(300, 55);

        negative.FlatStyle = FlatStyle.Flat;
        negative.FlatAppearance.BorderSize = 0;

        negative.BackColor = Color.FromArgb(15, 54, 120);
        negative.ForeColor = Color.White;

        negative.Font = new Font("Segoe UI", 11);

        negative.TextAlign = ContentAlignment.MiddleLeft;
        negative.Padding = new Padding(20, 0, 0, 0);

        negative.Cursor = Cursors.Hand;

        leftPanel.Controls.Add(negative);
        Button average = new Button();
        average.Click += Average_Click;
        average.Text = "Average Hours";
        average.Location = new Point(0, 340);
        average.Size = new Size(300, 55);

        average.FlatStyle = FlatStyle.Flat;
        average.FlatAppearance.BorderSize = 0;

        average.BackColor = Color.FromArgb(15, 54, 120);
        average.ForeColor = Color.White;

        average.Font = new Font("Segoe UI", 11);

        average.TextAlign = ContentAlignment.MiddleLeft;
        average.Padding = new Padding(20, 0, 0, 0);

        average.Cursor = Cursors.Hand;

        leftPanel.Controls.Add(average);
        Button logout = new Button();

        logout.Text = "Logout";

        logout.Dock = DockStyle.Bottom;
        logout.Height = 55;

        logout.FlatStyle = FlatStyle.Flat;
        logout.FlatAppearance.BorderSize = 0;

        logout.BackColor = Color.FromArgb(15, 54, 120);
        logout.ForeColor = Color.White;

        logout.Font = new Font("Segoe UI", 11);

        logout.TextAlign = ContentAlignment.MiddleLeft;
        logout.Padding = new Padding(20, 0, 0, 0);

        logout.Cursor = Cursors.Hand;

        leftPanel.Controls.Add(logout);

    }

    private void createMainPanel()
    {

        mainPanel.Location = new Point(300, 0);
        mainPanel.Size = new Size(1200, 900);

        mainPanel.BackColor = Color.WhiteSmoke;

        Controls.Add(mainPanel);
        title = new Label();

        title.Text = "Attendance Records";
        title.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        title.Location = new Point(60, 30);
        title.AutoSize = true;

        mainPanel.Controls.Add(title);
        duration = new Label();

        duration.Text = "Duration";
        duration.Location = new Point(60, 90);
        duration.AutoSize = true;

        mainPanel.Controls.Add(duration);

        durationBox = new ComboBox();

        durationBox.Location = new Point(150, 85);
        durationBox.Size = new Size(150, 30);

        durationBox.Items.Add("Weekly");
        durationBox.Items.Add("Monthly");
        durationBox.SelectedIndex = 0;

        mainPanel.Controls.Add(durationBox);
        from = new Label();

        from.Text = "From Date";
        from.Location = new Point(370, 90);
        from.AutoSize = true;

        mainPanel.Controls.Add(from);

        fromDate = new DateTimePicker();

        fromDate.Location = new Point(470, 85);
        fromDate.Size = new Size(180, 30);

        mainPanel.Controls.Add(fromDate);
        to = new Label();

        to.Text = "To Date";
        to.Location = new Point(700, 90);
        to.AutoSize = true;

        mainPanel.Controls.Add(to);

        toDate = new DateTimePicker();

        toDate.Location = new Point(770, 85);
        toDate.Size = new Size(180, 30);

        mainPanel.Controls.Add(toDate);
        go = new Button();

        go.Text = "GO";

        go.Location = new Point(1000, 85);
        go.Size = new Size(80, 35);
        go.Click += Go_Click;

        mainPanel.Controls.Add(go);
        attendance = new DataGridView();

        attendance.Location = new Point(60, 150);
        attendance.Size = new Size(1200, 500);
        attendance.AllowUserToAddRows = false;
        attendance.RowHeadersVisible = false;
        attendance.ReadOnly = true;
        attendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        attendance.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                            AnchorStyles.Right | AnchorStyles.Bottom;

        attendance.ColumnCount = 6;
        attendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        attendance.Columns[0].Name = "Date";
        attendance.Columns[1].Name = "Day";
        attendance.Columns[2].Name = "In Time";
        attendance.Columns[3].Name = "Out Time";
        attendance.Columns[4].Name = "Working Hours";
        attendance.Columns[5].Name = "Status";

        mainPanel.Controls.Add(attendance);
        swipeTitle = new Label();

        swipeTitle.Text = "Single Swipe";
        swipeTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        swipeTitle.Location = new Point(60, 30);
        swipeTitle.AutoSize = true;
        swipeTitle.Visible = false;

        mainPanel.Controls.Add(swipeTitle);
        swipeMsg = new Label();

        swipeMsg.Location = new Point(60, 90);
        swipeMsg.AutoSize = true;
        swipeMsg.Visible = false;

        mainPanel.Controls.Add(swipeMsg);
        manager = new Label();

        manager.Text = "Manager Name";
        manager.Location = new Point(60, 150);
        manager.AutoSize = true;
        manager.Visible = false;

        mainPanel.Controls.Add(manager);
        managerName = new TextBox();

        managerName.Location = new Point(60, 180);
        managerName.Size = new Size(250, 30);
        managerName.Visible = false;

        mainPanel.Controls.Add(managerName);
        apply = new Button();

        apply.Text = "Apply";
        apply.Click += Apply_Click;
        apply.Location = new Point(60, 230);
        apply.Size = new Size(100, 35);
        apply.Visible = false;

        mainPanel.Controls.Add(apply);
        statusTitle.Text = "Status Unknown";
        statusTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        statusTitle.Location = new Point(60, 30);
        statusTitle.AutoSize = true;
        statusTitle.Visible = false;

        mainPanel.Controls.Add(statusTitle);
        statusMsg.Location = new Point(60, 90);
        statusMsg.AutoSize = true;
        statusMsg.Visible = false;

        mainPanel.Controls.Add(statusMsg);
        statusManager.Text = "Manager Name";
        statusManager.Location = new Point(60, 150);
        statusManager.AutoSize = true;
        statusManager.Visible = false;

        mainPanel.Controls.Add(statusManager);
        statusManagerName.Location = new Point(60, 180);
        statusManagerName.Size = new Size(250, 30);
        statusManagerName.Visible = false;

        mainPanel.Controls.Add(statusManagerName);
        statusApply.Text = "Apply";
        statusApply.Location = new Point(60, 230);
        statusApply.Size = new Size(100, 35);
        statusApply.Visible = false;

        statusApply.Click += StatusApply_Click;

        mainPanel.Controls.Add(statusApply);
        negativeTitle.Text = "Negative Hours";
        negativeTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        negativeTitle.Location = new Point(60, 30);
        negativeTitle.AutoSize = true;
        negativeTitle.Visible = false;

        mainPanel.Controls.Add(negativeTitle);
        negativeMsg.Location = new Point(60, 90);
        negativeMsg.AutoSize = true;
        negativeMsg.Visible = false;

        mainPanel.Controls.Add(negativeMsg);
        avgTitle.Text = "Average Working Hours";
avgTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
avgTitle.Location = new Point(60, 30);
avgTitle.AutoSize = true;
avgTitle.Visible = false;

mainPanel.Controls.Add(avgTitle);
year1.Text = "2024-2025";
year1.Location = new Point(60, 90);
year1.Size = new Size(120, 35);
year1.Click += Year1_Click;
year1.Visible = false;

mainPanel.Controls.Add(year1);
year2.Text = "2025-2026";
year2.Location = new Point(200, 90);
year2.Size = new Size(120, 35);
year2.Click += Year2_Click;
year2.Visible = false;

mainPanel.Controls.Add(year2);
jan.Text = "Jan";
jan.Location = new Point(60, 160);
jan.Size = new Size(70, 35);
jan.Visible = false;

mainPanel.Controls.Add(jan);
feb.Text = "Feb";
feb.Location = new Point(140, 160);
feb.Size = new Size(70, 35);
feb.Visible = false;

mainPanel.Controls.Add(feb);
mar.Text = "Mar";
mar.Location = new Point(220, 160);
mar.Size = new Size(70, 35);
mar.Visible = false;
mainPanel.Controls.Add(mar);

apr.Text = "Apr";
apr.Location = new Point(300, 160);
apr.Size = new Size(70, 35);
apr.Visible = false;
mainPanel.Controls.Add(apr);

may.Text = "May";
may.Location = new Point(380, 160);
may.Size = new Size(70, 35);
may.Visible = false;
mainPanel.Controls.Add(may);

jun.Text = "Jun";
jun.Location = new Point(460, 160);
jun.Size = new Size(70, 35);
jun.Visible = false;
mainPanel.Controls.Add(jun);
jul.Text = "Jul";
jul.Location = new Point(60, 210);
jul.Size = new Size(70, 35);
jul.Visible = false;
mainPanel.Controls.Add(jul);

aug.Text = "Aug";
aug.Location = new Point(140, 210);
aug.Size = new Size(70, 35);
aug.Visible = false;
mainPanel.Controls.Add(aug);

sep.Text = "Sep";
sep.Location = new Point(220, 210);
sep.Size = new Size(70, 35);
sep.Visible = false;
mainPanel.Controls.Add(sep);

oct.Text = "Oct";
oct.Location = new Point(300, 210);
oct.Size = new Size(70, 35);
oct.Visible = false;
mainPanel.Controls.Add(oct);

nov.Text = "Nov";
nov.Location = new Point(380, 210);
nov.Size = new Size(70, 35);
nov.Visible = false;
mainPanel.Controls.Add(nov);

dec.Text = "Dec";
dec.Location = new Point(460, 210);
dec.Size = new Size(70, 35);
dec.Visible = false;
mainPanel.Controls.Add(dec);
jan.Click += Month_Click;
feb.Click += Month_Click;
mar.Click += Month_Click;
apr.Click += Month_Click;
may.Click += Month_Click;
jun.Click += Month_Click;
jul.Click += Month_Click;
aug.Click += Month_Click;
sep.Click += Month_Click;
oct.Click += Month_Click;
nov.Click += Month_Click;
dec.Click += Month_Click;
avgHours.Text = "Average Working Hours : 00:00";
avgHours.Location = new Point(60, 300);
avgHours.Font = new Font("Segoe UI", 12, FontStyle.Bold);
avgHours.AutoSize = true;
avgHours.Visible = false;

mainPanel.Controls.Add(avgHours);

    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Application.Exit();
        base.OnFormClosed(e);
    }
}