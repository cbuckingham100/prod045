<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblExeVersion = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpPanel = New System.Windows.Forms.Panel()
        Me.txtSerial_Number = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerial_Number_Display = New System.Windows.Forms.TextBox()
        Me.txtReading1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReading2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDifference = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrConvert = New System.Windows.Forms.Timer(Me.components)
        Me.txtGreen = New System.Windows.Forms.TextBox()
        Me.txtOrange = New System.Windows.Forms.TextBox()
        Me.txtRed = New System.Windows.Forms.TextBox()
        Me.txtV1 = New System.Windows.Forms.TextBox()
        Me.txtV2 = New System.Windows.Forms.TextBox()
        Me.txtPump = New System.Windows.Forms.TextBox()
        Me.lblLinxLibVersion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblExeVersion
        '
        Me.lblExeVersion.AutoSize = True
        Me.lblExeVersion.Location = New System.Drawing.Point(12, 435)
        Me.lblExeVersion.Name = "lblExeVersion"
        Me.lblExeVersion.Size = New System.Drawing.Size(28, 13)
        Me.lblExeVersion.TabIndex = 41
        Me.lblExeVersion.Text = "v1.0"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(664, 381)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(161, 51)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Tag = "2"
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'grpPanel
        '
        Me.grpPanel.BackgroundImage = Global.PROD045.My.Resources.Resources.LinxLogo_small
        Me.grpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.grpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grpPanel.Location = New System.Drawing.Point(18, 16)
        Me.grpPanel.Name = "grpPanel"
        Me.grpPanel.Size = New System.Drawing.Size(114, 47)
        Me.grpPanel.TabIndex = 54
        '
        'txtSerial_Number
        '
        Me.txtSerial_Number.BackColor = System.Drawing.Color.Yellow
        Me.txtSerial_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerial_Number.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSerial_Number.Location = New System.Drawing.Point(15, 331)
        Me.txtSerial_Number.Name = "txtSerial_Number"
        Me.txtSerial_Number.Size = New System.Drawing.Size(350, 80)
        Me.txtSerial_Number.TabIndex = 33
        Me.txtSerial_Number.Tag = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(159, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 24)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Printhead PCB Vacuum Test"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 313)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 15)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Serial Number Input"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.Silver
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStatus.Location = New System.Drawing.Point(15, 208)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(448, 80)
        Me.txtStatus.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(471, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Serial Number"
        '
        'txtSerial_Number_Display
        '
        Me.txtSerial_Number_Display.BackColor = System.Drawing.Color.Silver
        Me.txtSerial_Number_Display.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerial_Number_Display.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSerial_Number_Display.Location = New System.Drawing.Point(473, 208)
        Me.txtSerial_Number_Display.Name = "txtSerial_Number_Display"
        Me.txtSerial_Number_Display.Size = New System.Drawing.Size(350, 80)
        Me.txtSerial_Number_Display.TabIndex = 61
        '
        'txtReading1
        '
        Me.txtReading1.BackColor = System.Drawing.Color.Silver
        Me.txtReading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReading1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReading1.Location = New System.Drawing.Point(616, 34)
        Me.txtReading1.Name = "txtReading1"
        Me.txtReading1.Size = New System.Drawing.Size(208, 29)
        Me.txtReading1.TabIndex = 63
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(612, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Reading 1"
        '
        'txtReading2
        '
        Me.txtReading2.BackColor = System.Drawing.Color.Silver
        Me.txtReading2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReading2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReading2.Location = New System.Drawing.Point(616, 87)
        Me.txtReading2.Name = "txtReading2"
        Me.txtReading2.Size = New System.Drawing.Size(208, 29)
        Me.txtReading2.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(612, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Reading 2"
        '
        'txtDifference
        '
        Me.txtDifference.BackColor = System.Drawing.Color.Silver
        Me.txtDifference.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDifference.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDifference.Location = New System.Drawing.Point(616, 143)
        Me.txtDifference.Name = "txtDifference"
        Me.txtDifference.Size = New System.Drawing.Size(208, 29)
        Me.txtDifference.TabIndex = 67
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(612, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Difference"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.Red
        Me.lblResult.Location = New System.Drawing.Point(370, 334)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(139, 73)
        Me.lblResult.TabIndex = 68
        Me.lblResult.Text = "Fail"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(664, 309)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(161, 51)
        Me.btnStart.TabIndex = 69
        Me.btnStart.Tag = "1"
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'tmrConvert
        '
        Me.tmrConvert.Interval = 200
        '
        'txtGreen
        '
        Me.txtGreen.BackColor = System.Drawing.Color.Lime
        Me.txtGreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGreen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGreen.Location = New System.Drawing.Point(18, 147)
        Me.txtGreen.Name = "txtGreen"
        Me.txtGreen.Size = New System.Drawing.Size(45, 20)
        Me.txtGreen.TabIndex = 70
        '
        'txtOrange
        '
        Me.txtOrange.BackColor = System.Drawing.Color.DarkOrange
        Me.txtOrange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOrange.Location = New System.Drawing.Point(18, 121)
        Me.txtOrange.Name = "txtOrange"
        Me.txtOrange.Size = New System.Drawing.Size(45, 20)
        Me.txtOrange.TabIndex = 71
        '
        'txtRed
        '
        Me.txtRed.BackColor = System.Drawing.Color.Red
        Me.txtRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRed.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRed.Location = New System.Drawing.Point(18, 95)
        Me.txtRed.Name = "txtRed"
        Me.txtRed.Size = New System.Drawing.Size(45, 20)
        Me.txtRed.TabIndex = 72
        '
        'txtV1
        '
        Me.txtV1.BackColor = System.Drawing.Color.Red
        Me.txtV1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtV1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtV1.Location = New System.Drawing.Point(112, 96)
        Me.txtV1.Name = "txtV1"
        Me.txtV1.Size = New System.Drawing.Size(80, 20)
        Me.txtV1.TabIndex = 73
        Me.txtV1.Text = "Valve 1"
        Me.txtV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtV2
        '
        Me.txtV2.BackColor = System.Drawing.Color.Red
        Me.txtV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtV2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtV2.Location = New System.Drawing.Point(207, 96)
        Me.txtV2.Name = "txtV2"
        Me.txtV2.Size = New System.Drawing.Size(80, 20)
        Me.txtV2.TabIndex = 74
        Me.txtV2.Text = "Valve 2"
        Me.txtV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPump
        '
        Me.txtPump.BackColor = System.Drawing.Color.Red
        Me.txtPump.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPump.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPump.Location = New System.Drawing.Point(303, 96)
        Me.txtPump.Name = "txtPump"
        Me.txtPump.Size = New System.Drawing.Size(80, 20)
        Me.txtPump.TabIndex = 75
        Me.txtPump.Text = "PUMP"
        Me.txtPump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLinxLibVersion
        '
        Me.lblLinxLibVersion.AutoSize = True
        Me.lblLinxLibVersion.Location = New System.Drawing.Point(56, 435)
        Me.lblLinxLibVersion.Name = "lblLinxLibVersion"
        Me.lblLinxLibVersion.Size = New System.Drawing.Size(28, 13)
        Me.lblLinxLibVersion.TabIndex = 76
        Me.lblLinxLibVersion.Text = "v1.0"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 470)
        Me.Controls.Add(Me.lblLinxLibVersion)
        Me.Controls.Add(Me.txtPump)
        Me.Controls.Add(Me.txtV2)
        Me.Controls.Add(Me.txtV1)
        Me.Controls.Add(Me.txtRed)
        Me.Controls.Add(Me.txtOrange)
        Me.Controls.Add(Me.txtGreen)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtDifference)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtReading2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtReading1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSerial_Number_Display)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSerial_Number)
        Me.Controls.Add(Me.grpPanel)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblExeVersion)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PROD045 - Printhead Vacuum Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents lblExeVersion As Label
    Friend WithEvents grpPanel As Panel
    Friend WithEvents txtSerial_Number As TextBox

    Private TextBoxOrder As New Dictionary(Of TextBox, TextBox)()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        AddHandler txtSerial_Number.KeyDown, AddressOf BarcodeInputKeyDown

        lblExeVersion.Text = "Exe:" & sExeVersion

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Private Sub BarcodeInputKeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter AndAlso ActiveControl.[GetType]() = GetType(TextBox) Then
            StartProcess()
        End If
    End Sub


    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSerial_Number_Display As TextBox
    Friend WithEvents txtReading1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtReading2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDifference As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tmrConvert As Timer
    Friend WithEvents txtGreen As TextBox
    Friend WithEvents txtOrange As TextBox
    Friend WithEvents txtRed As TextBox
    Friend WithEvents txtV1 As TextBox
    Friend WithEvents txtV2 As TextBox
    Friend WithEvents txtPump As TextBox
    Friend WithEvents lblLinxLibVersion As Label
End Class
